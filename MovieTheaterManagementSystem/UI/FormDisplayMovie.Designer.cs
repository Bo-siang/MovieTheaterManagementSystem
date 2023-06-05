
namespace MovieTheaterManagementSystem.UI
{
    partial class FormDisplayMovie
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDisplayMovie));
            this.imageListMoviePoster = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.listViewMovieOnAir = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpMovieOnAir = new System.Windows.Forms.DateTimePicker();
            this.search = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblBack = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageListMoviePoster
            // 
            this.imageListMoviePoster.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListMoviePoster.ImageSize = new System.Drawing.Size(256, 256);
            this.imageListMoviePoster.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = global::MovieTheaterManagementSystem.Properties.Resources.kandou_movie_eigakan;
            this.pictureBox3.Location = new System.Drawing.Point(1087, 188);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(474, 293);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // listViewMovieOnAir
            // 
            this.listViewMovieOnAir.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewMovieOnAir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewMovieOnAir.BackColor = System.Drawing.Color.Black;
            this.listViewMovieOnAir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewMovieOnAir.HideSelection = false;
            this.listViewMovieOnAir.Location = new System.Drawing.Point(69, 188);
            this.listViewMovieOnAir.MultiSelect = false;
            this.listViewMovieOnAir.Name = "listViewMovieOnAir";
            this.listViewMovieOnAir.Size = new System.Drawing.Size(971, 485);
            this.listViewMovieOnAir.TabIndex = 8;
            this.listViewMovieOnAir.UseCompatibleStateImageBehavior = false;
            this.listViewMovieOnAir.ItemActivate += new System.EventHandler(this.listViewMovieOnAir_ItemActivate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.Aqua;
            this.label1.Location = new System.Drawing.Point(63, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "日付を調べる";
            // 
            // dtpMovieOnAir
            // 
            this.dtpMovieOnAir.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpMovieOnAir.Location = new System.Drawing.Point(238, 98);
            this.dtpMovieOnAir.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtpMovieOnAir.Name = "dtpMovieOnAir";
            this.dtpMovieOnAir.Size = new System.Drawing.Size(258, 38);
            this.dtpMovieOnAir.TabIndex = 5;
            // 
            // search
            // 
            this.search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.search.Image = global::MovieTheaterManagementSystem.Properties.Resources.magnifier;
            this.search.Location = new System.Drawing.Point(502, 98);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(55, 38);
            this.search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.search.TabIndex = 7;
            this.search.TabStop = false;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::MovieTheaterManagementSystem.Properties.Resources.cursor;
            this.pictureBox1.Location = new System.Drawing.Point(1404, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 70);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // lblBack
            // 
            this.lblBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBack.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblBack.ForeColor = System.Drawing.Color.RosyBrown;
            this.lblBack.Location = new System.Drawing.Point(1169, 83);
            this.lblBack.Name = "lblBack";
            this.lblBack.Size = new System.Drawing.Size(247, 41);
            this.lblBack.TabIndex = 11;
            this.lblBack.Text = "メインページに戻る";
            this.lblBack.Click += new System.EventHandler(this.lblBack_Click);
            // 
            // FormDisplayMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1582, 753);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblBack);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.listViewMovieOnAir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpMovieOnAir);
            this.Controls.Add(this.search);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDisplayMovie";
            this.Text = "映画検索";
            this.Load += new System.EventHandler(this.FormBuyTicket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageListMoviePoster;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ListView listViewMovieOnAir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpMovieOnAir;
        private System.Windows.Forms.PictureBox search;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label lblBack;
    }
}