using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DTO;
using BUS;
using DevExpress.XtraEditors;

namespace QLST
{
    public partial class DoiMK : Form
    {
        string tenTK; //lấy tên tài khoản cần đổi mật khẩu từ form trước
        public DoiMK()
        {
            InitializeComponent();
        }
        public DoiMK(string id)
        {
            InitializeComponent();
            this.tenTK = id;
        }

        #region Hàm kiểm tra mật khẩu mới và xác nhận mật khẩu mới nhập có giống nhau không
        private bool kTraMatKhauMoi()
        {
            if (txteMatKhauMoi.Text == txteXacNhanMKMoi.Text)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Xử lý button huỷ
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Xử lý button lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (TaiKhoanBUS.kTraTaiKhoan(tenTK, txteMatKhauCu.Text) == 1)
                {
                    if (kTraMatKhauMoi()==true)
                    {
                        if (TaiKhoanBUS.cNhatMatKhau(tenTK, txteXacNhanMKMoi.Text)==true)
                        {
                            XtraMessageBox.Show("Đổi mật khẩu mới thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            XtraMessageBox.Show("Có lỗi phát sinh, đổi mật khẩu thất bại!", "Đổi mật khẩu thất bại!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txteMatKhauCu.Text = "";
                            txteMatKhauMoi.Text = "";
                            txteXacNhanMKMoi.Text = "";
                            txteMatKhauCu.Focus();
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Mật khẩu mới và xác nhận mật khẩu mới không trùng khớp!", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Mật khẩu cũ không đúng!", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Lỗi!");
            }
        }

        private void txteXacNhanMKMoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnLuu_Click(sender, e);
        }
        #endregion
    }
}
