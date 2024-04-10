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
    public partial class FDatPhong : Form
    {
        public FDatPhong()
        {
            InitializeComponent();
            LoadPhong();
        }
        public void LoadPhong()
        {
            dtgv_PhongDat.DataSource = DataProvider.Instance.ExecuteQuery("Select * from View_PhongTrong");
        }
        private void FDatPhong_Load(object sender, EventArgs e)
        {





        }

        private void dtgv_PhongDat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra xem đã click vào một dòng hợp lệ chưa
            {
                DataGridViewRow row = dtgv_PhongDat.Rows[e.RowIndex];

                // Đổ dữ liệu từ DataGridView vào các TextBox
                txtMaPhong.Text = row.Cells["MaPhong"].Value.ToString();
                txtLoaiPhong.Text = row.Cells["LoaiPhong"].Value.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value.ToString();               
                txtMaKhachSan.Text = row.Cells["MaKhachSan"].Value.ToString();
            }
        }
    }
}
