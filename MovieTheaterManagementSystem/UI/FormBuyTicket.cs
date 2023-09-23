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
    public partial class FormBuyTicket : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.MovieTheaterManagementConnectionString);
        SqlCommand cmd;
        int movieID, scheduleID;
        string trailer_url, selectedDate;
        List<int> seatStatus = new List<int>(); // 儲存該場次的位置狀態
        List<Button> seatBtn = new List<Button>(); // 對應seatStatus的索引，以控制按鈕顏色、停用或不停用
        List<String> selectedSeat = new List<string>(); // 用於 1. 確認劃位數是否跟票種輸入框的總和一致、2. 顯示在購票表中的所選座位欄位(以逗號隔開)、3. 更新場次座位狀態表中的座位(1代表被選走了)


        public FormBuyTicket(int movie_id, DateTime selected_date)
        {
            InitializeComponent();
            this.movieID = movie_id;
            this.selectedDate = selected_date.ToString("yyyy-MM-dd");
        }

        private void FormBuyTicket_Load(object sender, EventArgs e)
        {
            setTrailerURL();
            initBrowser(trailer_url);
            setComboShowingTime();
            //foreach (int item in seatStatus)
            //{
            //    Console.WriteLine(item);
            //}
            setButton();
            defaultTextBox();
        }

        // 利用movie_id搜尋預告片檔案位置，並設定給trailer_url變數
        private void setTrailerURL() 
        {
            con.Open();
            string strSQL = $"select trailer_url from movie where movie_id = {movieID};";
            cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read() == true)
            {
                trailer_url = reader["trailer_url"].ToString();
            }
            reader.Close();
            con.Close();
        }

        public async void initBrowser(string url)
        {
            await initiated();
            webView2Trailer.CoreWebView2.Navigate(SharedInfo.dirname + url);
        }

        private async Task initiated()
        {
            await webView2Trailer.EnsureCoreWebView2Async(null);
        }

        //將四種票數皆設為0
        private void defaultTextBox() 
        {
            txtAdults.Text = 0.ToString();
            txtElders.Text = 0.ToString();
            txtChildren.Text = 0.ToString();
            txtStudents.Text = 0.ToString();
        }

        //依據使用者所選的電影(id)、場次時間、hall_id，查出schesule_id，並顯示出此schedule_id的位置狀況(按鈕)
        private void comboBoxShowingTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string strSQL = $"select schedule_id from schedule where movie_id = {movieID} and hall_id = '{comboBoxShowingTime.SelectedItem.ToString().Substring(6, 4)}' and convert(char(16), showing_time, 120) like '{selectedDate} {comboBoxShowingTime.SelectedItem.ToString().Substring(0, 5)}';";
            cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read() == true)
            {
                scheduleID = Convert.ToInt32(reader["schedule_id"]);
                //Console.WriteLine(scheduleID);
            }
            reader.Close();
            con.Close();

            setSeatStatus();
        }

        private void setButton()
        {
            seatBtn.Add(btnA1);
            seatBtn.Add(btnA2);
            seatBtn.Add(btnA3);
            seatBtn.Add(btnA4);
            seatBtn.Add(btnA5);
            seatBtn.Add(btnB1);
            seatBtn.Add(btnB2);
            seatBtn.Add(btnB3);
            seatBtn.Add(btnB4);
            seatBtn.Add(btnB5);
            seatBtn.Add(btnC1);
            seatBtn.Add(btnC2);
            seatBtn.Add(btnC3);
            seatBtn.Add(btnC4);
            seatBtn.Add(btnC5);

            foreach (Button sbtn in seatBtn)
            {
                sbtn.Enabled = false;
                sbtn.Click += sButton_Click;
            }
        }

        private void sButton_Click(object sender, EventArgs e)
        {
            Button sbtn = (Button)sender;
            if (sbtn.BackColor == Color.Green)
            {
                sbtn.BackColor = Color.LawnGreen;
                selectedSeat.Add(sbtn.Text);
            }
            else
            {
                sbtn.BackColor = Color.Green;
                selectedSeat.Remove(sbtn.Text);
            }
            //foreach (string seat in selectedSeat)
            //{
            //    Console.WriteLine(seat);
            //}
        }

        private void setSeatStatus()
        {
            seatStatus.Clear();
            refreshButtonColor();

            con.Open();
            string strSQL = $"select a1, a2, a3, a4, a5, b1, b2, b3, b4, b5, c1, c2, c3, c4, c5 from seat_status where schedule_id = {scheduleID};";
            cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read() == true)
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    seatStatus.Add(Convert.ToInt32(reader[i]));
                }
            }
            reader.Close();
            con.Close();

            int cnt = 0;
            foreach (int seat in seatStatus)
            {
                if (seat == 1)
                {
                    seatBtn[cnt].BackColor = Color.Red;
                    seatBtn[cnt].Enabled = false;
                }
                cnt++;
            }
        }

        private void refreshButtonColor()
        {
            foreach (Button btn in seatBtn)
            {
                btn.BackColor = Color.Green;
                btn.Enabled = true;
            }
        }

        private void setComboShowingTime()
        {
            con.Open();
            string strSQL = $"select convert(varchar(5), showing_time, 108), hall_id from schedule where movie_id = {movieID} and convert(varchar(10), showing_time, 120) like '{selectedDate}';";
            cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read() == true)
            {
                comboBoxShowingTime.Items.Add($"{reader[0].ToString()}/{reader[1].ToString()}");
            }
            reader.Close();
            con.Close();
        }



        private void lblChooseOtherMovie_Click(object sender, EventArgs e)
        {
            webView2Trailer.Dispose();
            FormDisplayMovie fdm = new FormDisplayMovie();
            fdm.Show();
            this.Hide();
        }


        private void txtAdults_KeyPress(object sender, KeyPressEventArgs e) //限制使用者只能輸入10進位數字
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtStudents_KeyPress(object sender, KeyPressEventArgs e) //限制使用者只能輸入10進位數字
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }


        private void txtElders_KeyPress(object sender, KeyPressEventArgs e) //限制使用者只能輸入10進位數字
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtChildren_KeyPress(object sender, KeyPressEventArgs e) //限制使用者只能輸入10進位數字
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //防止使用者刪掉預設值0，導致空值所致的int轉型錯誤
        private void dealWithNull() 
        {
            if (txtAdults.Text == "")
            {
                txtAdults.Text = 0.ToString();
            }
            if (txtChildren.Text == "")
            {
                txtChildren.Text = 0.ToString();
            }
            if (txtElders.Text == "")
            {
                txtElders.Text = 0.ToString();
            }
            if (txtStudents.Text == "")
            {
                txtElders.Text = 0.ToString();
            }
        } 

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (selectedSeat.Count == 0)
            {
                MessageBox.Show("座席をお選びください！", "操作のご説明", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dealWithNull();
            int ticketNum = Convert.ToInt32(txtAdults.Text) + Convert.ToInt32(txtElders.Text) + Convert.ToInt32(txtStudents.Text) + Convert.ToInt32(txtChildren.Text);
            int totalPrice = calculatePrice();
            if (ticketNum == selectedSeat.Count())
            {
                string SeatToDB = "";
                for (int i = 0; i < selectedSeat.Count(); i++)
                {
                    if (i == selectedSeat.Count - 1)
                    {
                        SeatToDB += $"{selectedSeat[i]}";
                    }
                    else
                    {
                        SeatToDB += $"{selectedSeat[i]},";
                    }
                }
                DialogResult r =  MessageBox.Show($"ご購入内容は以下の通りでございます。\n\n注文者：{SharedInfo.u_name} 様\n映画：{SharedInfo.m_name}\n座席：{SeatToDB}\n合計金額：{totalPrice} 円\n\nよろしいでしょうか？", "ご確認のお願い", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (r == DialogResult.Yes)
                {
                    con.Open();
                    string strSQL = $"insert into ticket values ({SharedInfo.id}, {scheduleID}, '{SeatToDB}', {Convert.ToInt32(txtAdults.Text)}, {Convert.ToInt32(txtElders.Text)}, {Convert.ToInt32(txtChildren.Text)}, {Convert.ToInt32(txtStudents.Text)}, {totalPrice}, '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}');";
                    cmd = new SqlCommand(strSQL, con);
                    int rows = cmd.ExecuteNonQuery();
                    Console.WriteLine(rows);
                    con.Close();
                    MessageBox.Show("ご購入いただき、誠にありがとうございます！");
                    updateDBSeatStatus();
                    setSeatStatus();
                    selectedSeat.Clear();
                    defaultTextBox();
                }
            }
            else
            {
                MessageBox.Show("枚数は座席の数と同じではございません！", "操作のご説明", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //電影票訂單送出後更新該場次於資料庫的座位狀態
        private void updateDBSeatStatus() 
        {
            con.Open();
            foreach (string seat in selectedSeat)
            {
                string strSQL = $"update seat_status set {seat} = 1 where schedule_id = {scheduleID} ;";
                cmd = new SqlCommand(strSQL, con);
                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows);
            }
            con.Close();
        }

        private int calculatePrice()
        {
            return Convert.ToInt32(txtAdults.Text) * 1800 + Convert.ToInt32(txtElders.Text) * 1100 + Convert.ToInt32(txtStudents.Text) * 1300 + Convert.ToInt32(txtChildren.Text) * 1000;
        }
    }
}