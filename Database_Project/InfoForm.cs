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
        public InfoForm()//add Param for passed data
        {
            InitializeComponent();
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
