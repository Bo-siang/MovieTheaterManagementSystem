using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieTheaterManagementSystem.UI
{
    public partial class FormManageMember : Form
    {
        public FormManageMember()
        {
            InitializeComponent();
        }

        private void FormManageMember_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'movieTheaterManagementDataSet.view_member' 資料表。您可以視需要進行移動或移除。
            this.view_memberTableAdapter.Fill(this.movieTheaterManagementDataSet.view_member);

        }

        private void lblBack_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FormMainPage fmp = new FormMainPage($"ようこそ： {SharedInfo.u_name}様");
            fmp.Show();
        }
    }
}
