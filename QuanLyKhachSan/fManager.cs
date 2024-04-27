using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class fManager : Form
    {

        private string connectionStr = @"";

        public fManager()
        {
            InitializeComponent();
            connectionStr = User.getConnectionString();

            tabControl1.SelectTab(5);
            LoadData();

        }

        public void LoadData()
        {
            dgvKhachHang.DataSource = DataProvider.Instance.ExecuteQuery("Select * from View_KhachHang");
            dgvPhong.DataSource = DataProvider.Instance.ExecuteQuery("Select * from ShowPhong ");
            dgvNhanVien.DataSource = DataProvider.Instance.ExecuteQuery("Select * from NhanVien");
            dgvDichvu.DataSource = DataProvider.Instance.ExecuteQuery("Select * from  View_DICHVU");
            dgv_HoaDon.DataSource = DataProvider.Instance.ExecuteQuery("Select * from View_HoaDon");
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            if (cbbLoaiPhong.Text == "" || tbGiaPhong.Text == "" || tbMaPhong.Text == "")
            {
                MessageBox.Show("Da xay ra loi khi them phong\nHay dien day du thong tin");
                return;
            }
            string query = string.Format("exec USP_AddNewRoom {0},N'{1}',{2},{3}", tbMaPhong.Text, cbbLoaiPhong.Text, tbGiaPhong.Text, 1);
            if (DataProvider.Instance.ExecuteNonQuery(query) > 0)
            {
                MessageBox.Show("Them phong thanh cong");
                LoadData();
            }
            else
            {
                MessageBox.Show(query);
                MessageBox.Show("Da xay ra loi khi them phong");
            }
        }

        private void btnSuaPhong_Click(object sender, EventArgs e)
        {
            if (cbbLoaiPhong.Text == "" || tbGiaPhong.Text == "" || tbMaPhong.Text == "" || cbbTinhTrang.Text == "")
            {
                MessageBox.Show("Da xay ra loi khi them phong\nHay dien day du thong tin");
                return;
            }
            string query = string.Format("exec USP_UpdateRoom {0},N'{1}',{2},N'{3}',{4}", tbMaPhong.Text, cbbLoaiPhong.Text, tbGiaPhong.Text, cbbTinhTrang.Text, 1);
            if (DataProvider.Instance.ExecuteNonQuery(query) > 0)
            {
                MessageBox.Show("Cap nhat phong thanh cong");
                LoadData();
            }
            else
            {
                MessageBox.Show(query);
                MessageBox.Show("Da xay ra loi khi cap nhat phong");
            }
        }

        private void btnXoaPhong_Click(object sender, EventArgs e)
        {
            if (tbMaPhong.Text == "")
            {
                MessageBox.Show("Da xay ra loi khi them phong\nHay dien day du thong tin");
                return;
            }
            string query = string.Format("exec USP_DeleteRoom {0}", tbMaPhong.Text);
            if (DataProvider.Instance.ExecuteNonQuery(query) > 0)
            {
                MessageBox.Show("Xoa phong thanh cong");
                LoadData();
            }
            else
            {
                MessageBox.Show(query);
                MessageBox.Show("Da xay ra loi khi xoa phong");
            }
        }

        private void fManager_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            FDatPhong fPhong = new FDatPhong();
            fPhong.Show();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_ThemDichVu_Click(object sender, EventArgs e)
        {
            string query = string.Format("exec USP_ThemDichVu {0},N'{1}',{2}", txb_maDichvu.Text, txb_tenDichvu.Text, txb_giaDichvu.Text);
            if (DataProvider.Instance.ExecuteNonQuery(query) > 0)
            {
                MessageBox.Show("Them dich vu thanh cong");
                LoadData();
            }
            else
            {
                MessageBox.Show(query);
                MessageBox.Show("Da xay ra loi khi them dich vu");
            }
        }

        private void btn_XoaDichVu_Click(object sender, EventArgs e)
        {
            string query = string.Format("exec USP_XoaDichVu {0}", txb_maDichvu.Text);
            if (DataProvider.Instance.ExecuteNonQuery(query) > 0)
            {
                MessageBox.Show("Xoa dich vu thanh cong");
                LoadData();
            }
            else
            {
                MessageBox.Show(query);
                MessageBox.Show("Da xay ra loi khi xoa dich vu");
            }
        }

        private void btn_SuaDichVu_Click(object sender, EventArgs e)
        {
            string query = string.Format("exec USP_SuaThongTinDichVu {0},N'{1}',{2}", txb_maDichvu.Text, txb_tenDichvu.Text, txb_giaDichvu.Text);
            if (DataProvider.Instance.ExecuteNonQuery(query) > 0)
            {
                MessageBox.Show("Cap nhat dich vu thanh cong");
                LoadData();
            }
            else
            {
                MessageBox.Show(query);
                MessageBox.Show("Da xay ra loi khi cap nhat dich vu");
            }
        }

        private void btn_ThemNhanVien_Click(object sender, EventArgs e)
        {
            string query = string.Format("exec USP_ThemNhanVien {0}, '{1}', N'{2}', N'{3}', '{4}', N'{5}', {6}",
                txb_maNhanvien.Text, txb_sdtNhanvien.Text, txb_tenNhanvien.Text, txb_diachi.Text,
                dtp_ngaythangnamsinhNhanvien.Value.ToString(), cbb_gioiTinh.Text, 1);
            if (DataProvider.Instance.ExecuteNonQuery(query) > 0)
            {
                MessageBox.Show("Them nhan vien thanh cong");
                LoadData();
            }
            else
            {
                MessageBox.Show(query);
                MessageBox.Show("Da xay ra loi khi them nhan vien");
            }
        }

        private void btn_XoaNhanVien_Click(object sender, EventArgs e)
        {
            string query = string.Format("exec USP_XoaNhanVien {0}", txb_maNhanvien.Text);
            if (DataProvider.Instance.ExecuteNonQuery(query) > 0)
            {
                MessageBox.Show("Xoa nhan vien thanh cong");
                LoadData();
            }
            else
            {
                MessageBox.Show(query);
                MessageBox.Show("Da xay ra loi khi xoa nhan vien");
            }
        }

        private void btn_SuaNhanVien_Click(object sender, EventArgs e)
        {
            string query = string.Format("exec USP_SuaThongTinNhanVien {0}, '{1}', N'{2}', N'{3}', '{4}', N'{5}', {6}",
                txb_maNhanvien.Text, txb_sdtNhanvien.Text, txb_tenNhanvien.Text, txb_diachi.Text,
                dtp_ngaythangnamsinhNhanvien.Value.ToString(), cbb_gioiTinh.Text, 1);
            if (DataProvider.Instance.ExecuteNonQuery(query) > 0)
            {
                MessageBox.Show("Cap nhat nhan vien thanh cong");
                LoadData();
            }
            else
            {
                MessageBox.Show(query);
                MessageBox.Show("Da xay ra loi khi cap nhat nhan vien");
            }
        }

        private void btn_DatPhong_Click(object sender, EventArgs e)
        {
            FDatPhong fdatphong = new FDatPhong(Convert.ToInt32(btn_DatPhong.Tag));
            fdatphong.Show();
        }

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            FDatPhong fdatphong = new FDatPhong(Convert.ToInt32(btn_ThanhToan.Tag));
            fdatphong.Show();
        }

        private void btn_DatDIchVu_Click(object sender, EventArgs e)
        {
            FDatPhong fdatphong = new FDatPhong(Convert.ToInt32(btn_ThanhToan.Tag));
            fdatphong.Show();
        }
        private void dgv_HoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable khachHangInfo = TimKiemKhachHang(txb_TenKhachHang.Text, txb_CCCD.Text);

            if (khachHangInfo.Rows.Count > 0)
            {
                dgvKhachHang.DataSource = khachHangInfo;
                txbMaKhachHang.Text = khachHangInfo.Rows[0]["MaKhachHang"].ToString();
            }
            else
            {
                Console.WriteLine("Không tìm thấy thông tin khách hàng.");
            }
            dgvKhachHang.DataSource = khachHangInfo;
        }

        private DataTable TimKiemKhachHang(string hoTen, string cccd)
        {
            string query = "SELECT * FROM TimKiemKhachHang(@HoTen, @CCCD)";

            string connectionString = connectionStr;
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@HoTen", hoTen);
                    command.Parameters.AddWithValue("@CCCD", cccd);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        try
                        {
                            connection.Open();
                            adapter.Fill(dataTable);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }
                }
            }

            return dataTable;
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
            txbMaKhachHang.Text = "";
            txb_tenNhanvien.Text = "";
            txb_CCCD.Text = "";
        }

        private void btnTKPhong_Click(object sender, EventArgs e)
        {

            string query = string.Format("SELECT * FROM TimKiemPhong('{0}')",txb_MaPhong_TK.Text);
            object result = DataProvider.Instance.ExecuteQuery(query);
            if (result == null)
                MessageBox.Show("Khong tim thay thong tin");
            else
            {
                dgvPhong.DataSource = result;
            }
        }

        private DataTable TimKiemPhong(string maphong)
        {
            string query = "SELECT * FROM TimKiemPhong(@MaPhong)";

            string connectionString = connectionStr;
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaPhong", maphong);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        try
                        {
                            connection.Open();
                            adapter.Fill(dataTable);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }
                }
            }

            return dataTable;
        }




        private void button1_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = string.Format("SELECT * FROM TimKiemNhanVien('{0}')", txt_MaNV_TK.Text);
            object result = DataProvider.Instance.ExecuteQuery(query);
            if (result == null)
                MessageBox.Show("Khong tim thay thong tin");
            else
            {
                dgvNhanVien.DataSource = result;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string query = string.Format("select* from TimKiemDichVu('{0}')", txt_TimKiemMaDichVu.Text);
            object result = DataProvider.Instance.ExecuteQuery(query);
            if (result == null)
                MessageBox.Show("Khong tim thay thong tin");
            else
            {
                dgvDichvu.DataSource = result;
            }

        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_LoadDichVu_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string query = string.Format("select* from TimKiemHoaDon('{0}')", txtTKHHOADON.Text);
            object result = DataProvider.Instance.ExecuteQuery(query);
            if (result == null)
                MessageBox.Show("Khong tim thay thong tin");
            else
            {
                dgv_HoaDon.DataSource = result;
            }
        }

        private void radio_TK_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (radioButton != null && radioButton.Checked)
            {
              
                if (radioButton.Name == "radio_TK_DATE") 
                {
                    string query = string.Format("select* from TimKiemHoaDon_NgayThanhToan()");
                    object result = DataProvider.Instance.ExecuteQuery(query);
                    if (result == null)
                        MessageBox.Show("Khong tim thay thong tin");
                    else
                    {
                        dgv_HoaDon.DataSource = result;
                    }

                }
                else if (radioButton.Name == "radioButton2")
                {
                    
                }
             
            }

        }

        public bool isNotNull()
        {
            if (txtTKT.Text.Length <= 0)
                return false;
            if (txtMK.Text.Length <= 0)
                return false;
            if (txtNhapLaiMK.Text.Length <= 0)
                return false;
            return true;
        }

        public bool isSameMK()
        {
            if (txtMK.Text.Trim().Equals(txtNhapLaiMK.Text.Trim()))
                return true;
            return false;
        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            if (!isNotNull())
            {
                MessageBox.Show("Vui lòng không để trống");
                return;
            }
            if (!isSameMK())
            {
                MessageBox.Show("Vui lòng nhập mk ở 2 ô giống nhau");
                return;
            }
            object a = DataProvider.Instance.ExecuteNonQuery(String.Format("exec createUser '{0}', '{1}'", txtTKT.Text.Trim(), txtMK.Text.Trim()));
            if (a!=null)
            {
                MessageBox.Show("Tạo tài khoản nhân viên mới thành công");
            }
        }
    }


}
