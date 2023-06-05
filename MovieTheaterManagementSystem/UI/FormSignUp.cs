using MovieTheaterManagementSystem.UI;
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

namespace MovieTheaterManagementSystem
{
    public partial class FormSignUp : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.MovieTheaterManagementConnectionString);
        SqlCommand cmd;

        public FormSignUp()
        {
            InitializeComponent();
        }

        private void FormSignUp_Load(object sender, EventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtEmail.Text != "" && txtPassword.Text != "")
            {
                con.Open();
                string strSQL = $"insert into [user] values ('mb', @Name, @Email, @Password, @RegisterDatetime);";
                cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@RegisterDatetime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                cmd.ExecuteNonQuery();

                strSQL = $"select user_id from [user] where email = '{txtEmail.Text}' and password = '{txtPassword.Text}';";
                cmd = new SqlCommand(strSQL, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read() == true)
                {
                    SharedInfo.id = Convert.ToInt32(reader["user_id"]);
                }
                reader.Close();
                con.Close();

                SharedInfo.u_name = txtName.Text;
                SharedInfo.role = "member";
                MessageBox.Show("会員登録いただき、ありがとうございます！", "お知らせ");
                FormMainPage fmp = new FormMainPage($"ようこそ：{SharedInfo.u_name}様");
                this.Hide();
                fmp.Show();
            }
            else
            {
                MessageBox.Show("ご記入の上ご登録ください。", "操作のご説明", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogIn fli = new FormLogIn();
            fli.Show();
        }
    }
}