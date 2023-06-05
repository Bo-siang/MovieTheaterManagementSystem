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
    public partial class FormManageMovie : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.MovieTheaterManagementConnectionString);
        SqlCommand cmd;
        List<int> movieID = new List<int>();
        List<string> movieName = new List<string>();
        int sID = 0;

        public FormManageMovie()
        {
            InitializeComponent();
        }

        private void FormManageMovie_Load(object sender, EventArgs e)
        {
            //tabPage1
            loadMovies();
            pictureMode();
            //tabPage2
            setcomboBoxTitle();
            setComboBoxHall();
            //新增場次
            comboAddTitle.SelectedIndex = 0;
            comboAddHall.SelectedIndex = 0;
            //更改與刪除場次
            comboTitle.SelectedIndex = 0;
            comboHall.SelectedIndex = 0;

        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMainPage fmp = new FormMainPage($"ようこそ： {SharedInfo.u_name}様");
            fmp.Show();
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            StringFormat StrFormat = new StringFormat();
            //設定文字樣式
            StrFormat.LineAlignment = StringAlignment.Center;//垂直置中
            StrFormat.Alignment = StringAlignment.Center;//水平置中   
            Font New_Font = new System.Drawing.Font("微軟正黑體", 12F);//標籤字體
            SolidBrush Brush_Font = new SolidBrush(Color.White);//標籤字體顏色
            SolidBrush Brush_Tab = new SolidBrush(Color.Black);//標籤預設顏色
            //繪置元件背景
            Bitmap Bitmap_TabControl = new Bitmap(tabControl1.Width, tabControl1.Height);
            Graphics Graphics_TabControl = Graphics.FromImage(Bitmap_TabControl);
            Graphics_TabControl.FillRectangle(new SolidBrush(Color.Black), 0, 0, tabControl1.Width, tabControl1.Height);
            e.Graphics.DrawImage(Bitmap_TabControl, 0, 0, tabControl1.Width, tabControl1.Height);
            //繪製標籤背景
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                //獲取標籤區域
                Rectangle recChild = tabControl1.GetTabRect(i);
                //設定標籤顏色要實現的區域
                e.Graphics.FillRectangle(Brush_Tab, recChild);
                //設定標籤文字&顏色
                e.Graphics.DrawString(tabControl1.TabPages[i].Text, New_Font, Brush_Font, recChild, StrFormat);
            }
            //繪製被選取的標籤背景
            if (e.Index == tabControl1.SelectedIndex)
            {
                Rectangle recChild = tabControl1.GetTabRect(tabControl1.SelectedIndex);
                Brush_Tab = new SolidBrush(Color.Gray);
                e.Graphics.FillRectangle(Brush_Tab, recChild);
                e.Graphics.DrawString(tabControl1.TabPages[tabControl1.SelectedIndex].Text, New_Font, Brush_Font, recChild, StrFormat);
            }
        }

        void loadMovies()
        {
            con.Open();
            string strSQL = "select top 200 * from movie;";
            cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            int count = 0;

            while (reader.Read() == true)
            {
                movieID.Add((int)reader["movie_id"]);
                movieName.Add((string)reader["movie_name"]);
                string image_name = (string)reader["poster_url"];
                string completePath = $"{SharedInfo.dirname}{image_name}";
                Image img = Image.FromFile(completePath);
                imageListMovie.Images.Add(img);
                count += 1;
            }
            reader.Close();
            con.Close();
            Console.WriteLine($"讀取{count}筆資料");
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            FormUpdateMovie fum = new FormUpdateMovie();
            this.Hide();
            fum.Show();
        }

        void pictureMode()
        {
            listViewMovie.Clear();
            listViewMovie.View = View.LargeIcon;//LargeIcon, SmallIcon, List, Tile
            imageListMovie.ImageSize = new Size(200, 230);
            listViewMovie.LargeImageList = imageListMovie; //LargeIcon, Tile

            for (int i = 0; i < imageListMovie.Images.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = i;
                item.Text = $"{movieName[i]}";
                item.Font = new Font("微軟正黑體", 14, FontStyle.Regular);
                item.ForeColor = Color.Aqua;
                item.Tag = movieID[i];
                listViewMovie.Items.Add(item);
            }
        }

        private void btnPicShow_Click(object sender, EventArgs e)
        {
            pictureMode();
        }

        void listMode()
        {
            listViewMovie.Clear();
            listViewMovie.LargeImageList = null;
            listViewMovie.SmallImageList = null;
            listViewMovie.View = View.Details;
            listViewMovie.Columns.Add("映画ID", 100);
            listViewMovie.Columns.Add("題名", 200);
            listViewMovie.GridLines = true;
            listViewMovie.FullRowSelect = true;

            for (int i = 0; i < movieID.Count; i += 1)
            {
                ListViewItem item = new ListViewItem();
                item.Font = new Font("微軟正黑體", 12, FontStyle.Regular);
                item.Text = movieID[i].ToString();
                item.SubItems.Add(movieName[i]);
                item.Tag = movieID[i];
                item.ForeColor = Color.Aqua;
                item.BackColor = Color.Black;
                listViewMovie.Items.Add(item);
            }
        }

        private void btnListShow_Click(object sender, EventArgs e)
        {
            listMode();
        }

        void reloadData()
        {
            movieID.Clear();
            movieName.Clear();
            imageListMovie.Images.Clear();
            loadMovies();

            if (listViewMovie.View == View.Details)
            {
                listMode();
            }
            else
            {
                pictureMode();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            reloadData();
        }


        private void listViewMovie_ItemActivate(object sender, EventArgs e)
        {
            FormUpdateMovie fum = new FormUpdateMovie();
            fum.selectedID = (int)listViewMovie.SelectedItems[0].Tag;
            this.Hide();
            fum.Show();
        }

        //tabPage2---------------------------------------------------------------------------------------------------------------

        void setcomboBoxTitle()
        {
            con.Open();
            string strSQL = "select movie_id, movie_name from movie;";
            cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read() == true)
            {
                comboAddTitle.Items.Add($"{reader["movie_id"]}/{reader["movie_name"]}");
                comboTitle.Items.Add($"{reader["movie_id"]}/{reader["movie_name"]}");
            }
            reader.Close();
            con.Close();
        }

        void setComboBoxHall()
        {
            con.Open();
            string strSQL = "select hall_id from hall;";
            cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read() == true)
            {
                comboAddHall.Items.Add(reader["hall_id"].ToString());
                comboHall.Items.Add(reader["hall_id"].ToString());
            }
            reader.Close();
            con.Close();
        }

        //加入新的場次
        private void btnInsert_Click(object sender, EventArgs e)
        {
            string selectedMovie = comboAddTitle.SelectedItem.ToString();
            int slashIdx = selectedMovie.IndexOf("/");
            int mID = Convert.ToInt32(selectedMovie.Substring(0, selectedMovie.Length - (selectedMovie.Length - slashIdx)));
            int sID = 0;
            con.Open();
            string strSQL = $"insert into schedule values ({mID}, '{comboAddHall.SelectedItem.ToString()}', '{dtpAddShowingTime.Value.ToString("yyyy-MM-dd HH:mm:ss")}')";
            cmd = new SqlCommand(strSQL, con);
            cmd.ExecuteNonQuery();
            // 查詢剛加入的場次ID
            strSQL = $"select schedule_id from schedule where movie_id = {mID} and hall_id = '{comboAddHall.SelectedItem.ToString()}' and showing_time = '{dtpAddShowingTime.Value.ToString("yyyy-MM-dd HH:mm:ss")}';";
            cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() == true)
            {
                sID = Convert.ToInt32(reader[0]);
            }
            reader.Close();
            //加入該場次對應的座位狀態
            strSQL = $"insert into seat_status values ({sID}, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);";
            cmd = new SqlCommand(strSQL, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("追加が完了しました！", "お知らせ");
        }



        void LoadDataGridView()
        {
            string selectedMovie = comboTitle.SelectedItem.ToString();
            int slashIdx = selectedMovie.IndexOf("/");
            int mID = Convert.ToInt32(selectedMovie.Substring(0, selectedMovie.Length - (selectedMovie.Length - slashIdx)));
            string selectedHall = comboHall.SelectedItem.ToString();
            con.Open();
            
            string strSQL = $"select s.schedule_id as スゲージュルID, m.movie_name as 映画, s.hall_id as ホール, s.showing_time as 演出時間 " +
                $"from schedule as s inner join movie as m on s.movie_id = m.movie_id " +
                $"where m.movie_id = {mID} and s.hall_id = '{selectedHall}' and convert(varchar(10), showing_time, 120) like '{dtpShowingTime.Value.ToString("yyyy-MM-dd")}';";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvSchedule.DataSource = dt;
            con.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void dgvSchedule_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Int32.TryParse(dgvSchedule.Rows[e.RowIndex].Cells[0].Value.ToString(), out sID);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show($"スゲージュル(ID{sID})を削除します。よろしいでしょうか？", "ご確認のお願い", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                con.Open();
                string strSQL = "delete from schedule where schedule_id = @ScheduleID";
                cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@ScheduleID", sID);
                cmd.ExecuteNonQuery();
                //刪除該場次對應的座位狀態
                strSQL = $"delete from seat_status where schedule_id = {sID};";
                cmd = new SqlCommand(strSQL, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("削除が完了しました！", "お知らせ");
                LoadDataGridView();
            }
        }
    }
}