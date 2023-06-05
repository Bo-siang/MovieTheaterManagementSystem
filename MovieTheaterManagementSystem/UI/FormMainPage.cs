using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieTheaterManagementSystem.UI
{
    public partial class FormMainPage : Form
    {
        string top1_url, top2_url, top3_url;

        SqlConnection con = new SqlConnection(Properties.Settings.Default.MovieTheaterManagementConnectionString);
        SqlCommand cmd;

        public FormMainPage(string grettings)
        {
            InitializeComponent();
            lblgreetings.Text = grettings;
        }

        private void FormMainPage_Load(object sender, EventArgs e)
        {
            timer.Start();

            if (SharedInfo.role == "administrator")
            {
                btnBuyTicket.Visible = true;
                btnManageTicket.Visible = true;
                btnManageMovie.Visible = true;
                btnManageMember.Visible = true;
                btnManageStaff.Visible = true;
            }
            else if (SharedInfo.role == "staff")
            {
                btnBuyTicket.Visible = true;
                btnManageTicket.Visible = true;
                btnManageMovie.Visible = true;
                btnManageMember.Visible = true;
                btnManageStaff.Visible = false;
            }
            else
            {
                btnBuyTicket.Visible = true;
                btnManageTicket.Visible = false;
                btnManageMovie.Visible = false;
                btnManageMember.Visible = false;
                btnManageStaff.Visible = false;
            }


            setTop3();
            initBrowser(top1_url, top2_url, top3_url);
        }


        private void movePanel(Control btn)
        {
            pnlMove.Top = btn.Top;
            pnlMove.Height = btn.Height;
        }

        private void setTop3()
        {
            List<string> temp_urls = new List<string>();
            List<string> temp_titles = new List<string>();

            con.Open();
            string strSQL = "select movie_name, trailer_url from movie where top3 = 1;";
            cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read() == true)
            {
                temp_titles.Add(reader["movie_name"].ToString());
                temp_urls.Add(reader["trailer_url"].ToString());
            }
            top1_url = temp_urls[0];
            top2_url = temp_urls[1];
            top3_url = temp_urls[2];
            lblTop1.Text = temp_titles[0];
            lblTop2.Text = temp_titles[1];
            lblTop3.Text = temp_titles[2];

            reader.Close();
            con.Close();
        }

        public async void initBrowser(string top1_url, string top2_url, string top3_url)
        {
            await initiated();
            webView21.CoreWebView2.Navigate(top1_url);
            webView22.CoreWebView2.Navigate(top2_url);
            webView23.CoreWebView2.Navigate(top3_url);
        }

        private async Task initiated()
        {
            await webView21.EnsureCoreWebView2Async(null);
            await webView22.EnsureCoreWebView2Async(null);
            await webView23.EnsureCoreWebView2Async(null);
        }


        private void stopVideo()
        {
            webView21.Dispose();
            webView22.Dispose();
            webView23.Dispose();
        }


        private void btnBuyTicket_Click(object sender, EventArgs e)
        {
            movePanel(btnBuyTicket);
            stopVideo();
            FormDisplayMovie fbt = new FormDisplayMovie();
            this.Hide();
            fbt.Show();
        }

        private void btnManageTicket_Click(object sender, EventArgs e)
        {
            movePanel(btnManageTicket);
            stopVideo();
            FormManageTicket fmt = new FormManageTicket();
            this.Hide();
            fmt.Show();
        }

        private void btnManageMovie_Click(object sender, EventArgs e)
        {
            movePanel(btnManageMovie);
            stopVideo();
            FormManageMovie fmv = new FormManageMovie();
            this.Hide();
            fmv.Show();
        }

        private void btnManageMember_Click(object sender, EventArgs e)
        {
            movePanel(btnManageMember);
            stopVideo();
            FormManageMember fmm = new FormManageMember();
            this.Hide();
            fmm.Show();
        }

        private void btnManageStaff_Click(object sender, EventArgs e)
        {
            movePanel(btnManageStaff);
            stopVideo();
            FormManageStaff fms = new FormManageStaff();
            this.Hide();
            fms.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("ログアウトします。よろしいですか？", "ログアウト確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                timer.Stop();
                stopVideo();
                Close();
                FormLogIn flg = new FormLogIn();
                flg.Show();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblDatetime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}