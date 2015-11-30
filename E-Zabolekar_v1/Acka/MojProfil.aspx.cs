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
    public partial class MojProfil : System.Web.UI.Page
    {
        private string korisnik;
        private string imeprezime;
        private string username;
        private int telefon;
        private string lokacija;
        private string password;

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
                    staroIME.Text = korisnik;

                }
                getProfileInfo();
                Ispolni();

                //   Settings.Controls.Add(new LiteralControl(settings));


            }
        }
        private void Ispolni()
        {
            getProfileInfo();
            string us = "<div class='container-fluid well span6'><div class='row-fluid'><div class='span8'><h3>" + username + "</h3><h6>Name: " + imeprezime + "</h6><h6>Telefon: " + Convert.ToString(telefon) + "</h6><h6>Lokacija: " + lokacija + "</h6></div></div></div>";
            string nov = "<h3>" + imeprezime + "</h3>            <span class='help-block'>" + lokacija + "</span>";
            string accinfo = " <div class='container' style='margin-left:13%; padding-top:10%'><table>   <tr> <td><i class='fa fa-user'style='float:left' > </i><label>Username</label> </td> <td> <span>" + username + "</span> </td> </tr> <tr><td> <i class='fa fa-genderless'  style='float:left'></i> <label>Full Name</label>  </td> <td> <span>" + imeprezime + "</span> </td> </tr> <tr> <td> <i class='fa fa-mobile'></i> <label>Mobile Number</label> </td> <td> <span>" + Convert.ToString(telefon) + "</span> </td> </tr> <tr> <td>   <i class='fa fa-location-arrow' style='float:left'></i>   <label>Address</label>  </td> <td> <span>" + lokacija + "</span> </td> </tr> </table></div>";
            //   string settings = " <div class='container' style='margin-left:18%'><table>   <tr> <td><i class='fa fa-user'style='float:left' > </i><label>Username</label> </td> <td> <span>" + username + "</span> </td> </tr> <tr><td> <i class='fa fa-genderless'  style='float:left'></i> <label>Full Name</label>  </td> <td> <asp:TextBox ID='TextBox1' runat='server' text='"+imeprezime+"'></asp:TextBox>  </td> </tr> <tr> <td> <i class='fa fa-mobile'></i> <label>Mobile Number</label> </td> <td> <span>" + Convert.ToString(telefon) + "</span> </td> </tr> <tr> <td>   <i class='fa fa-location-arrow' style='float:left'></i>   <label>Address</label>  </td> <td> <span>" + lokacija + "</span> </td> </tr> </table></div>";

            userInfo.Controls.Add(new LiteralControl(nov));
            UserInfoemation.Controls.Add(new LiteralControl(us));
            AccountInformation.Controls.Add(new LiteralControl(accinfo));

        }

        private void getProfileInfo()
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            string sqlString = "SELECT * FROM Korisnik where user_name='" + korisnik + "'";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Korisnik");
                imeprezime = ds.Tables[0].Rows[0]["ime_prezime"].ToString();
                username = ds.Tables[0].Rows[0]["user_name"].ToString();
                lokacija = ds.Tables[0].Rows[0]["lokacija"].ToString();
                password = ds.Tables[0].Rows[0]["password"].ToString();
                telefon = Convert.ToInt32(ds.Tables[0].Rows[0]["telefon"].ToString());

                txtStarTelefon.Text = Convert.ToString(telefon);
                txtStaraLokacija.Text = lokacija;

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

        protected void PromeniIme(object sender, EventArgs e)
        {
            string korisnik = (string)Session["korisnik"];
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            string novo = novoIME.Text;
            komanda.CommandText = "UPDATE Korisnik set user_name='" + novoIME.Text + "' where user_name='" + korisnik + "'";







            try
            {
                konekcija.Open();
                komanda.ExecuteNonQuery();
                Session["korisnik"] = novo;


            }
            catch (Exception err)
            {
                lblerror.Text = err.Message;

            }
            finally
            {
                konekcija.Close();
                Response.Redirect("MojProfil.aspx");

            }

            Response.Redirect("MojProfil.aspx");



        }

        protected void promeniPassword(object sender, EventArgs e)
        {
            string korisnik = (string)Session["korisnik"];
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            string sqlString = "SELECT * FROM Korisnik where user_name='" + korisnik + "'";
            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Korisnik");
                imeprezime = ds.Tables[0].Rows[0]["ime_prezime"].ToString();
                username = ds.Tables[0].Rows[0]["user_name"].ToString();
                lokacija = ds.Tables[0].Rows[0]["lokacija"].ToString();
                password = ds.Tables[0].Rows[0]["password"].ToString();
                telefon = Convert.ToInt32(ds.Tables[0].Rows[0]["telefon"].ToString());

                ViewState["dataset"] = ds;
                if (txtStaraLozinka.Text != null)
                {
                    if (txtStaraLozinka.Text == password)
                    {
                        if (txtNovaLozinka.Text != null && txtPotvrdiNova != null)
                        {
                            if (txtNovaLozinka.Text == txtPotvrdiNova.Text)
                            {
                                string smenet = txtNovaLozinka.Text;
                                smeniPassword(smenet);

                            }

                        }


                    }

                }

            }
            catch (Exception err)
            {

            }
            finally
            {
                konekcija.Close();
            }

        }

        private void smeniPassword(string smenet)
        {


            string korisnik = (string)Session["korisnik"];
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;

            komanda.CommandText = "UPDATE Korisnik set password='" + smenet + "' where user_name='" + korisnik + "'";


            try
            {
                konekcija.Open();
                komanda.ExecuteNonQuery();
                Session["korisnik"] = korisnik;


            }
            catch (Exception err)
            {
                lblerror.Text = err.Message;

            }
            finally
            {
                konekcija.Close();
                Response.Redirect("MojProfil.aspx");

            }

            Response.Redirect("MojProfil.aspx");
        }

        protected void PromeniTelefon(object sender, EventArgs e)
        {
            string korisnik = (string)Session["korisnik"];
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            string novo = txtNovTelefon.Text;
            komanda.CommandText = "UPDATE Korisnik set telefon='" + novo + "' where user_name='" + korisnik + "'";


            try
            {
                konekcija.Open();
                komanda.ExecuteNonQuery();


            }
            catch (Exception err)
            {
                lblerror.Text = err.Message;

            }
            finally
            {
                konekcija.Close();
                Response.Redirect("MojProfil.aspx");

            }

            Response.Redirect("MojProfil.aspx");

        }

        protected void PromeniLokacija(object sender, EventArgs e)
        {

            string korisnik = (string)Session["korisnik"];
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            string novo = txtNovaLokacija.Text;
            komanda.CommandText = "UPDATE Korisnik set lokacija='" + novo + "' where user_name='" + korisnik + "'";


            try
            {
                konekcija.Open();
                komanda.ExecuteNonQuery();


            }
            catch (Exception err)
            {
                lblerror.Text = err.Message;

            }
            finally
            {
                konekcija.Close();
                Response.Redirect("MojProfil.aspx");

            }

            Response.Redirect("MojProfil.aspx");

        }
    }
}