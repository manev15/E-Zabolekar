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
    public partial class Anketi : System.Web.UI.Page
    {
        private string html = "";
        private int zabolekar_id;
        private int korisnik_id;
        private string naslov, imezabolekar;
        private string sodrzina;
        private string zabolekar;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["korisnik"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                imezabolekar = (string)Session["korisnik"];
                zabolekar_id = getidfromIme(imezabolekar);
                if (!IsPostBack)
                {


                }
            }

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            dodadiAnketa();
            dodadiPrasanje();
            //     dodadiOdgovori();

            // popolnuvanje();
        }

        private void dodadiPrasanje()
        {

            int anketaID = getIdAnketa();

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "INSERT INTO Prasanja (anketa_ID,ime_prasanje)" +
                "VALUES(@anketa_ID,@ime_prasanje) ";
            komanda.Parameters.AddWithValue("@anketa_ID", anketaID);
            komanda.Parameters.AddWithValue("@ime_prasanje", txtPrasanje.Text);


            try
            {
                konekcija.Open();
                komanda.ExecuteNonQuery();


            }
            catch (Exception err)
            {

                //      lblError.Text = err.Message;
            }
            finally
            {

                konekcija.Close();
            }

        }

        private void dodadiAnketa()
        {
            int zaboID = getIDfromusername();

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "INSERT INTO Anketa (ime_anketa,zabolekar_ID)" +
                "VALUES(@ime_anketa,@zabolekar_ID) ";
            komanda.Parameters.AddWithValue("@ime_anketa", txtAnketa.Value);
            komanda.Parameters.AddWithValue("@zabolekar_ID", zaboID);


            try
            {
                konekcija.Open();
                komanda.ExecuteNonQuery();


            }
            catch (Exception err)
            {

                //      lblError.Text = err.Message;
            }
            finally
            {
                konekcija.Close();
            }

            //     listaKorisnici.ClearSelection();
            //    naslovPoraka.Value = "";
            //   opisPoraka.InnerText = "";

            //   ispolniPrimeni();
            //  ispolniPrateni();
            //   ispolniPacienti();

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
        private int getIdAnketa()
        {
            int id = 0;
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            string sqlString = "SELECT anketa_ID FROM Anketa where ime_anketa='" + txtAnketa.Value + "'";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Korisnik");
                id = Convert.ToInt32(ds.Tables[0].Rows[0]["anketa_ID"].ToString());
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
        private int getIdPrasanje()
        {
            int id = 0;
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            string sqlString = "SELECT prasanje_ID FROM Prasanja where ime_prasanje='" + txtPrasanje.Text + "'";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Korisnik");
                id = Convert.ToInt32(ds.Tables[0].Rows[0]["prasanje_ID"].ToString());
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
        protected void btndodadi_Click(object sender, EventArgs e)
        {
            int anketa = getIdAnketa();
            if (anketa == 0)
            {
                dodadiAnketa();
                dodadiPrasanje();
                if (txtOdgovor1.Text.Length > 0)
                {
                    string odgovor = txtOdgovor1.Text;
                    dodadiOdgovor(odgovor);
                }
                if (txtOdgovor2.Text.Length > 0)
                {
                    string odgovor = txtOdgovor2.Text;
                    dodadiOdgovor(odgovor);
                }
                if (txtOdgovor3.Text.Length > 0)
                {
                    string odgovor = txtOdgovor3.Text;
                    dodadiOdgovor(odgovor);
                }
                if (txtOdgovor4.Text.Length > 0)
                {
                    string odgovor = txtOdgovor4.Text;
                    dodadiOdgovor(odgovor);
                }
                if (txtOdgovor5.Text.Length > 0)
                {
                    string odgovor = txtOdgovor5.Text;
                    dodadiOdgovor(odgovor);
                }
                if (txtOdgovor6.Text.Length > 0)
                {
                    string odgovor = txtOdgovor6.Text;
                    dodadiOdgovor(odgovor);
                }
            }
            else
            {
                dodadiPrasanje();
                if (txtOdgovor1.Text.Length > 0)
                {
                    string odgovor = txtOdgovor1.Text;
                    dodadiOdgovor(odgovor);
                }
                if (txtOdgovor2.Text.Length > 0)
                {
                    string odgovor = txtOdgovor2.Text;
                    dodadiOdgovor(odgovor);
                }
                if (txtOdgovor3.Text.Length > 0)
                {
                    string odgovor = txtOdgovor3.Text;
                    dodadiOdgovor(odgovor);
                }
                if (txtOdgovor4.Text.Length > 0)
                {
                    string odgovor = txtOdgovor4.Text;
                    dodadiOdgovor(odgovor);
                }
                if (txtOdgovor5.Text.Length > 0)
                {
                    string odgovor = txtOdgovor5.Text;
                    dodadiOdgovor(odgovor);
                }
                if (txtOdgovor6.Text.Length > 0)
                {
                    string odgovor = txtOdgovor6.Text;
                    dodadiOdgovor(odgovor);
                }
            }
            popolni();

        }

        private void popolni()
        {
            string imeOdgovor;
            int prasanjeID = getIdPrasanje();
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            string sqlString = "SELECT * FROM Odgovori where prasanje_ID='" + prasanjeID + "'";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Korisnik");

                html = html + "<div class='col-md-6'><div class='panel panel-primary><div class='panel-heading'><h3 class='panel-title'><span class='glyphicon glyphicon-hand-right'></span>" + txtPrasanje.Text + "</h3></div> <div class='panel-body'><ul class='list-group'>";
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {

                        imeOdgovor = row["ime_odgovor"].ToString();


                        html = html + "<li class='list-group-item'> <div class='checkbox'><label><input type='checkbox' value=''>" + imeOdgovor + " </label></div></li>";


                    }
                }
                html = html + "</ul></div><div class='panel-footer text-center'><button type='button' class='btn btn-primary btn-block btn-sm'>Гласај</button><a href='#' class='small'>View Result</a></div></div></div>";
                ViewState["dataset"] = ds;
                placePrasanja.Controls.Add(new LiteralControl(html));
            }
            catch (Exception err)
            {

            }
            finally
            {
                konekcija.Close();
            }
        }

        private void dodadiOdgovor(string odgovor)
        {
            int prasanje = getIdPrasanje();

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "INSERT INTO Odgovori (prasanje_ID,ime_odgovor)" +
                "VALUES(@prasanje_ID,@ime_odgovor) ";
            komanda.Parameters.AddWithValue("@prasanje_ID", prasanje);
            komanda.Parameters.AddWithValue("@ime_odgovor", odgovor);


            try
            {
                konekcija.Open();
                komanda.ExecuteNonQuery();


            }
            catch (Exception err)
            {

                //      lblError.Text = err.Message;
            }
            finally
            {

                konekcija.Close();
            }
        }


    }
}