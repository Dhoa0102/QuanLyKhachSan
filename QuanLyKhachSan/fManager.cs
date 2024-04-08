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
    public partial class fManager : Form
    {
        public fManager()
        {
            InitializeComponent();
            LoadPhong();
        }
        public void LoadPhong()
        {
            dgvPhong.DataSource = DataProvider.Instance.ExecuteQuery("Select * from Phong");
        }
        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            if (cbbLoaiPhong.Text == "" || tbGiaPhong.Text == ""||tbMaPhong.Text=="")
            {
                MessageBox.Show("Da xay ra loi khi them phong\nHay dien day du thong tin");
                return;
            }
            string query = string.Format("exec USP_AddNewRoom {0},N'{1}',{2},{3}", tbMaPhong.Text, cbbLoaiPhong.Text, tbGiaPhong.Text, 1);
            if (DataProvider.Instance.ExecuteNonQuery(query) >0)
            {
                MessageBox.Show("Them phong thanh cong");
                LoadPhong();
            }
            else
            {
                MessageBox.Show(query);
                MessageBox.Show("Da xay ra loi khi them phong");
            }
        }

        private void btnSuaPhong_Click(object sender, EventArgs e)
        {
            if (cbbLoaiPhong.Text == "" || tbGiaPhong.Text == "" || tbMaPhong.Text == ""||cbbTinhTrang.Text=="")
            {
                MessageBox.Show("Da xay ra loi khi them phong\nHay dien day du thong tin");
                return;
            }
            string query = string.Format("exec USP_UpdateRoom {0},N'{1}',{2},{3},{4}", tbMaPhong.Text, cbbLoaiPhong.Text, tbGiaPhong.Text,cbbTinhTrang.Text ,1);
            if (DataProvider.Instance.ExecuteNonQuery(query) > 0)
            {
                MessageBox.Show("Cap nhat phong thanh cong");
                LoadPhong();
            }
            else
            {
                MessageBox.Show(query);
                MessageBox.Show("Da xay ra loi khi cap nhat phong");
            }
        }

        private void btnXoaPhong_Click(object sender, EventArgs e)
        {

        }
    }
}
