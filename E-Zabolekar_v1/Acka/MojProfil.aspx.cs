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
                getProfileInfo();

                string us = "<div class='container-fluid well span6'><div class='row-fluid'><div class='span8'><h3>" + username + "</h3><h6>Name: " + imeprezime + "</h6><h6>Telefon: " + Convert.ToString(telefon) + "</h6><h6>Lokacija: " + lokacija + "</h6></div></div></div>";
                string nov = "<h3>" + imeprezime + "</h3>            <span class='help-block'>" + lokacija + "</span>";
                string accinfo = " <div class='container' style='margin-left:18%'><table>   <tr> <td><i class='fa fa-user'style='float:left' > </i><label>Username</label> </td> <td> <span>" + username + "</span> </td> </tr> <tr><td> <i class='fa fa-genderless'  style='float:left'></i> <label>Full Name</label>  </td> <td> <span>" + imeprezime + "</span> </td> </tr> <tr> <td> <i class='fa fa-mobile'></i> <label>Mobile Number</label> </td> <td> <span>" + Convert.ToString(telefon) + "</span> </td> </tr> <tr> <td>   <i class='fa fa-location-arrow' style='float:left'></i>   <label>Address</label>  </td> <td> <span>" + lokacija + "</span> </td> </tr> </table></div>";
                userInfo.Controls.Add(new LiteralControl(nov));
                UserInfoemation.Controls.Add(new LiteralControl(us));
                AccountInformation.Controls.Add(new LiteralControl(accinfo));


            }
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
                telefon = Convert.ToInt32(ds.Tables[0].Rows[0]["telefon"].ToString());

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