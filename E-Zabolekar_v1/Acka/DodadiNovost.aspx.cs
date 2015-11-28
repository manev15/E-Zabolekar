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
    public partial class DodadiNovost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["korisnik"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                ispolniNovosti();
            }
        }
        private void ispolniNovosti()
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            string sqlString = "SELECT top 8 * FROM Novosti order by datum desc ";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();
            string html = "";
            string naslov = "";
            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Termin");

                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        naslov = row["naslov"].ToString();

                        html = html + " <button type='button' class='list-group-item' style='height:30px'><a href='newsAdmin.aspx' style='color:black'><i class='fa fa-chevron-right'></i> " + naslov + "</a></button> ";


                    }
                }

                placeZanovosti.Controls.Add(new LiteralControl(html));

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

        protected void dodadiNovost(object sender, EventArgs e)
        {
            String data = Convert.ToString(DateTime.Today.ToString("dd-MM-yyyy"));
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandText = "INSERT INTO Novosti (naslov,opis,datum)" +
                "VALUES(@naslov,@opis, @datum) ";
            komanda.Parameters.AddWithValue("@naslov", txtNaslov.Text);
            komanda.Parameters.AddWithValue("@opis", txtOpis.Text);

            komanda.Parameters.AddWithValue("@datum", data);




            try
            {
                konekcija.Open();
                komanda.ExecuteNonQuery();


            }
            catch (Exception err)
            {


            }
            finally
            {
                konekcija.Close();
                txtNaslov.Text = "";
                txtOpis.Text = "";
            }
            ispolniNovosti();
        }
    }
}