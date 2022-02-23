using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace PatientDoctor
{
    public partial class Labaratory : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=CURRYFLEX;Initial Catalog=PatientDoctor;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
            }
            getdata();

            HttpCookie cookie = Request.Cookies["loginfo"];
            //lablename.Text = cookie["username"];
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void getdata()
        {
            con.Open();
            String sql = "select *from testdisease";
            SqlCommand cmd = new SqlCommand(sql, con);
            labgrid.DataSource = cmd.ExecuteReader();

            labgrid.DataBind();
            con.Close();
        }
        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void txtsearch_TextChanged(object sender, EventArgs e)
        {
                    }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void labgrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = labgrid.SelectedRow;

            txtfname.Text = row.Cells[2].Text;
            txtlname.Text = row.Cells[3].Text;
            dropgender.SelectedItem.Text = row.Cells[4].Text;
            txtage.Text = row.Cells[5].Text;
            txttest.Text = row.Cells[6].Text;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String sql = "insert into testResult values('" + txtfname.Text + "','" + txtlname.Text + "','" + dropgender.SelectedItem.Text + "','" + txtage.Text + "','"+txtresult.Text+"')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
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
