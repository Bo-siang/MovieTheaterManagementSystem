
namespace MovieTheaterManagementSystem.UI
{
    partial class FormMainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainPage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlMove = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblDatetime = new System.Windows.Forms.Label();
            this.lblgreetings = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblTop1 = new System.Windows.Forms.Label();
            this.lblTop2 = new System.Windows.Forms.Label();
            this.lblTop3 = new System.Windows.Forms.Label();
            this.webView22 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.webView23 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnManageStaff = new System.Windows.Forms.Button();
            this.btnManageMember = new System.Windows.Forms.Button();
            this.btnManageMovie = new System.Windows.Forms.Button();
            this.btnManageTicket = new System.Windows.Forms.Button();
            this.btnBuyTicket = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(7)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.pnlMove);
            this.panel1.Controls.Add(this.btnManageStaff);
            this.panel1.Controls.Add(this.btnManageMember);
            this.panel1.Controls.Add(this.btnManageMovie);
            this.panel1.Controls.Add(this.btnManageTicket);
            this.panel1.Controls.Add(this.btnBuyTicket);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 898);
            this.panel1.TabIndex = 0;
            // 
            // pnlMove
            // 
            this.pnlMove.BackColor = System.Drawing.Color.Aqua;
            this.pnlMove.Location = new System.Drawing.Point(28, 356);
            this.pnlMove.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMove.Name = "pnlMove";
            this.pnlMove.Size = new System.Drawing.Size(13, 46);
            this.pnlMove.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(364, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 125);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Teal;
            this.panel3.Controls.Add(this.btnLogOut);
            this.panel3.Controls.Add(this.lblDatetime);
            this.panel3.Controls.Add(this.lblgreetings);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(356, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1436, 115);
            this.panel3.TabIndex = 1;
            // 
            // lblDatetime
            // 
            this.lblDatetime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDatetime.AutoSize = true;
            this.lblDatetime.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblDatetime.ForeColor = System.Drawing.Color.White;
            this.lblDatetime.Location = new System.Drawing.Point(1181, 75);
            this.lblDatetime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDatetime.Name = "lblDatetime";
            this.lblDatetime.Size = new System.Drawing.Size(92, 25);
            this.lblDatetime.TabIndex = 1;
            this.lblDatetime.Text = "現在時刻";
            // 
            // lblgreetings
            // 
            this.lblgreetings.AutoSize = true;
            this.lblgreetings.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblgreetings.ForeColor = System.Drawing.Color.White;
            this.lblgreetings.Location = new System.Drawing.Point(107, 30);
            this.lblgreetings.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblgreetings.Name = "lblgreetings";
            this.lblgreetings.Size = new System.Drawing.Size(254, 31);
            this.lblgreetings.TabIndex = 0;
            this.lblgreetings.Text = "ようこそ：ユーザー様";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblTop1
            // 
            this.lblTop1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTop1.AutoSize = true;
            this.lblTop1.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTop1.ForeColor = System.Drawing.Color.Gold;
            this.lblTop1.Location = new System.Drawing.Point(451, 144);
            this.lblTop1.Name = "lblTop1";
            this.lblTop1.Size = new System.Drawing.Size(110, 31);
            this.lblTop1.TabIndex = 3;
            this.lblTop1.Text = "ヒット１";
            // 
            // lblTop2
            // 
            this.lblTop2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTop2.AutoSize = true;
            this.lblTop2.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTop2.ForeColor = System.Drawing.Color.Gold;
            this.lblTop2.Location = new System.Drawing.Point(451, 499);
            this.lblTop2.Name = "lblTop2";
            this.lblTop2.Size = new System.Drawing.Size(110, 31);
            this.lblTop2.TabIndex = 6;
            this.lblTop2.Text = "ヒット２";
            // 
            // lblTop3
            // 
            this.lblTop3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTop3.AutoSize = true;
            this.lblTop3.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTop3.ForeColor = System.Drawing.Color.Gold;
            this.lblTop3.Location = new System.Drawing.Point(1083, 300);
            this.lblTop3.Name = "lblTop3";
            this.lblTop3.Size = new System.Drawing.Size(110, 31);
            this.lblTop3.TabIndex = 7;
            this.lblTop3.Text = "ヒット３";
            // 
            // webView22
            // 
            this.webView22.AllowExternalDrop = true;
            this.webView22.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.webView22.CreationProperties = null;
            this.webView22.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView22.Location = new System.Drawing.Point(429, 547);
            this.webView22.Name = "webView22";
            this.webView22.Size = new System.Drawing.Size(615, 285);
            this.webView22.TabIndex = 9;
            this.webView22.ZoomFactor = 1D;
            // 
            // webView23
            // 
            this.webView23.AllowExternalDrop = true;
            this.webView23.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.webView23.CreationProperties = null;
            this.webView23.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView23.Location = new System.Drawing.Point(1073, 356);
            this.webView23.Name = "webView23";
            this.webView23.Size = new System.Drawing.Size(615, 285);
            this.webView23.TabIndex = 10;
            this.webView23.ZoomFactor = 1D;
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(429, 193);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(615, 285);
            this.webView21.TabIndex = 11;
            this.webView21.ZoomFactor = 1D;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogOut.FlatAppearance.BorderSize = 0;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.Image = global::MovieTheaterManagementSystem.Properties.Resources.logout;
            this.btnLogOut.Location = new System.Drawing.Point(1099, 20);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(224, 51);
            this.btnLogOut.TabIndex = 9;
            this.btnLogOut.Text = "  ログアウト";
            this.btnLogOut.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnManageStaff
            // 
            this.btnManageStaff.FlatAppearance.BorderSize = 0;
            this.btnManageStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageStaff.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnManageStaff.ForeColor = System.Drawing.Color.White;
            this.btnManageStaff.Image = global::MovieTheaterManagementSystem.Properties.Resources.user;
            this.btnManageStaff.Location = new System.Drawing.Point(43, 786);
            this.btnManageStaff.Margin = new System.Windows.Forms.Padding(4);
            this.btnManageStaff.Name = "btnManageStaff";
            this.btnManageStaff.Size = new System.Drawing.Size(275, 66);
            this.btnManageStaff.TabIndex = 7;
            this.btnManageStaff.Text = "  スタッフ管理";
            this.btnManageStaff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManageStaff.UseVisualStyleBackColor = true;
            this.btnManageStaff.Click += new System.EventHandler(this.btnManageStaff_Click);
            // 
            // btnManageMember
            // 
            this.btnManageMember.FlatAppearance.BorderSize = 0;
            this.btnManageMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageMember.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnManageMember.ForeColor = System.Drawing.Color.White;
            this.btnManageMember.Image = global::MovieTheaterManagementSystem.Properties.Resources.member;
            this.btnManageMember.Location = new System.Drawing.Point(28, 672);
            this.btnManageMember.Margin = new System.Windows.Forms.Padding(4);
            this.btnManageMember.Name = "btnManageMember";
            this.btnManageMember.Size = new System.Drawing.Size(275, 66);
            this.btnManageMember.TabIndex = 6;
            this.btnManageMember.Text = "  会員管理";
            this.btnManageMember.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManageMember.UseVisualStyleBackColor = true;
            this.btnManageMember.Click += new System.EventHandler(this.btnManageMember_Click);
            // 
            // btnManageMovie
            // 
            this.btnManageMovie.FlatAppearance.BorderSize = 0;
            this.btnManageMovie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageMovie.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnManageMovie.ForeColor = System.Drawing.Color.White;
            this.btnManageMovie.Image = global::MovieTheaterManagementSystem.Properties.Resources.movie;
            this.btnManageMovie.Location = new System.Drawing.Point(28, 559);
            this.btnManageMovie.Margin = new System.Windows.Forms.Padding(4);
            this.btnManageMovie.Name = "btnManageMovie";
            this.btnManageMovie.Size = new System.Drawing.Size(275, 66);
            this.btnManageMovie.TabIndex = 5;
            this.btnManageMovie.Text = "  ムビ管理";
            this.btnManageMovie.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManageMovie.UseVisualStyleBackColor = true;
            this.btnManageMovie.Click += new System.EventHandler(this.btnManageMovie_Click);
            // 
            // btnManageTicket
            // 
            this.btnManageTicket.FlatAppearance.BorderSize = 0;
            this.btnManageTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageTicket.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnManageTicket.ForeColor = System.Drawing.Color.White;
            this.btnManageTicket.Image = global::MovieTheaterManagementSystem.Properties.Resources.profit;
            this.btnManageTicket.Location = new System.Drawing.Point(43, 451);
            this.btnManageTicket.Margin = new System.Windows.Forms.Padding(4);
            this.btnManageTicket.Name = "btnManageTicket";
            this.btnManageTicket.Size = new System.Drawing.Size(275, 66);
            this.btnManageTicket.TabIndex = 4;
            this.btnManageTicket.Text = "  チケット管理";
            this.btnManageTicket.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManageTicket.UseVisualStyleBackColor = true;
            this.btnManageTicket.Click += new System.EventHandler(this.btnManageTicket_Click);
            // 
            // btnBuyTicket
            // 
            this.btnBuyTicket.FlatAppearance.BorderSize = 0;
            this.btnBuyTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuyTicket.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnBuyTicket.ForeColor = System.Drawing.Color.White;
            this.btnBuyTicket.Image = global::MovieTheaterManagementSystem.Properties.Resources.ticket;
            this.btnBuyTicket.Location = new System.Drawing.Point(43, 336);
            this.btnBuyTicket.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuyTicket.Name = "btnBuyTicket";
            this.btnBuyTicket.Size = new System.Drawing.Size(275, 66);
            this.btnBuyTicket.TabIndex = 3;
            this.btnBuyTicket.Text = "  チケット購入";
            this.btnBuyTicket.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuyTicket.UseVisualStyleBackColor = true;
            this.btnBuyTicket.Click += new System.EventHandler(this.btnBuyTicket_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MovieTheaterManagementSystem.Properties.Resources.movie_man;
            this.pictureBox1.Location = new System.Drawing.Point(4, 30);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(329, 226);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // FormMainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1792, 898);
            this.Controls.Add(this.webView21);
            this.Controls.Add(this.webView23);
            this.Controls.Add(this.webView22);
            this.Controls.Add(this.lblTop3);
            this.Controls.Add(this.lblTop2);
            this.Controls.Add(this.lblTop1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMainPage";
            this.Text = "メインページ";
            this.Load += new System.EventHandler(this.FormMainPage_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlMove;
        private System.Windows.Forms.Button btnManageStaff;
        private System.Windows.Forms.Button btnManageMember;
        private System.Windows.Forms.Button btnManageMovie;
        private System.Windows.Forms.Button btnManageTicket;
        private System.Windows.Forms.Button btnBuyTicket;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label lblDatetime;
        private System.Windows.Forms.Label lblgreetings;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblTop1;
        private System.Windows.Forms.Label lblTop2;
        private System.Windows.Forms.Label lblTop3;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView22;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView23;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    }
}