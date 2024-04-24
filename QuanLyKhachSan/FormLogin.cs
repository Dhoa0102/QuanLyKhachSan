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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        public bool canLogin()
        {
            return txtTK.Text.Length > 0 && txtPass.Text.Length > 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!canLogin())
            {
                MessageBox.Show("Vui lòng điền đẩy đủ tài khoản, mật khẩu");
                return;
            }

            if (!User.ConnectByUser(txtTK.Text.Trim(), txtPass.Text.Trim()))
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!");
                return;
            }
            openForm();
        }

        public void openForm()
        {
            string role = User.getRole();
            MessageBox.Show(role);
            if (role.Equals("NHANVIEN"))
            {
                FDatPhong fd = new FDatPhong();
                fd.FormClosed += Fd_FormClosed;
                this.Hide();
                fd.ShowDialog();
                
            }
            else if (role.Equals("ADMIN"))
            {
                fManager fd = new fManager();
                fd.FormClosed += Fd_FormClosed;
                this.Hide();
                fd.ShowDialog();
                
            }
        }

        private void Fd_FormClosed(object sender, FormClosedEventArgs e)
        {
            reset();
            this.Show();
        }

        public void reset()
        {
            txtTK.Text = "";
            txtPass.Text = "";
        }
    }
}
