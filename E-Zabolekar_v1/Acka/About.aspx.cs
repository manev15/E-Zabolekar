using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acka
{
    public partial class About : Page
    {
        private string korisnik;
        bool flag = true;
        protected void Page_Load(object sender, EventArgs e)
        {
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
    }
}