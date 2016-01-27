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
    public partial class Izvestai : System.Web.UI.Page
    {
        private int br1 = 0, br2 = 0, br3 = 0;
        SqlConnection konekcija = new SqlConnection(WebConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString);
        SqlCommand komanda;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["korisnik"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                ispolniBrojki();
                ispolni();

            }
            zasite.ServerClick += new EventHandler(a1_ServerClick);
            zanovi.ServerClick += new EventHandler(a2_ServerClick);
            zaposledenmesec.ServerClick += new EventHandler(a3_ServerClick);
            zapostari.ServerClick += new EventHandler(a4_ServerClick);

        }

        protected void a1_ServerClick(object sender, EventArgs e)
        {
            ispolniBrojki();
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            string sqlString = "SELECT * FROM GotoviPreglediii";

            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();
            string html = "";

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Kurs");
                string zaza = "";
                string zaza1 = "";
                string zaza2 = "";
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        zaza2 = row["datum"].ToString();

                        zaza = row["naslov"].ToString();
                        zaza1 = row["opispregled"].ToString();


                        html = html + "<div class='list-group'><div class='list-group-item'><div class='row-action-primary'> <i class='fa fa-book'></i></div><div class='row-content'><div class='action-secondary'><i class='mdi-material-info'></i></div><div class='least-content'>" + zaza2 + "</div><h4 class='list-group-item-heading'>" + zaza + "</h4><p class='list-group-item-text'>" + zaza1 + "</p></div> </div><div class='list-group-separator'></div>";
                    }
                }

                //string panel = "<div class='panel panel-primary><div class='panel-heading'><h3 class='panel-title'> Сите курсеви</h3></div><div class='panel-body'>'" + html + "'</div></div>";

                pan.Visible = true;
                pan1.Visible = false;
                pan2.Visible = false;
                pan3.Visible = false;
                sitepreglediPlace.Controls.Add(new LiteralControl(html));

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
        protected void a2_ServerClick(object sender, EventArgs e)
        {
            ispolniBrojki();
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            string sqlString = "SELECT  * FROM GotoviPreglediii";


            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();
            string html = "";

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Kurs");
                string zaz = "";
                string zaza = "";
                string zaza1 = "";
                string zaza2 = "";
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {

                        zaz = row["datum"].ToString();
                        string[] da = zaz.Split('-');
                        int odsega = Convert.ToInt32(DateTime.Now.Day);
                        int mesec = Convert.ToInt32(DateTime.Now.Month);
                        int odbaza = Convert.ToInt32(da[0]);
                        int odbazaMesec = Convert.ToInt32(da[1]);
                        if (mesec - odbazaMesec == 0)
                        {
                            if (Math.Abs(odsega) - Math.Abs(odbaza) <= 7)
                            {
                                zaza2 = row["datum"].ToString();
                                zaza = row["naslov"].ToString();
                                zaza1 = row["opispregled"].ToString();

                                html = html + "<div class='list-group'><div class='list-group-item'><div class='row-action-primary'> <i class='fa fa-book'></i></div><div class='row-content'><div class='action-secondary'><i class='mdi-material-info'></i></div><div class='least-content'>" + zaza2 + "</div><h4 class='list-group-item-heading'>" + zaza + "</h4><p class='list-group-item-text'>" + zaza1 + "</p></div> </div><div class='list-group-separator'></div>";

                            }
                            else
                            {

                            }
                        }
                        else
                        { }
                    }
                }


                pan.Visible = false;
                pan1.Visible = true;
                pan2.Visible = false;
                pan3.Visible = false;


                novipreglediPlace.Controls.Add(new LiteralControl(html));

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
        protected void a3_ServerClick(object sender, EventArgs e)
        {
            ispolniBrojki();
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

            string sqlString = "SELECT  * FROM GotoviPreglediii";



            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();
            string html = "";

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Kurs");

                string zaza1 = "";
                string zaza = "";
                string zaza2 = "";


                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {

                        zaza = row["datum"].ToString();
                        string[] da = zaza.Split('-');
                        int odsega = Convert.ToInt32(DateTime.Now.Month);

                        int odbaza = Convert.ToInt32(da[1]);
                        if (Math.Abs(odsega) - Math.Abs(odbaza) == 0)
                        {
                            zaza2 = row["datum"].ToString();
                            zaza = row["naslov"].ToString();
                            zaza1 = row["opispregled"].ToString();

                            html = html + "<div class='list-group'><div class='list-group-item'><div class='row-action-primary'> <i class='fa fa-book'></i></div><div class='row-content'><div class='action-secondary'><i class='mdi-material-info'></i></div><div class='least-content'>" + zaza2 + "</div><h4 class='list-group-item-heading'>" + zaza + "</h4><p class='list-group-item-text'>" + zaza1 + "</p></div> </div><div class='list-group-separator'></div>";

                        }
                        else
                        {

                        }
                    }
                }


                pan.Visible = false;
                pan1.Visible = false;
                pan2.Visible = true;
                pan3.Visible = false;
                posledenmesecPlace.Controls.Add(new LiteralControl(html));

                ViewState["dataset"] = ds;
            }
            catch (Exception err)
            {
                poraka.Text = err.Message;
            }
            finally
            {
                konekcija.Close();
            }
        }

        protected void a4_ServerClick(object sender, EventArgs e)
        {
            ispolniBrojki();
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;

            string sqlString = "SELECT  * FROM GotoviPreglediii";



            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();
            string html = "";

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Kurs");
                string za = "";
                string zaza1 = "";
                string zaza = "";
                string zaza2 = "";
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        za = row["datum"].ToString();
                        string[] da = za.Split('-');
                        int odsega = Convert.ToInt32(DateTime.Now.Month);

                        int odbaza = Convert.ToInt32(da[1]);

                        int god = Convert.ToInt32(da[2]);
                        if (god < 2016)
                        {
                            zaza2 = row["datum"].ToString();
                            zaza = row["naslov"].ToString();
                            zaza1 = row["opispregled"].ToString();

                            html = html + "<div class='list-group'><div class='list-group-item'><div class='row-action-primary'> <i class='fa fa-book'></i></div><div class='row-content'><div class='action-secondary'><i class='mdi-material-info'></i></div><div class='least-content'>" + zaza2 + "</div><h4 class='list-group-item-heading'>" + zaza + "</h4><p class='list-group-item-text'>" + zaza1 + "</p></div> </div><div class='list-group-separator'></div>";

                        }


                        if (Math.Abs(odsega) - Math.Abs(odbaza) > 1)
                        {
                            zaza2 = row["datum"].ToString();
                            zaza = row["naslov"].ToString();
                            zaza1 = row["opispregled"].ToString();

                            html = html + "<div class='list-group'><div class='list-group-item'><div class='row-action-primary'> <i class='fa fa-book'></i></div><div class='row-content'><div class='action-secondary'><i class='mdi-material-info'></i></div><div class='least-content'>" + zaza2 + "</div><h4 class='list-group-item-heading'>" + zaza + "</h4><p class='list-group-item-text'>" + zaza1 + "</p></div> </div><div class='list-group-separator'></div>";

                        }
                        else
                        {

                        }

                    }
                }

                pan.Visible = false;
                pan1.Visible = false;
                pan2.Visible = false;
                pan3.Visible = true;

                postaripreglediPlace.Controls.Add(new LiteralControl(html));

                ViewState["dataset"] = ds;
            }
            catch (Exception err)
            {
                poraka.Text = err.Message;
            }
            finally
            {
                konekcija.Close();
            }
        }
        private void ispolniBrojki()
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            string sqlString = "SELECT  COUNT(gotov_id)as broj1 FROM GotoviPreglediii";
            string datata = Convert.ToString(DateTime.Now.AddDays(-7));
            string[] sega = Convert.ToString(DateTime.Now).Split(' ');
            string sqlString2 = "SELECT * FROM GotoviPreglediii";
            string sqlString3 = "SELECT * FROM GotoviPreglediii";
            string sqlString1 = "SELECT * FROM GotoviPreglediii";


            SqlCommand komanda = new SqlCommand(sqlString, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            SqlCommand komanda1 = new SqlCommand(sqlString1, konekcija);
            SqlDataAdapter adapter1 = new SqlDataAdapter(komanda1);
            DataSet ds1 = new DataSet();

            SqlCommand komanda2 = new SqlCommand(sqlString2, konekcija);
            SqlDataAdapter adapter2 = new SqlDataAdapter(komanda2);
            DataSet ds2 = new DataSet();

            SqlCommand komanda3 = new SqlCommand(sqlString3, konekcija);
            SqlDataAdapter adapter3 = new SqlDataAdapter(komanda3);
            DataSet ds3 = new DataSet();



            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Kurs");
                adapter1.Fill(ds1, "Kurs1");
                adapter2.Fill(ds2, "Kurs2");
                adapter3.Fill(ds3, "Kurs3");

                string zaza = "";
                foreach (DataTable table in ds2.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {

                        zaza = row["datum"].ToString();
                        string[] da = zaza.Split('-');
                        int odsega = Convert.ToInt32(DateTime.Now.Month);

                        int odbaza = Convert.ToInt32(da[1]);
                        if (Math.Abs(odsega) - Math.Abs(odbaza) == 0)
                        {
                            br2++;
                        }
                        else
                        {

                        }
                    }
                }

                string za = "";
                foreach (DataTable table in ds3.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {

                        za = row["datum"].ToString();
                        string[] da = za.Split('-');
                        int odsega = Convert.ToInt32(DateTime.Now.Month);

                        int odbaza = Convert.ToInt32(da[1]);
                        int god=Convert.ToInt32(da[2]);
                        if (god < 2016)
                        {
                            br3++;
                        }

                        if (Math.Abs(odsega) - Math.Abs(odbaza) > 1)
                        {
                            br3++;
                        }
                        else
                        {

                        }
                    }
                }




                int br = Convert.ToInt32(ds.Tables[0].Rows[0]["broj1"].ToString());

                string zaz = "";
                foreach (DataTable table in ds1.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {

                        zaz = row["datum"].ToString();
                        string[] da = zaz.Split('-');
                        int odsega = Convert.ToInt32(DateTime.Now.Day);
                        int mesec = Convert.ToInt32(DateTime.Now.Month);
                        int odbaza = Convert.ToInt32(da[0]);
                        int odbazaMesec = Convert.ToInt32(da[1]);
                        if (mesec - odbazaMesec == 0)
                        {
                            if (Math.Abs(odsega) - Math.Abs(odbaza) <= 7)
                            {
                                br1++;
                            }
                            else
                            {

                            }
                        }
                        else
                        { }
                    }
                }


                string site = "<div class='huge'>" + br + "</div>";
                string novi = "<div class='huge'>" + br1 + "</div>";
                string posleden = "<div class='huge'>" + br2 + "</div>";
                string postari = "<div class='huge'>" + br3 + "</div>";
                a.Text = Convert.ToString(br1);
                b.Text = Convert.ToString(br2);
                c.Text = Convert.ToString(br3);
                siteKursevi.Controls.Add(new LiteralControl(site));
                noviKursevi.Controls.Add(new LiteralControl(novi));
                posledenMesec.Controls.Add(new LiteralControl(posleden));
                postariKursevi.Controls.Add(new LiteralControl(postari));
                //ViewState["dataset"] = ds;
            }
            catch (Exception err)
            {

            }
            finally
            {
                konekcija.Close();
            }




        }
        private void ispolni()
        {
            konekcija = new SqlConnection();
            konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            string sqlString = "SELECT * FROM Termin";
            komanda = new SqlCommand(sqlString, konekcija);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataSet ds = new DataSet();

            try
            {
                konekcija.Open();
                adapter.Fill(ds, "Korisnici");
                gvZabolekari.DataSource = ds;
                gvZabolekari.DataBind();
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

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //DataSet ds = (DataSet)ViewState["dataset"];

            gvZabolekari.EditIndex = e.NewEditIndex;
            //GridView1.DataSource = ds;
            // GridView1.DataBind();
            ispolni();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // DataSet ds = (DataSet)ViewState["dataset"];
            gvZabolekari.EditIndex = -1;
            // GridView1.DataSource = ds;
            // GridView1.DataBind();
            ispolni();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {


            int index = e.RowIndex;


            GridViewRow row = (GridViewRow)gvZabolekari.Rows[index];
            Label eid = (Label)row.FindControl("lblTermin");
            TextBox txtime = (TextBox)row.FindControl("txtKorisnik");
            TextBox txtopis = (TextBox)row.FindControl("txtZabolekar");
            TextBox txttelefon = (TextBox)row.FindControl("txtOd");
            TextBox txtuser = (TextBox)row.FindControl("txtDo");
            TextBox txtlokacija = (TextBox)row.FindControl("txtDatum");

            //    komanda.commandtext = "update korisnik set lokacija='" + novo + "' where user_name='" + korisnik + "'";
            SqlCommand cmd2 = new SqlCommand("update termin set korisnik_id = '" + txtime.Text + "',zabolekar_id='" + txtopis.Text + "',od='" + txttelefon.Text + "',do='" + txtuser.Text + "',datum='" + txtlokacija.Text + "' where termin_id='" + Convert.ToInt32(eid.Text) + "'", konekcija);
            konekcija.Open();
            int res1 = cmd2.ExecuteNonQuery();
            konekcija.Close();


            gvZabolekari.EditIndex = -1;

            ispolni();



            /*TextBox tb = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].Controls[0];
            komanda.Parameters.AddWithValue("@ime_prezime", tb.Text);
             */
            // komanda.Parameters.AddWithValue("@korisnik_ID",);

            int efekt = 0;
            try
            {
                konekcija.Open();
                efekt = komanda.ExecuteNonQuery();
            }
            catch (Exception err)
            {

            }
            finally
            {
                konekcija.Close();
                gvZabolekari.EditIndex = -1;
            }

            ispolni();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gv1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvZabolekari.EditIndex = -1;

            ispolni();
        }
        protected void gv1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;

            GridViewRow row = (GridViewRow)gvZabolekari.Rows[index];

            Label eid = (Label)row.FindControl("lblTermin");

            SqlCommand cmd = new SqlCommand("delete from termin where termin_id=" + Convert.ToInt32(eid.Text) + "", konekcija);
            konekcija.Open();
            int res = cmd.ExecuteNonQuery();
            konekcija.Close();



            ispolni();
        }
        protected void gv1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvZabolekari.PageIndex = e.NewPageIndex;

            ispolni();
        }
    }
}