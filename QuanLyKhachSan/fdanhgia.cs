using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class fdanhgia : Form
    {
        public fdanhgia()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            DataStorage.MaHD = 32;
            string query = string.Format("Insert into DanhGia values ({0},{1},{2})",DataStorage.MaHD,cbbRate.TabIndex,tbDanhGia.Text);
            int result=DataProvider.Instance.ExecuteNonQuery(query);
            if (result > 0)
            {
                MessageBox.Show("Success");
                this.Close();
            }
            else
                MessageBox.Show("Failed");
        }
    }
}
