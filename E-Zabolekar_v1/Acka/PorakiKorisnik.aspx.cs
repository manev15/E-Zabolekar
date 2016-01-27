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
        private int zabolekar_id;

        private string naslov, imezabolekar;
        private string sodrzina;
        private string zabolekar;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["korisnik"] == null)
            {
                Response.Redirect("zaprofil.aspx");
            }
            else
            {

                korisnik = (string)Session["korisnik"];
                korisnikID = getidfromIme(korisnik);
                if (!IsPostBack)
                {
                    ispolniPrimeni();
                    ispolniPrateni();
                    ispolniZabolekari();
                }

            }
        }

        private int getidfromIme(string korisnik)
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

        private void ispolniPrimeni()
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            string sqlString = "SELECT * FROM Poraki where korisnik_id='" + korisnikID + "' and ispratenaOd=1";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();
            string html = "";
            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Termin");


                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {

                        naslov = row["naslov"].ToString();
                        sodrzina = row["sodrzina"].ToString();
                        zabolekar_id = Convert.ToInt32(row["zabolekar_ID"].ToString());
                        string imeZabolekar = zemiIme(zabolekar_id);
                        //                        string kratkaSodrzina = sodrzina.Substring(0, 30);

                        html = html + "<li><a href='#' role='tab' data-toggle='tab'><span class='mail-sender'>" + imeZabolekar + "</span><span class='mail-subject'>" + naslov + "</span><span class='mail-message-preview'>" + sodrzina + "</span></li>";


                    }
                }

                placePrimeni.Controls.Add(new LiteralControl(html));
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
        private string zemiIme(int zabolekarID)
        {
            string ime = "";
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            string sqlString = "SELECT ime_prezime FROM Zabolekarr where zabolekar_ID='" + zabolekarID + "'";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Korisnik");
                ime = ds.Tables[0].Rows[0]["ime_prezime"].ToString();
                ViewState["dataset"] = ds;
            }
            catch (Exception err)
            {

            }
            finally
            {
                konekcija.Close();
            }

            return ime;
        }
        private void ispolniPrateni()
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            string sqlString = "SELECT * FROM Poraki where korisnik_id='" + korisnikID + "' and ispratenaOd=0";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();
            string html = "";
            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Termin");


                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {

                        naslov = row["naslov"].ToString();
                        sodrzina = row["sodrzina"].ToString();
                        zabolekar_id = Convert.ToInt32(row["zabolekar_ID"].ToString());
                        string imeZabolekar = zemiIme(zabolekar_id);
                        //                        string kratkaSodrzina = sodrzina.Substring(0, 30);

                        html = html + "<li><a href='#' role='tab' data-toggle='tab'><span class='mail-sender'>" + imeZabolekar + "</span><span class='mail-subject'>" + naslov + "</span><span class='mail-message-preview'>" + sodrzina + "</span></li>";


                    }
                }

                placePrateni.Controls.Add(new LiteralControl(html));
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



        protected void btn1_Click(object sender, EventArgs e)
        {
            int korisID = getIDfromusername();

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "INSERT INTO Poraki (korisnik_ID,zabolekar_ID,naslov,status,ispratenaOd,sodrzina)" +
                "VALUES(@korisnik_ID,@zabolekar_ID,@naslov,@status,@ispratenaOd, @sodrzina) ";
            komanda.Parameters.AddWithValue("@korisnik_ID", korisID);
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


            ispolniPrimeni();
            ispolniPrateni();
            ispolniZabolekari();
        }



    }

}