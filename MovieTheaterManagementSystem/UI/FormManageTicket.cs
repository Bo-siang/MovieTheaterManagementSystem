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
    public partial class FormManageTicket : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.MovieTheaterManagementConnectionString);
        SqlCommand cmd;
        int tID; //電影訂票編號
        string seat; //需要更新的位置狀態(改為False)


        public FormManageTicket()
        {
            InitializeComponent();
        }

        private void FormManageTicket_Load(object sender, EventArgs e)
        {

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

        private void lblBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMainPage fmp = new FormMainPage($"ようこそ： {SharedInfo.u_name}様");
            fmp.Show();
        }


        //tabPage2
        private void rankingSearch_Click(object sender, EventArgs e)
        {
            con.Open();
            string strSQL = $"select m.movie_name as 映画, sum(t.total_price) as 興行収入 " +
                $"from ticket as t inner join schedule as s on t.schedule_id = s.schedule_id inner join movie as m on s.movie_id = m.movie_id " +
                $"where t.order_datetime >= '{dtpStart.Value.ToString("yyyy-MM-dd HH:mm:dd.hh")}' and t.order_datetime <= '{dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:dd.hh")}' " +
                $"group by m.movie_name; ";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvBoxOffice.DataSource = dt;
            con.Close();
        }

        // tabPage2------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void searchOrder()
        {
            con.Open();
            string strSQL = $"select t.ticket_id as チケットID, u.user_name as 名前, m.movie_name as 映画, s.hall_id as ホール, s.showing_time as 演出時間, t.seat as 座席, t.adult_num as 大人, t.elder_num as お年寄り, t.child_num as 子供, t.student_num as 学生, t.total_price as 合計金額, t.order_datetime as 注文時間 " +
                $"from ticket as t join [user] as u on t.user_id = u.user_id join schedule as s on s.schedule_id = t.schedule_id join movie as m on s.movie_id = m.movie_id " +
                $"where u.email = '{txtEmail.Text.ToString()}';";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvTicket.DataSource = dt;
            con.Close();
        }

        private void ticketSearch_Click(object sender, EventArgs e)
        {
            searchOrder();
        }

        private void dgvTicket_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Int32.TryParse(dgvTicket.Rows[e.RowIndex].Cells[0].Value.ToString(), out tID);
                seat = dgvTicket.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }

        void updateSeatStatus()
        {
            List<string> seatToBeUpdated = new List<string>();
            
            if (seat.Contains(',') == true)
            {
                seatToBeUpdated = seat.Split(',').ToList();
            }
            else
            {
                seatToBeUpdated.Add(seat);
            }
            con.Open();
            int cnt = 0;
            foreach (string seat in seatToBeUpdated)
            {
                if (seat != "")
                {
                    string strSQL = $"update seat_status set {seat} = 0;";
                    cmd = new SqlCommand(strSQL, con);
                    cmd.ExecuteNonQuery();
                    cnt++;
                }
            }
            Console.WriteLine(cnt);
            con.Close();
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            if (tID != 0)
            {
                DialogResult r = MessageBox.Show($"チケット(ID{tID})を払戻しします。よろしいでしょうか?", "ご確認のお願い", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    con.Open();
                    string strSQL = $"delete from ticket where ticket_id = {tID}";
                    cmd = new SqlCommand(strSQL, con);
                    int rows = cmd.ExecuteNonQuery();
                    con.Close();

                    updateSeatStatus(); //退完票進行座位狀態更新
                    MessageBox.Show("お払戻しが完了しました！", "お知らせ");
                    searchOrder();
                }
            }
        }
    }
}