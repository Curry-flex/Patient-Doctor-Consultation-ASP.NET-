using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace PatientDoctor
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=CURRYFLEX;Initial Catalog=PatientDoctor;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("sp_role", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@uname", txtusername.Text);
                    cmd.Parameters.AddWithValue("@upass", txtpassword.Text);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if(dr.HasRows)
                    {
                        dr.Read();
                        if(dr[3].ToString()=="Doctor")
                        {
                            HttpCookie cook = new HttpCookie("loginfo");
                            cook["username"] = txtusername.Text;
                            Response.Cookies.Add(cook);
                            Response.Redirect("Doctor.aspx");
                        }
                        else if (dr[3].ToString() == "Reciptionist")
                        {
                            HttpCookie cook = new HttpCookie("loginfo");
                            cook["username"] = txtusername.Text;
                            Response.Cookies.Add(cook);
                            Response.Redirect("HOME.aspx");
                        }
                        else if(dr[3].ToString()=="Labtech")
                        {
                            HttpCookie cook = new HttpCookie("loginfo");
                            cook["username"] = txtusername.Text;
                            Response.Cookies.Add(cook);
                            Response.Redirect("Labaratory.aspx");
                        }
                    }

                    else
                    {
                        lab1.Text = "Incorrect username or password";
                    }
                }

            }catch(Exception ex)
            {

            }
        }

    }
}