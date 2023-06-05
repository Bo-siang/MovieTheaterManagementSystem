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
    public partial class FormManageStaff : Form
    {
        public FormManageStaff()
        {
            InitializeComponent();
        }

        private void userBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.userBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.movieTheaterManagementDataSet);

        }

        private void FormManageStaff_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'movieTheaterManagementDataSet.user' 資料表。您可以視需要進行移動或移除。
            this.userTableAdapter.Fill(this.movieTheaterManagementDataSet.user);
            // TODO: 這行程式碼會將資料載入 'movieTheaterManagementDataSet.user' 資料表。您可以視需要進行移動或移除。
            this.userTableAdapter.Fill(this.movieTheaterManagementDataSet.user);
            // TODO: 這行程式碼會將資料載入 'movieTheaterManagementDataSet.user' 資料表。您可以視需要進行移動或移除。
            this.userTableAdapter.Fill(this.movieTheaterManagementDataSet.user);

        }

        private void userBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.userBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.movieTheaterManagementDataSet);

        }

        private void userBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.userBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.movieTheaterManagementDataSet);

        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMainPage fmp = new FormMainPage($"ようこそ： {SharedInfo.u_name}様");
            fmp.Show();
        }
    }
}
