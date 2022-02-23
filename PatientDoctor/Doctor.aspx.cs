using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data;

namespace PatientDoctor
{
    public partial class Doctor : System.Web.UI.Page
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
            //lablenmae.Text = cookie["username"];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;


         
        }

        public void getdata()
        {
            con.Open();
            String sql = "select *from patient";
            SqlCommand cmd = new SqlCommand(sql, con);
            viewgrid.DataSource = cmd.ExecuteReader();

            viewgrid.DataBind();
            con.Close();
        }
        public void search()
        {
            SqlConnection com = new SqlConnection("Data Source=CURRYFLEX;Initial Catalog=PatientDoctor;Integrated Security=True");
            com.Open();
            SqlCommand cmd = com.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select *from patient where fname='" + txtsearch1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            viewgrid.DataSource = dt;
            com.Close();


        }
        

        protected void Button2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            feedback();
        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        public void feedback()
        {
            con.Open();
            String sql = "select *from testresult";
            SqlCommand cmd = new SqlCommand(sql, con);
            feedgrid.DataSource = cmd.ExecuteReader();
            feedgrid.DataBind();
            con.Close();
        }

        protected void viewgrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = viewgrid.SelectedRow;
            txtfname.Text = row.Cells[2].Text;
            txtlname.Text = row.Cells[3].Text;
            dropgender.SelectedItem.Text = row.Cells[4].Text;
            txtage.Text = row.Cells[5].Text;
            txtlocation.Text = row.Cells[6].Text;
            txtcontact.Text = row.Cells[7].Text;

        }

        protected void viewgrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = viewgrid.SelectedRow;

            if(row != null)
            {

                GridViewRow gr = viewgrid.SelectedRow;
                txtfname.Text = gr.Cells[1].Text;
                txtlname.Text = gr.Cells[2].Text;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String sql = "insert into testdisease values('" + txtfname.Text + "','" + txtlname.Text + "','" + dropgender.SelectedItem.Text + "','" + txtage.Text + "','" + txtlast.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

        

        }

        protected void txttest_TextChanged(object sender, EventArgs e)
        {

        }

        protected void feedgrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = feedgrid.SelectedRow;

            fname.Text = row.Cells[2].Text;
            lname.Text = row.Cells[3].Text;
            gender.Text = row.Cells[4].Text;
            age.Text = row.Cells[5].Text;
            test.Text = row.Cells[6].Text;
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String sql = "insert into prescription values('" +fname.Text + "','" + lname.Text + "','" + gender.SelectedItem.Text + "','" + age.Text + "','" + prescription.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            search();
        }
    }
    }
