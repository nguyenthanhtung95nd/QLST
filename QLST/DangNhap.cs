using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Security.Cryptography;
using DTO;
using BUS;
using DevExpress.XtraEditors;

namespace QLST
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        #region Xử lý button thoát.
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult warning = (XtraMessageBox.Show("Bạn thật sự muốn thoát chương trình?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning));
            if (warning == DialogResult.Yes) 
                Application.Exit();
        }
        #endregion

        #region Xử lý button đăng nhập
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (TaiKhoanBUS.kTraTaiKhoan(txteTenDangNhap.Text, txteMatKhau.Text) == 1)
                {
                    this.Hide();
                    ManHinhChinh moManHinhChinh = new ManHinhChinh(txteTenDangNhap.Text);
                    moManHinhChinh.Show();   
                    moManHinhChinh.hotro();
                }
                else
                {
                    XtraMessageBox.Show("Sai tên tài khoản hoặc mật khẩu.\nVui lòng nhập lại!", "Đăng nhập thất bại!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txteMatKhau.Text = "";
                    txteTenDangNhap.Focus();
                }
            }
            catch
            {
                XtraMessageBox.Show("Không thể kết nối cơ sở dữ liệu.", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txteMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnDangNhap_Click(sender, e);
        }
        #endregion
    }
}
