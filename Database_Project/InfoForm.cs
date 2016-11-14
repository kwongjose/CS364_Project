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
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            String title = titleOfMovie.Text;
            String actor = mainActor.Text;
            String genre = movieGenre.Text;
            String rating = ratingOfMovie.Text;
            String description = descriptionOfMovie.Text;
        }
    }
}
