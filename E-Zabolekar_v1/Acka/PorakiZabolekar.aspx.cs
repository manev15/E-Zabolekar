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
    public partial class PorakiZabolekar : System.Web.UI.Page
    {
        private int zabolekar_id;
        private int korisnik_id;
        private string naslov,imezabolekar;
        private string sodrzina;
        private string zabolekar;

        protected void Page_Load(object sender, EventArgs e)
        {
            imezabolekar=(string)Session["korisnik"];
            zabolekar_id=getidfromIme(imezabolekar);

            if (!IsPostBack)
            {
                ispolniPrimeni();
                ispolniPrateni();
                ispolniPacienti();
            }

            }

        private void ispolniPacienti()
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            string sqlString = "SELECT * FROM Korisnik";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Zabolekari");
                listaKorisnici.DataSource = ds;
                listaKorisnici.DataBind();
                listaKorisnici.DataTextField = "ime_prezime";
                listaKorisnici.DataValueField = "korisnik_ID";
                listaKorisnici.DataBind();

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
            string sqlString = "SELECT zabolekar_ID FROM Zabolekarr where user_name='" + imezabolekar + "'";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Korisnik");
                id = Convert.ToInt32(ds.Tables[0].Rows[0]["zabolekar_ID"].ToString());
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




        private int getidfromIme(string imezabolekar)
        {
            int id = 0;
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            string sqlString = "SELECT zabolekar_ID FROM Zabolekarr where user_name='" + imezabolekar + "'";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Korisnik");
                id = Convert.ToInt32(ds.Tables[0].Rows[0]["zabolekar_ID"].ToString());
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

        private string zemiIme(int korisnik_id)
            {
                string ime = "";
                SqlConnection konekcija = new SqlConnection();
                konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
                string sqlString = "SELECT ime_prezime FROM Korisnik where korisnik_ID='" + korisnik_id + "'";
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
        private void ispolniPrimeni()
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            string sqlString = "SELECT * FROM Poraki where zabolekar_id='" + zabolekar_id + "' and ispratenaOd=0";
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
                        korisnik_id = Convert.ToInt32(row["korisnik_ID"].ToString());
                        string imeKorisnik = zemiIme(korisnik_id);
//                        string kratkaSodrzina = sodrzina.Substring(0, 30);

                        html = html + "<li><a href='#' role='tab' data-toggle='tab'><span class='mail-sender'>" + imeKorisnik + "</span><span class='mail-subject'>" + naslov + "</span><span class='mail-message-preview'>" + sodrzina + "</span></li>";
                        
                    
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

        private void ispolniPrateni()
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            string sqlString = "SELECT * FROM Poraki where zabolekar_id='" + zabolekar_id + "' and ispratenaOd=1";
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
                        korisnik_id = Convert.ToInt32(row["korisnik_ID"].ToString());
                        string imeKorisnik = zemiIme(korisnik_id);
                        //                        string kratkaSodrzina = sodrzina.Substring(0, 30);

                        html = html + "<li><a href='#' role='tab' data-toggle='tab'><span class='mail-sender'>" + imeKorisnik + "</span><span class='mail-subject'>" + naslov + "</span><span class='mail-message-preview'>" + sodrzina + "</span></li>";


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

        protected void Button1_Click(object sender, EventArgs e)
        {
            int zaboID = getIDfromusername();

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "INSERT INTO Poraki (korisnik_ID,zabolekar_ID,naslov,status,ispratenaOd,sodrzina)" +
                "VALUES(@korisnik_ID,@zabolekar_ID,@naslov,@status,@ispratenaOd, @sodrzina) ";
            komanda.Parameters.AddWithValue("@korisnik_ID", listaKorisnici.SelectedValue);
            komanda.Parameters.AddWithValue("@zabolekar_ID", zaboID);
            komanda.Parameters.AddWithValue("@naslov", naslovPoraka.Value);
            komanda.Parameters.AddWithValue("@sodrzina", opisPoraka.Value);
            komanda.Parameters.AddWithValue("@status", 0);
            komanda.Parameters.AddWithValue("@ispratenaOd", 1);

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

            listaKorisnici.ClearSelection();
            naslovPoraka.Value = "";
            opisPoraka.InnerText = "";
            ispolniPacienti();
            ispolniPrimeni();
            ispolniPrateni();
        }



    }
}