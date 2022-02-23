using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;

namespace PatientDoctor
{
    public partial class HOME : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=CURRYFLEX;Initial Catalog=PatientDoctor;Integrated Security=True");
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpCookie cookie = Request.Cookies["loginfo"];
           // lablename.Text = cookie["username"];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String sql = "insert into patient values('" + txtfname.Text + "','" + txtlname.Text + "','" + dropgender.SelectedItem.Text+ "','" + txtAge.Text + "','" + txtlocation.Text + "','"+txtcontact.Text+"')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                Response.Write(ex);
            }

     
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}