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
               
                popolniZabolekari();

            }

        }

        private void popolniZabolekari()
        {
           string ime_prezime;
           string opis;
           string telefon;
           string lokacija;
              string slika;
         

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            string sqlString = "SELECT * FROM Zabolekarr ";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();
            string html = "";
            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Termin");

                gvZabolekari.DataSource = ds;
                gvZabolekari.DataBind();
                //datum = ds.Tables[0].Rows[0]["datum"].ToString();
                //od = ds.Tables[0].Rows[0]["od"].ToString();
                //dot = ds.Tables[0].Rows[0]["do"].ToString();
                //zabolekarid = Convert.ToInt32(ds.Tables[0].Rows[0]["zabolekar_id"].ToString());

                           
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                     //   string imag = row["imageUrl"].ToString();
                        ime_prezime = row["ime_prezime"].ToString();
                        opis = row["opis"].ToString();
                        telefon = row["telefon"].ToString();
                        lokacija = row["lokacija"].ToString();
                        slika = row["imageUrl"].ToString();
                        string[] niza;
                       
                        if (slika == "")
                        {
                            slika = "/images/default.jpg";
                            
                        }
                        else
                        {
                            niza = slika.Split('/');
                            slika = "/images/" + niza[2];
                        }

                        if (flag)
                        {
                            flag = false;
                                                   
                                html = html + " <li>   <div class='timeline-image'>  <img  style='width: 100%; height: 100%' class='img-circle' src='" + slika + "' alt=''> </div> <div class='timeline-panel'> <div class='timeline-heading'>  <h4>" + ime_prezime + "</h4> <h5 class='subheading'>Тел.број:" + telefon + " </h5><h5 class='subheading'> Локација:" + lokacija + "</h5> </div><div class='timeline-body'> <p class='text-muted'>" + opis + "</p> </div> </div> </li>";
                      
                            
                        }
                        else
                        {
                            flag = true;
                         
                           
                                html = html + " <li class='timeline-inverted'>   <div class='timeline-image'>  <img style='width: 100%; height: 100%' class='img-circle' src='" + slika + "' alt=''> </div> <div class='timeline-panel'> <div class='timeline-heading'>  <h4>" + ime_prezime + "</h4> <h5 class='subheading'>Тел.број:" + telefon + "</h5><h5 class='subheading'> Локација:" + lokacija + "</h5> </div><div class='timeline-body'> <p class='text-muted'>" + opis + "</p> </div> </div> </li>";

                           
                        }

              }
                }

               dodadiZabolekari.Controls.Add(new LiteralControl(html));
                ViewState["dataset"] = ds;
            }
            catch (Exception err)
            {

            }
            finally
            {
                konekcija.Close();
            }


        }
       
        protected void gv1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvZabolekari.EditIndex = e.NewEditIndex;
            popolniZabolekari();
        }
        protected void gv1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index =e.RowIndex ;


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
    }
}