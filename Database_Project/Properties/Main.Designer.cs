namespace Database_Project
{
    partial class Main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Data = new System.Windows.Forms.DataGridView();
            this.Genres = new System.Windows.Forms.ComboBox();
            this.Streaming_Service = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Submit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.reset_view = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Data)).BeginInit();
            this.SuspendLayout();
            // 
            // Data
            // 
            this.Data.AllowUserToAddRows = false;
            this.Data.AllowUserToDeleteRows = false;
            this.Data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Data.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.Data.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Data.DefaultCellStyle = dataGridViewCellStyle2;
            this.Data.Location = new System.Drawing.Point(12, 207);
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.RowHeadersVisible = false;
            this.Data.Size = new System.Drawing.Size(1087, 387);
            this.Data.TabIndex = 0;
            this.Data.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Data_CellContentClick);
            // 
            // Genres
            // 
            this.Genres.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Genres.FormattingEnabled = true;
            this.Genres.Items.AddRange(new object[] {
            "Thriller",
            "Crime",
            "Action",
            "Horror",
            "Romance",
            "Comedy",
            "Animation",
            "War",
            "Biography",
            "Music",
            "Sport",
            "Musical",
            "Western",
            "Sci-Fi",
            "Drama",
            "Mystery",
            "Fantasy",
            "Adventure",
            "Family"});
            this.Genres.Location = new System.Drawing.Point(67, 102);
            this.Genres.Name = "Genres";
            this.Genres.Size = new System.Drawing.Size(121, 26);
            this.Genres.TabIndex = 1;
            this.Genres.Text = "Genres";
            this.Genres.SelectedIndexChanged += new System.EventHandler(this.Genres_SelectedIndexChanged);
            // 
            // Streaming_Service
            // 
            this.Streaming_Service.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Streaming_Service.FormattingEnabled = true;
            this.Streaming_Service.Items.AddRange(new object[] {
            "Hulu",
            "Netflix",
            "Amazon Prime",
            "HBO NOW",
            "STARZ",
            "Showtime"});
            this.Streaming_Service.Location = new System.Drawing.Point(327, 102);
            this.Streaming_Service.Name = "Streaming_Service";
            this.Streaming_Service.Size = new System.Drawing.Size(153, 26);
            this.Streaming_Service.TabIndex = 2;
            this.Streaming_Service.Text = "Streaming Service";
            this.Streaming_Service.SelectedIndexChanged += new System.EventHandler(this.Streaming_Service_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(672, 102);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 3;
            // 
            // Submit
            // 
            this.Submit.BackColor = System.Drawing.Color.White;
            this.Submit.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Submit.Location = new System.Drawing.Point(794, 102);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(81, 26);
            this.Submit.TabIndex = 4;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = false;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(578, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Title or Actor";
            // 
            // reset_view
            // 
            this.reset_view.BackColor = System.Drawing.Color.White;
            this.reset_view.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset_view.Location = new System.Drawing.Point(954, 102);
            this.reset_view.Name = "reset_view";
            this.reset_view.Size = new System.Drawing.Size(80, 27);
            this.reset_view.TabIndex = 6;
            this.reset_view.Text = "Reset";
            this.reset_view.UseVisualStyleBackColor = false;
            this.reset_view.Click += new System.EventHandler(this.reset_view_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(672, 135);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 22);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Actor";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1111, 606);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.reset_view);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Streaming_Service);
            this.Controls.Add(this.Genres);
            this.Controls.Add(this.Data);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Movie DB";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Data;
        private System.Windows.Forms.ComboBox Genres;
        private System.Windows.Forms.ComboBox Streaming_Service;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button reset_view;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

