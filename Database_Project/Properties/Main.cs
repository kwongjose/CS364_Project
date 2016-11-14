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
                if(e.ColumnIndex == 1)//check that the TITLE column was clicked
                {
                    System.Console.WriteLine(r.Cells[0].Value.ToString());
                    int MID = int.Parse(r.Cells[0].Value.ToString() );

                    Form info = new InfoForm(MID);
                    info.Show();
                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // load movie data into grid
            loadMovieGrid();
        }

        //loads movie data into dataGridView Data
        private void loadMovieGrid()
        {
            ConnectionClass connect = new ConnectionClass();
            Data.DataSource = connect.loadMovieData();
            connect.close();
            

            //hide certain columns if they exist
            if (Data.Columns.Contains("MID"))
            {
                Data.Columns["MID"].Visible = false;
            }

            if (Data.Columns.Contains("Plot"))
            {
                Data.Columns["Plot"].Visible = false;
            }

            Data.Update();
        }

        /*
         * Calls the DB and repopulates the gridview
         * 
         */ 
        private void reset_view_Click(object sender, EventArgs e)
        {
            loadMovieGrid();
        }
    }
}
