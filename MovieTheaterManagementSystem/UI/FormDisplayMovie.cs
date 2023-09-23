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
    public partial class FormDisplayMovie : Form
    {
        List<string> listMovieName = new List<string>();
        List<int> listMovieID = new List<int>();

        SqlConnection con = new SqlConnection(Properties.Settings.Default.MovieTheaterManagementConnectionString);
        SqlCommand cmd;

        public FormDisplayMovie()
        {
            InitializeComponent();
        }

        private void FormBuyTicket_Load(object sender, EventArgs e)
        {
          
        }


        private void lblBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMainPage fmp = new FormMainPage($"ようこそ： {SharedInfo.u_name}様");
            fmp.Show();
        }

        private void loadMovieOnAir()
        {
            con.Open();
            string strSQL = "select movie_id, movie_name, poster_url from movie where datediff(day, release_date, @chosen_date) <= 30 and datediff(day, release_date, @chosen_date) >= 0;"; //確認所選的日期晚於上映日
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@chosen_date", dtpMovieOnAir.Value);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read() == true)
            {
                listMovieID.Add((int)reader["movie_id"]);
                listMovieName.Add((string)reader["movie_name"]);
                string poster_url = (string)reader["poster_url"];
                string dirFile = SharedInfo.dirname + poster_url;
                Image imgMovie = Image.FromFile(dirFile);
                imageListMoviePoster.Images.Add(imgMovie);
            }
            reader.Close();
            con.Close();
        }


        private void search_Click(object sender, EventArgs e)
        {
            listMovieID.Clear();
            listMovieName.Clear();
            listViewMovieOnAir.Clear();
            imageListMoviePoster.Images.Clear();
            loadMovieOnAir();
            listViewMovieOnAir.View = View.LargeIcon;
            imageListMoviePoster.ImageSize = new Size(200, 230);
            listViewMovieOnAir.LargeImageList = imageListMoviePoster;

            for (int i = 0; i < imageListMoviePoster.Images.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = i;
                item.Text = $"{listMovieName[i]}";
                item.Font = new Font("微軟正黑體", 14, FontStyle.Regular);
                item.ForeColor = Color.Aqua;
                item.Tag = listMovieID[i];
                listViewMovieOnAir.Items.Add(item);
            }
        }

        // 電影海報被點擊時觸發
        private void listViewMovieOnAir_ItemActivate(object sender, EventArgs e)
        {
            int selectedMovieID = (int)listViewMovieOnAir.SelectedItems[0].Tag;
            con.Open();
            string strSQL = $"select movie_name from movie where movie_id = {selectedMovieID};";
            cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() == true)
            {
                SharedInfo.m_name = reader["movie_name"].ToString(); //將使用者所選的電影名稱存入全域變數
                //Console.WriteLine(SharedInfo.m_name);
            }
            reader.Close();
            con.Close();
            FormBuyTicket fbt = new FormBuyTicket(selectedMovieID, dtpMovieOnAir.Value);
            fbt.Show();
            this.Hide();
        }
    }
}