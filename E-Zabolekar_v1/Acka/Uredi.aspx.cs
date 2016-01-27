using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acka
{
    public partial class TimZabolekari : System.Web.UI.Page
    {
        private string korisnik;
        bool flag = true;
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString);

        SqlCommand komanda;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["korisnik"] == null)
            {
                Response.Redirect("zaprofil.aspx");
            }
            if (!IsPostBack)
            {

                if (Session["korisnik"] != null)
                {
                    korisnik = (string)Session["korisnik"];

                }
                ispolni();
                popolniZabolekari();



            }

        }



        protected void gv1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvZabolekari.EditIndex = e.NewEditIndex;

        }
        protected void gv1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = e.RowIndex;


            GridViewRow row = (GridViewRow)gvZabolekari.Rows[index];
            Label eid = (Label)row.FindControl("lblzabolekarid");
            TextBox txtime = (TextBox)row.FindControl("txtzabolekarime");
            TextBox txtopis = (TextBox)row.FindControl("txtopis");
            TextBox txttelefon = (TextBox)row.FindControl("txttelefon");
            TextBox txtuser = (TextBox)row.FindControl("txtuser");
            TextBox txtlokacija = (TextBox)row.FindControl("txtlokacija");

            FileUpload fu = (FileUpload)row.FindControl("fu1");



            if (fu.HasFile)
            {

                string file = System.IO.Path.Combine(Server.MapPath("~/images/"), fu.FileName);
                fu.SaveAs(file);
                string path = "~/images/" + fu.FileName.ToString();

                SqlCommand cmd1 = new SqlCommand("update zabolekarr set imageurl = '" + path + "' where zabolekar_id='" + Convert.ToInt32(eid.Text) + "'", con);


                con.Open();
                int res2 = cmd1.ExecuteNonQuery();
                con.Close();
            }
            //    komanda.commandtext = "update korisnik set lokacija='" + novo + "' where user_name='" + korisnik + "'";
            SqlCommand cmd2 = new SqlCommand("update zabolekarr set ime_prezime = '" + txtime.Text + "',opis='" + txtopis.Text + "',telefon='" + txttelefon.Text + "',lokacija='" + txtlokacija.Text + "' where zabolekar_id='" + Convert.ToInt32(eid.Text) + "'", con);
            con.Open();
            int res1 = cmd2.ExecuteNonQuery();
            con.Close();

            if (res1 == 1)
            {
                Response.Write("<script>alert('updation done!')</script>");
            }
            gvZabolekari.EditIndex = -1;

            popolniZabolekari();
        }

        private void popolniZabolekari()
        {
            con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            string sqlString = "SELECT * FROM Zabolekarr";
            komanda = new SqlCommand(sqlString, con);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                adapter.Fill(ds, "Zabolekari");
                gvZabolekari.DataSource = ds;
                gvZabolekari.DataBind();
                //    lblPoraka.Text = ds.Tables[0].Rows[0]["broj"].ToString();
                ViewState["dataset"] = ds;
            }
            catch (Exception err)
            {

            }
            finally
            {
                con.Close();
            }
        }
        protected void gv1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvZabolekari.EditIndex = -1;

            popolniZabolekari();
        }
        protected void gv1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;

            GridViewRow row = (GridViewRow)gvZabolekari.Rows[index];

            Label eid = (Label)row.FindControl("lblzabolekarid");

            SqlCommand cmd = new SqlCommand("delete from zabolekarr where zabolekar_id=" + Convert.ToInt32(eid.Text) + "", con);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();

            if (res == 1)
            {
                Response.Write("<script>alert('deletion done!')</script>");
            }

            popolniZabolekari();
        }
        protected void gv1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvZabolekari.PageIndex = e.NewPageIndex;

            popolniZabolekari();
        }

        private void ispolni()
        {
            con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            string sqlString = "SELECT * FROM Termin";
            komanda = new SqlCommand(sqlString, con);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                adapter.Fill(ds, "Korisnici");
                GridView1.DataSource = ds;
                GridView1.DataBind();
                //    lblPoraka.Text = ds.Tables[0].Rows[0]["broj"].ToString();
                ViewState["dataset"] = ds;
            }
            catch (Exception err)
            {

            }
            finally
            {
                con.Close();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //DataSet ds = (DataSet)ViewState["dataset"];

            GridView1.EditIndex = e.NewEditIndex;
            //GridView1.DataSource = ds;
            // GridView1.DataBind();
            ispolni();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // DataSet ds = (DataSet)ViewState["dataset"];
            GridView1.EditIndex = -1;
            // GridView1.DataSource = ds;
            // GridView1.DataBind();
            ispolni();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;


            int index = e.RowIndex;


            GridViewRow row = (GridViewRow)GridView1.Rows[index];
            Label eid = (Label)row.FindControl("lblTermin");
            TextBox txtime = (TextBox)row.FindControl("txtKorisnik");
            TextBox txtopis = (TextBox)row.FindControl("txtZabolekar");
            TextBox txttelefon = (TextBox)row.FindControl("txtOd");
            TextBox txtuser = (TextBox)row.FindControl("txtDo");
            TextBox txtlokacija = (TextBox)row.FindControl("txtDatum");

            //    komanda.commandtext = "update korisnik set lokacija='" + novo + "' where user_name='" + korisnik + "'";
            SqlCommand cmd2 = new SqlCommand("update termin set korisnik_id = '" + txtime.Text + "',zabolekar_id='" + txtopis.Text + "',od='" + txttelefon.Text + "',do='" + txtuser.Text + "',datum='" + txtlokacija.Text + "' where termin_id='" + Convert.ToInt32(eid.Text) + "'", con);
            con.Open();
            int res1 = cmd2.ExecuteNonQuery();
            con.Close();


            GridView1.EditIndex = -1;




            /*TextBox tb = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].Controls[0];
            komanda.Parameters.AddWithValue("@ime_prezime", tb.Text);
             */
            // komanda.Parameters.AddWithValue("@korisnik_ID",);

            int efekt = 0;
            try
            {
                con.Open();
                efekt = komanda.ExecuteNonQuery();
            }
            catch (Exception err)
            {

            }
            finally
            {
                con.Close();
                GridView1.EditIndex = -1;
            }

            ispolni();


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /*   protected void Grid(object sender, GridViewCancelEditEventArgs e)
           {
               GridView1.EditIndex = -1;

               ispolni();


            
           }
          */
        protected void GridView1_RowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;

            ispolni();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;

            GridViewRow row = (GridViewRow)GridView1.Rows[index];

            Label eid = (Label)row.FindControl("lblTermin");

            SqlCommand cmd = new SqlCommand("delete from termin where termin_id=" + Convert.ToInt32(eid.Text) + "", con);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();


            
            ispolni();


        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            ispolni();

        }
    }
}