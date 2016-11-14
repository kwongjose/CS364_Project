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
            this.Data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Data.Location = new System.Drawing.Point(12, 207);
            this.Data.Name = "Data";
            this.Data.Size = new System.Drawing.Size(1198, 387);
            this.Data.TabIndex = 0;
            this.Data.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Data_CellContentClick);
            // 
            // Genres
            // 
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
            this.Genres.Location = new System.Drawing.Point(97, 127);
            this.Genres.Name = "Genres";
            this.Genres.Size = new System.Drawing.Size(121, 21);
            this.Genres.TabIndex = 1;
            this.Genres.Text = "Genres";
            this.Genres.SelectedIndexChanged += new System.EventHandler(this.Genres_SelectedIndexChanged);
            // 
            // Streaming_Service
            // 
            this.Streaming_Service.FormattingEnabled = true;
            this.Streaming_Service.Items.AddRange(new object[] {
            "Hulu",
            "Netflix",
            "Amazon Prime",
            "HBO Now",
            "Starz",
            "ShowTime"});
            this.Streaming_Service.Location = new System.Drawing.Point(460, 126);
            this.Streaming_Service.Name = "Streaming_Service";
            this.Streaming_Service.Size = new System.Drawing.Size(121, 21);
            this.Streaming_Service.TabIndex = 2;
            this.Streaming_Service.Text = "Streaming Service";
            this.Streaming_Service.SelectedIndexChanged += new System.EventHandler(this.Streaming_Service_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(755, 127);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(878, 127);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(75, 23);
            this.Submit.TabIndex = 4;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(682, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Title or Actor";
            // 
            // reset_view
            // 
            this.reset_view.Location = new System.Drawing.Point(995, 126);
            this.reset_view.Name = "reset_view";
            this.reset_view.Size = new System.Drawing.Size(75, 23);
            this.reset_view.TabIndex = 6;
            this.reset_view.Text = "Reset";
            this.reset_view.UseVisualStyleBackColor = true;
            this.reset_view.Click += new System.EventHandler(this.reset_view_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(755, 154);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(51, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Actor";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 606);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.reset_view);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Streaming_Service);
            this.Controls.Add(this.Genres);
            this.Controls.Add(this.Data);
            this.Name = "Main";
            this.Text = "Form1";
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

