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
    public partial class PorakiKorisnik : System.Web.UI.Page
    {
        private string korisnik;
        private int korisnikID;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["korisnik"] == null)
            {
                Response.Redirect("zapregled.aspx");

            }
            else
            {
                korisnik = (string)Session["korisnik"];
                if (!IsPostBack)
                {
                    ispolniZabolekari();
                }

            }

        }


        private void ispolniZabolekari()
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            string sqlString = "SELECT * FROM Zabolekarr";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Zabolekari");
                listaZabolekari.DataSource = ds;
                listaZabolekari.DataBind();
                listaZabolekari.DataTextField = "ime_prezime";
                listaZabolekari.DataValueField = "zabolekar_ID";
                listaZabolekari.DataBind();

                //    lblPoraka.Text = ds.Tables[0].Rows[0]["broj"].ToString();
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
        protected void ispratiPoraka(object sender, EventArgs e)
        {

            korisnikID = getIDfromusername();

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "INSERT INTO Poraki (korisnik_ID,zabolekar_ID,naslov,status,ispratenaOd,sodrzina)" +
                "VALUES(@korisnik_ID,@zabolekar_ID,@naslov,@status,@ispratenaOd, @sodrzina) ";
            komanda.Parameters.AddWithValue("@korisnik_ID", korisnikID);
            komanda.Parameters.AddWithValue("@zabolekar_ID", listaZabolekari.SelectedValue);
            komanda.Parameters.AddWithValue("@naslov", naslovPoraka.Value);
            komanda.Parameters.AddWithValue("@sodrzina", opisPoraka.Value);
            komanda.Parameters.AddWithValue("@status", 0);
            komanda.Parameters.AddWithValue("@ispratenaOd", 0);

            try
            {
                konekcija.Open();
                komanda.ExecuteNonQuery();


            }
            catch (Exception err)
            {

                lblError.Text = err.Message;
            }
            finally
            {
                konekcija.Close();
            }

            listaZabolekari.ClearSelection();
            naslovPoraka.Value = "";
            opisPoraka.InnerText = "";
        }


        private bool proveriUslovi()
        {
            bool proverka = false;
            if (listaZabolekari.SelectedIndex != -1)
            {
                if (naslovPoraka.Value.Length > 0)
                {
                    if (opisPoraka.InnerText.Length > 5)
                    {
                        proverka = true;
                    }

                    else
                    {
                        proverka = false;
                        lblError.Text = "Немате напишано состав на пораката!!";
                        lblError.ForeColor = System.Drawing.Color.Red;
                    }

                }
                else
                {

                    proverka = false;
                    lblError.Text = "Немате напишано наслов на пораката!!";
                    lblError.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                proverka = false;
                lblError.Text = "Немате изберено заболекар!!";
                lblError.ForeColor = System.Drawing.Color.Red;
            }

            return proverka;
        }
        private int getIDfromusername()
        {
            int id = 0;
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            string sqlString = "SELECT korisnik_ID FROM Korisnik where user_name='" + korisnik + "'";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Korisnik");
                id = Convert.ToInt32(ds.Tables[0].Rows[0]["korisnik_ID"].ToString());
                ViewState["dataset"] = ds;
            }
            catch (Exception err)
            {

            }
            finally
            {
                konekcija.Close();
            }

            return id;
        }


            
    }
}