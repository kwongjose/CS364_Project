﻿using System;
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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        /*
         * Sort Movies by Genres
         * 
         */ 
        private void Genres_SelectedIndexChanged(object sender, EventArgs e)
        {
            String Sel_Geners = Genres.Text;
        }
        /*
         * Sort by Streaming Service
         * 
         */ 
        private void Streaming_Service_SelectedIndexChanged(object sender, EventArgs e)
        {
            String SS = Streaming_Service.Text;
        }
        /*
         * Search by Title or Actor
         * 
         */ 
        private void Submit_Click(object sender, EventArgs e)
        {
            String Title_Actor = textBox1.Text;
        }
        /*
         * Opens a window that show info on a movie
         * 
         */ 
        private void Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;//cast the sender to a gridview
            if(e.RowIndex >= 0) //check if the click is valid
            {
                DataGridViewRow r = senderGrid.Rows[e.RowIndex];//get the row that was clicked on
                if(e.ColumnIndex == 0)//check that the TITLE column was clicked
                {

                }
            }
        }
    }
}
