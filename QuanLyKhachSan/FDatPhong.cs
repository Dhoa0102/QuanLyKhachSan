using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class FDatPhong : Form
    {
        private string connectionStr = @"Data Source=LEHUNG\THAIHUNG;Initial Catalog=QuanLyKhachSan_Fix;Integrated Security=True";
        public FDatPhong()
        {
            InitializeComponent();
            LoadPhong();
            LoadKhachHang();
        }
        public void LoadPhong()
        {
            dtgv_PhongDat.DataSource = DataProvider.Instance.ExecuteQuery("Select * from View_PhongTrong");
        }
        public void LoadKhachHang()
        {
            dgvKhachHang.DataSource = DataProvider.Instance.ExecuteQuery("Select * from KhachHang");
        }
        private void FDatPhong_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages[2].Text = "Thanh toán";
            loadF();
        }
        private void loadF()
        {
            dgvDichVu.DataSource = DataProvider.Instance.ExecuteQuery("EXEC USP_GetDICHVU");
            dgvKhachHang.DataSource = DataProvider.Instance.ExecuteQuery("EXEC USP_GetKhachHang");
            dgvDonDatDichVu.DataSource = DataProvider.Instance.ExecuteQuery("EXEC USP_GetDonDatDichVuChuaThanhToan");
            dgvDichVuDon.DataSource = DataProvider.Instance.ExecuteQuery("EXEC USP_GetDonDatDichVuChuaThanhToan");
            dgvDatPhongDon.DataSource = DataProvider.Instance.ExecuteQuery("EXEC USP_GetDonDatPhongChuaThanhToan");
            dgvHoaDon.DataSource = DataProvider.Instance.ExecuteQuery("EXEC USP_GetHoaDon");
        }
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra xem đã click vào một dòng hợp lệ chưa
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                // Đổ dữ liệu từ DataGridView vào các TextBox
                txtMaKhachHang.Text = row.Cells["MaKhachHang"].Value.ToString();
            }
        }
        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra xem đã click vào một dòng hợp lệ chưa
            {
                DataGridViewRow row = dgvDichVu.Rows[e.RowIndex];
                // Đổ dữ liệu từ DataGridView vào các TextBox
                txtMaDichVu.Text = row.Cells["MaDichVu"].Value.ToString();
                txtDichVu.Text = row.Cells["TenDichVu"].Value.ToString();
            }
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
        private void dtgv_DichVuDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra xem đã click vào một dòng hợp lệ chưa
            {
                DataGridViewRow row = dgvDichVuDon.Rows[e.RowIndex];

                // Đổ dữ liệu từ DataGridView vào các TextBox
                txtMaDatDV.Text = row.Cells["MaDatDV"].Value.ToString();
            }
        }
        private void dtgv_DatPhongDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra xem đã click vào một dòng hợp lệ chưa
            {
                DataGridViewRow row = dgvDatPhongDon.Rows[e.RowIndex];

                // Đổ dữ liệu từ DataGridView vào các TextBox
                txtMaDatPhong.Text = row.Cells["MaDatPhong"].Value.ToString();
                txbmaphong.Text= row.Cells["MaPhong"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //khi thực hiện đặt phòng nó sẽ tạo thông tin cho khách hàng , nếu khách hàng đã có trong db thì k cần thêm thông tin khách hàng 
            //mà chỉ thực hiện đặt phòng thông qua PROC USP_DatPhong 
            //USP_DatPhong lay ma khach hang thong qua CCCD cua ho
            string query = string.Format("BEGIN TRANSACTION; " +
       "DECLARE @ExistingCustomer INT; " + // Add space after INT
       "SELECT @ExistingCustomer = MaKhachHang " + // Add space after MaKhachHang
       "FROM KhachHang " + // Add space after KhachHang
       "WHERE CCCD = '{2}'; " + // Add space after '{2}'
       "IF @ExistingCustomer IS NULL " + // Add space after NULL
       "BEGIN " + // Add space after BEGIN
       "INSERT INTO KhachHang VALUES ('{0}', '{1}', '{2}'); " + // Add space after VALUES and between single quotes
       "END " + // Add space after END
       "EXEC USP_DatPhong '{2}', '{3}', '{4}', '{5}', '{6}'; " + // Add space after EXEC and between parameters
       "COMMIT TRANSACTION;", txbNameCustomer.Text, txbSDT.Text, txbCCCD.Text, txtMaPhong.Text, dtpNgayDat.Value.ToString(), dtpNgayCheckIn.Value.ToString(), dtpNgayCheckOut.Value.ToString());
            // Create connection
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                // Create command
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    // Open connection
                    connection.Open();

                    // Execute command
                    command.ExecuteNonQuery();

                    MessageBox.Show("Success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            LoadKhachHang();
        }

        private void btnDatDichVu_Click(object sender, EventArgs e)
        {
            string query = string.Format("USP_InsertDonDatDichVu '{0}', '{1}', '{2}' ,'{3}';",txtMaDatDichVu.Text,dtpTimeDatDichVu.Value.ToString(), txtMaDichVu.Text,txtMaKhachHang.Text);
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                // Create command
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    // Open connection
                    connection.Open();

                    // Execute command
                    command.ExecuteNonQuery();

                    MessageBox.Show("Success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            loadF();
        }

        private void dgvDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            int tongtiendichvu =0 ;
            int tongtienphong = 0;
            int tongtien = 0;
            if (!string.IsNullOrWhiteSpace(txtMaDatDV.Text))
            {
                try
                {
                    string query = string.Format("SELECT dbo.GetTotalGiaDichVu('{0}')", txtMaDatDV.Text);
                    object result = DataProvider.Instance.ExecuteScalar(query);
                    if (result != null && result != DBNull.Value)
                    {
                        tongtiendichvu = Convert.ToInt32(result);
                    }
                    else
                    {
   
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);        
                }
            }
            if (!string.IsNullOrWhiteSpace(txtMaDatPhong.Text))
            {
                try
                {
                    string query = string.Format("SELECT dbo.GetDonGiaFromPhong('{0}')", txbmaphong.Text);
                    object result = DataProvider.Instance.ExecuteScalar(query);
                    if (result != null && result != DBNull.Value)
                    {
                        tongtienphong = Convert.ToInt32(result);
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           tongtien = tongtiendichvu + tongtienphong;
           txtTongGiaTien.Text = tongtien.ToString();           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = string.Format("USP_InsertHoaDon '{0}', '{1}', '{2}' ,'{3}' ,'{4}';", txtMaNhanVienThanhToan.Text, txtMaDatPhong.Text, txtMaDatDV.Text, txtTongGiaTien.Text, dtpNgayThanhToan.Value.ToString());
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                // Create command
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    // Open connection
                    connection.Open();

                    // Execute command
                    command.ExecuteNonQuery();

                    MessageBox.Show("Success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            loadF();
        }
    }
}
