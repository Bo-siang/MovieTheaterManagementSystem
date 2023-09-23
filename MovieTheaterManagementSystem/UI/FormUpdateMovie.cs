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
    public partial class FormUpdateMovie : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.MovieTheaterManagementConnectionString);
        SqlCommand cmd;
        public int selectedID = 0;
        string image_modify_name = "";
        bool edit = false;

        public FormUpdateMovie()
        {
            InitializeComponent();
        }

        private void FormUpdateMovie_Load(object sender, EventArgs e)
        {
            if (selectedID == 0)
            { //新增模式
                groupBoxUpdate.Visible = false;
                groupBoxInsert.Visible = true;
            }
            else
            { //修改模式
                groupBoxUpdate.Visible = true;
                groupBoxInsert.Visible = false;
            }
            lblMID.Text = selectedID.ToString();
            showMovieDetail();
        }

        void showMovieDetail()
        {
            if (selectedID > 0)
            {
                con.Open();
                string strSQL = "select * from movie where movie_id = @ID;";
                cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@ID", selectedID);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read() == true)
                {
                    lblMID.Text = reader["movie_id"].ToString();
                    txtTitle.Text = reader["movie_name"].ToString();
                    txtGenre.Text = reader["type"].ToString();
                    txtDirector.Text = reader["director"].ToString();
                    txtLength.Text = reader["duration"].ToString();
                    txtTrailerURL.Text = reader["trailer_url"].ToString();
                    checkBoxTop3.Checked = Convert.ToBoolean(reader["top3"]);
                    dtpOnAir.Value = Convert.ToDateTime(reader["release_date"]);
                    image_modify_name = reader["poster_url"].ToString();
                    string completePath = SharedInfo.dirname + image_modify_name;
                    pictureBoxPoster.Image = Image.FromFile(completePath);
                }
                reader.Close();
                con.Close();
            }
        }

        void selectPicture()
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "檔案類型 (*.jpg, *.jpeg, *.png)|*.jpeg;*.jpg;*.png";

            DialogResult R = f.ShowDialog();

            if (R == DialogResult.OK)
            {
                pictureBoxPoster.Image = Image.FromFile(f.FileName); //f.FileName完整檔案路徑
                image_modify_name = f.SafeFileName;
                edit = true;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            selectPicture();
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //修改電影資訊
            if ((txtTitle.Text != "") && (txtGenre.Text != "") && (txtDirector.Text != "") && (txtLength.Text != "") && (txtTrailerURL.Text != "") && (pictureBoxPoster.Image != null))
            {
                if (edit == true)
                {
                    pictureBoxPoster.Image.Save(SharedInfo.dirname + image_modify_name);
                    edit = false;
                }
                con.Open();
                string strSQL = "update movie set movie_name = @Name, type = @Genre, director = @Director, duration = @Duration,  poster_url = @PosterURL, trailer_url = @TrailerURL, top3 = @Top3, release_date = @ReleaseDate where movie_id = @MovieID;";
                cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@MovieID", selectedID);
                cmd.Parameters.AddWithValue("@Name", txtTitle.Text);
                cmd.Parameters.AddWithValue("@Genre", txtGenre.Text);
                cmd.Parameters.AddWithValue("@Director", txtDirector.Text);
                cmd.Parameters.AddWithValue("@Duration", txtLength.Text);
                cmd.Parameters.AddWithValue("@PosterURL", image_modify_name);
                cmd.Parameters.AddWithValue("@TrailerURL", txtTrailerURL.Text);
                cmd.Parameters.AddWithValue("@Top3", checkBoxTop3.Checked);
                cmd.Parameters.AddWithValue("@ReleaseDate", dtpOnAir.Value);
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show($"更新が完了しました！", "お知らせ");
            }
            else
            {
                MessageBox.Show("全ての項目をご入力ください！", "操作のご説明", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblMID.Text = "";
            txtTitle.Clear();
            txtGenre.Clear();
            txtDirector.Clear();
            txtLength.Clear();
            txtTrailerURL.Clear();
            pictureBoxPoster.Image = null;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if ((txtTitle.Text != "") && (txtGenre.Text != "") && (txtDirector.Text != "") && (txtLength.Text != "") && (txtTrailerURL.Text != "") && (pictureBoxPoster.Image != null))
            {
                if (edit == true)
                {
                    pictureBoxPoster.Image.Save(SharedInfo.dirname + image_modify_name);
                    edit = false;
                }
                con.Open();
                string strSQL = "insert into movie values (@Name, @Genre, @Director, @Duration, @PosterURL, @TrailerURL, @Top3, @ReleaseDate);";
                cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@Name", txtTitle.Text);
                cmd.Parameters.AddWithValue("@Genre", txtGenre.Text);
                cmd.Parameters.AddWithValue("@Director", txtDirector.Text);
                cmd.Parameters.AddWithValue("@Duration", txtLength.Text);
                cmd.Parameters.AddWithValue("@PosterURL", image_modify_name);
                cmd.Parameters.AddWithValue("@TrailerURL", txtTrailerURL.Text);
                cmd.Parameters.AddWithValue("@Top3", checkBoxTop3.Checked);
                cmd.Parameters.AddWithValue("@ReleaseDate", dtpOnAir.Value);
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show($"更新が完了しました！", "お知らせ");
            }
            else
            {
                MessageBox.Show("全ての項目をご入力ください！", "操作のご説明", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void lblBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormManageMovie fmm = new FormManageMovie();
            fmm.Show();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (selectedID > 0)
            {
                con.Open();
                string strSQL = "select * from movie where movie_id = @ID;";
                cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@ID", selectedID);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read() == true)
                {
                    lblMID.Text = reader["movie_id"].ToString();
                    txtTitle.Text = reader["movie_name"].ToString();
                    txtGenre.Text = reader["type"].ToString();
                    txtDirector.Text = reader["director"].ToString();
                    txtLength.Text = reader["duration"].ToString();
                    txtTrailerURL.Text = reader["trailer_url"].ToString();
                    checkBoxTop3.Checked = Convert.ToBoolean(reader["top3"]);
                    dtpOnAir.Value = Convert.ToDateTime(reader["release_date"]);
                    image_modify_name = reader["poster_url"].ToString();
                    string completePath = SharedInfo.dirname + image_modify_name;
                    pictureBoxPoster.Image = Image.FromFile(completePath);
                }
                reader.Close();
                con.Close();
            }
        }
    }
}