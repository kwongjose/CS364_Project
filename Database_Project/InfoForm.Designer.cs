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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoForm));
            this.streamingService = new System.Windows.Forms.DataGridView();
            this.movieTitle = new System.Windows.Forms.Label();
            this.genreLabel = new System.Windows.Forms.Label();
            this.ratingsLabel = new System.Windows.Forms.Label();
            this.descriptionOfMovie = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.focusScapegoat = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.streamingService)).BeginInit();
            this.SuspendLayout();
            // 
            // streamingService
            // 
            this.streamingService.AllowUserToAddRows = false;
            this.streamingService.AllowUserToDeleteRows = false;
            this.streamingService.BackgroundColor = System.Drawing.Color.White;
            this.streamingService.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.streamingService.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.streamingService.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.streamingService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.streamingService.DefaultCellStyle = dataGridViewCellStyle5;
            this.streamingService.GridColor = System.Drawing.Color.White;
            this.streamingService.Location = new System.Drawing.Point(34, 477);
            this.streamingService.Name = "streamingService";
            this.streamingService.ReadOnly = true;
            this.streamingService.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.streamingService.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.streamingService.RowHeadersVisible = false;
            this.streamingService.Size = new System.Drawing.Size(552, 150);
            this.streamingService.TabIndex = 6;
            this.streamingService.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.streamingService_CellContentClick);
            // 
            // movieTitle
            // 
            this.movieTitle.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movieTitle.Location = new System.Drawing.Point(34, 45);
            this.movieTitle.Name = "movieTitle";
            this.movieTitle.Size = new System.Drawing.Size(571, 29);
            this.movieTitle.TabIndex = 8;
            this.movieTitle.Text = "Title";
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genreLabel.Location = new System.Drawing.Point(35, 77);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(48, 19);
            this.genreLabel.TabIndex = 11;
            this.genreLabel.Text = "genre";
            // 
            // ratingsLabel
            // 
            this.ratingsLabel.AutoSize = true;
            this.ratingsLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ratingsLabel.Location = new System.Drawing.Point(35, 102);
            this.ratingsLabel.Name = "ratingsLabel";
            this.ratingsLabel.Size = new System.Drawing.Size(55, 19);
            this.ratingsLabel.TabIndex = 10;
            this.ratingsLabel.Text = "ratings";
            // 
            // descriptionOfMovie
            // 
            this.descriptionOfMovie.BackColor = System.Drawing.Color.White;
            this.descriptionOfMovie.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.descriptionOfMovie.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionOfMovie.Location = new System.Drawing.Point(34, 146);
            this.descriptionOfMovie.Multiline = true;
            this.descriptionOfMovie.Name = "descriptionOfMovie";
            this.descriptionOfMovie.ReadOnly = true;
            this.descriptionOfMovie.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionOfMovie.Size = new System.Drawing.Size(571, 316);
            this.descriptionOfMovie.TabIndex = 12;
            this.descriptionOfMovie.Text = "This textbox will be the description for the movie.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 508);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "No Streaming Services Found";
            this.label1.Visible = false;
            // 
            // focusScapegoat
            // 
            this.focusScapegoat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.focusScapegoat.Location = new System.Drawing.Point(260, 322);
            this.focusScapegoat.Name = "focusScapegoat";
            this.focusScapegoat.Size = new System.Drawing.Size(79, 13);
            this.focusScapegoat.TabIndex = 0;
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(617, 649);
            this.Controls.Add(this.descriptionOfMovie);
            this.Controls.Add(this.genreLabel);
            this.Controls.Add(this.ratingsLabel);
            this.Controls.Add(this.movieTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.streamingService);
            this.Controls.Add(this.focusScapegoat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InfoForm";
            this.Text = "InfoForm";
            this.Load += new System.EventHandler(this.InfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.streamingService)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView streamingService;
        private System.Windows.Forms.Label movieTitle;
        private System.Windows.Forms.Label genreLabel;
        private System.Windows.Forms.Label ratingsLabel;
        private System.Windows.Forms.TextBox descriptionOfMovie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox focusScapegoat;
    }
}