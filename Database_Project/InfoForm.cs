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
            

            titleOfMovie.Text = mov.Title;
            movieGenre.Text = mov.Genre;
            mainActor.Text = mov.Actors;
            descriptionOfMovie.Text = mov.Plot;
            ratingOfMovie.Text = mov.imdbRating + " " + mov.Rated;
            
            buildServiceTable( con.GetServicesByID(MID) );
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            String title = titleOfMovie.Text;
            String actor = mainActor.Text;
            String genre = movieGenre.Text;
            String rating = ratingOfMovie.Text;
            String description = descriptionOfMovie.Text;
        }
        /*
         * takes a list of string in the form name,url
         * 
         */ 
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
                    
                    dr["Service"] = t.Substring(0, t.IndexOf(","));
                    dr["URL"] = t.Substring(t.IndexOf(","));
                    dt.Rows.Add(dr);

                }
                
            }
            else
            {
                DataRow e = dt.NewRow();
                e["Service"] = "NO OPTIONS";
                e["URL"] = "";
                dt.Rows.Add(e);

              //No streaming optins
            }
            streamingService.DataSource = dt;
            streamingService.Columns["URL"].Visible = false;
            streamingService.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /*
         * method for when a streaming service is clicked
         * 
         */ 
        private void streamingService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
