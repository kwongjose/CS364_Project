using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project
{
    public partial class InfoForm : Form
    {
        public InfoForm(int MID)//add Param for passed data
        {
            InitializeComponent();
            ConnectionClass con = new ConnectionClass();
            Movie mov = con.GetMovieByID(MID);
            con.close();

            titleOfMovie.Text = mov.Title;
            movieGenre.Text = mov.Genre;
            mainActor.Text = mov.Actors;
            descriptionOfMovie.Text = mov.Plot;
            ratingOfMovie.Text = mov.imdbRating + " " + mov.Rated;

            List<String> services = con.GetServicesByID(MID);
            buildServiceTable(services);
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            String title = titleOfMovie.Text;
            String actor = mainActor.Text;
            String genre = movieGenre.Text;
            String rating = ratingOfMovie.Text;
            String description = descriptionOfMovie.Text;
        }

        private void buildServiceTable(List<String> s)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Service");
            dt.Columns.Add("URL");

            if (s.Count > 0)
            {                               
                foreach(string t in s)
                {
                    DataRow dr = dt.NewRow();

                    string name = t.Substring(0, t.IndexOf(","));
                    string URL = t.Substring(t.IndexOf(",") );
                    dr["Service"] = name;
                    dr["URL"] = URL;
                    dt.Rows.Add(dr);

                }
                streamingService.DataSource = dt;
                streamingService.Columns["URL"].Visible = false;
                
            }
            else
            {
                DataRow e = dt.NewRow();
                e["Service"] = "NO OPTIONS";
                e["URL"] = "";
                dt.Rows.Add(e);

                streamingService.DataSource = dt;
                streamingService.Columns["URL"].Visible = false;
                //No streaming optins
            }
        }
    }
}
