namespace Database_Project
{
    partial class InfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.descriptionOfMovie = new System.Windows.Forms.TextBox();
            this.titleOfMovie = new System.Windows.Forms.TextBox();
            this.mainActors = new System.Windows.Forms.TextBox();
            this.movieGenre = new System.Windows.Forms.TextBox();
            this.rating = new System.Windows.Forms.TextBox();
            this.streamingService = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.streamingService)).BeginInit();
            this.SuspendLayout();
            // 
            // descriptionOfMovie
            // 
            this.descriptionOfMovie.Location = new System.Drawing.Point(314, 12);
            this.descriptionOfMovie.Multiline = true;
            this.descriptionOfMovie.Name = "descriptionOfMovie";
            this.descriptionOfMovie.ReadOnly = true;
            this.descriptionOfMovie.Size = new System.Drawing.Size(291, 352);
            this.descriptionOfMovie.TabIndex = 0;
            this.descriptionOfMovie.Text = "This textbox will be the description for the movie.";
            // 
            // titleOfMovie
            // 
            this.titleOfMovie.Location = new System.Drawing.Point(34, 78);
            this.titleOfMovie.Multiline = true;
            this.titleOfMovie.Name = "titleOfMovie";
            this.titleOfMovie.ReadOnly = true;
            this.titleOfMovie.Size = new System.Drawing.Size(239, 53);
            this.titleOfMovie.TabIndex = 1;
            this.titleOfMovie.Text = "This textbox will be the title of the movie. ";
            // 
            // mainActors
            // 
            this.mainActors.Location = new System.Drawing.Point(34, 153);
            this.mainActors.Multiline = true;
            this.mainActors.Name = "mainActors";
            this.mainActors.ReadOnly = true;
            this.mainActors.Size = new System.Drawing.Size(239, 51);
            this.mainActors.TabIndex = 2;
            this.mainActors.Text = "This textbox will be the main actors of the movie. ";
            // 
            // movieGenre
            // 
            this.movieGenre.Location = new System.Drawing.Point(34, 229);
            this.movieGenre.Multiline = true;
            this.movieGenre.Name = "movieGenre";
            this.movieGenre.ReadOnly = true;
            this.movieGenre.Size = new System.Drawing.Size(239, 51);
            this.movieGenre.TabIndex = 3;
            this.movieGenre.Text = "This textbox will be the genre of the movie. ";
            // 
            // rating
            // 
            this.rating.Location = new System.Drawing.Point(34, 308);
            this.rating.Multiline = true;
            this.rating.Name = "rating";
            this.rating.ReadOnly = true;
            this.rating.Size = new System.Drawing.Size(239, 56);
            this.rating.TabIndex = 5;
            this.rating.Text = "This textbox will be the rating of the movie. ";
            // 
            // streamingService
            // 
            this.streamingService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.streamingService.Location = new System.Drawing.Point(34, 434);
            this.streamingService.Name = "streamingService";
            this.streamingService.Size = new System.Drawing.Size(571, 150);
            this.streamingService.TabIndex = 6;
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(617, 614);
            this.Controls.Add(this.streamingService);
            this.Controls.Add(this.rating);
            this.Controls.Add(this.movieGenre);
            this.Controls.Add(this.mainActors);
            this.Controls.Add(this.titleOfMovie);
            this.Controls.Add(this.descriptionOfMovie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InfoForm";
            this.Text = "InfoForm";
            this.Load += new System.EventHandler(this.InfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.streamingService)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox descriptionOfMovie;
        private System.Windows.Forms.TextBox titleOfMovie;
        private System.Windows.Forms.TextBox mainActors;
        private System.Windows.Forms.TextBox movieGenre;
        private System.Windows.Forms.TextBox rating;
        private System.Windows.Forms.DataGridView streamingService;
    }
}