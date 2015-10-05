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
    public partial class ZakaziPregled : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["korisnik"] == null)
            {
                Response.Redirect("zapregled.aspx");

            }
            else
            {
                if (!IsPostBack)
                {
                    ispolniZabolekari();
                }

            }


        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e) 
        {
            string ace= Convert.ToString(Calendar1.SelectedDate);
            string[] ace1= ace.Split(' ');

            datum.Text = ace1[0];
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
                zabolekari.DataSource = ds;
                zabolekari.DataBind();
                zabolekari.DataTextField = "ime_prezime";
                zabolekari.DataValueField = "zabolekar_ID";
                zabolekari.DataBind();

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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string termin = termini.SelectedItem.Text;
            string[] niza = termin.Split(' ');

            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "INSERT INTO Terminn (od, do, datum,zabolekar_ID)" +
                "VALUES(@od, @do, @datum,@zabolekar_ID) ";
            komanda.Parameters.AddWithValue("@od", niza[0]);
            komanda.Parameters.AddWithValue("@do", niza[2]);
            komanda.Parameters.AddWithValue("@datum", datum.Text);
            komanda.Parameters.AddWithValue("@zabolekar_ID",zabolekari.SelectedValue);
           


            try
            {
                konekcija.Open();
                komanda.ExecuteNonQuery();


             

            }
            catch (Exception err)
            {

               lblporaka.Text = err.Message;
            }
            finally
            {
                konekcija.Close();
            }


        }
    }
}