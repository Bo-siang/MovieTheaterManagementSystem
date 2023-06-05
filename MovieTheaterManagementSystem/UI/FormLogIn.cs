using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MovieTheaterManagementSystem.UI;

namespace MovieTheaterManagementSystem
{
    public partial class FormLogIn : Form
    {
        string logInfo;
        SqlConnection con = new SqlConnection(Properties.Settings.Default.MovieTheaterManagementConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;

        public FormLogIn()
        {
            InitializeComponent();
        }


        private void FormLogIn_Load(object sender, EventArgs e)
        {

        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand($"SELECT * FROM [user] WHERE email = '{txtEmail.Text}' and password = '{txtPassword.Text}';", con);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int i = ds.Tables[0].Rows.Count;
            if (i == 1)
            {
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader["role"].ToString() == "admin")
                {
                    SharedInfo.role = "administrator";
                }
                else if (reader["role"].ToString() == "stf")
                {
                    SharedInfo.role = "staff";
                }
                else
                {
                    SharedInfo.role = "member";
                }
                SharedInfo.id = Convert.ToInt32(reader["user_id"]);
                SharedInfo.u_name = reader["user_name"].ToString();
                logInfo = $"ようこそ： {SharedInfo.u_name}様";
                FormMainPage fmp = new FormMainPage(logInfo);
                fmp.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("電子メールかパスワードをご確認ください！", "操作のご説明", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con.Close();
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormSignUp fsu = new FormSignUp();
            fsu.Show();
        }
    }
}