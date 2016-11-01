using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DTO;
using DevExpress.XtraEditors;
using BUS;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLST
{
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            LockControl();
            btnSuaKH.Enabled = true;
            btnXoaKH.Enabled = true;
            try
            {
                txtMaKH.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                txtTenKH.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                txtDiaChi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
                txtSDTKH.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }


        void LockControl()
        {
            txtMaKH.Enabled = false;
            txtTenKH.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSDTKH.Enabled = false;

            btnThemKH.Enabled = true;
            btnXoaKH.Enabled = false;
            btnSuaKH.Enabled = false;
            btnLuuKH.Enabled = false;
            btnHuy.Enabled = false;
            btnThoat.Enabled = true;
        }
        void UnLockControl()
        {
            txtMaKH.Enabled = true;
            txtTenKH.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSDTKH.Enabled = true;

            btnThemKH.Enabled = false;
            btnXoaKH.Enabled = false;
            btnSuaKH.Enabled = false;
            btnLuuKH.Enabled = true;
            btnHuy.Enabled = true;
            btnThoat.Enabled = false;
        }
        void ResetTexBox()
        {
            txtMaKH.Text = String.Empty;
            txtTenKH.Text = String.Empty;
            txtDiaChi.Text = String.Empty;
            txtSDTKH.Text = String.Empty;
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ResetTexBox();
            LockControl();
        }

        private void btnTaiDanhSachKH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData_KhachHang();
            LockControl();
            ResetTexBox();
        }

        private bool Them = true;
        private void btnThemKH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Them = true;
            ResetTexBox();
            UnLockControl();
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            LockControl();
            LoadData_KhachHang();
        }
        void LoadData_KhachHang()
        {
            gridControl1.DataSource = KhachHang_BUS.LoadDataKH();
        }

        private void btnXoaMH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult check = XtraMessageBox.Show("Bạn có chắc chắn muốn xoá khách hàng này?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (check == DialogResult.Yes)
            {
                try
                {
                    KhachHang_BUS.XoaKH(txtMaKH.Text);LoadData_KhachHang();
                }
                catch (SqlException ex)
                {

                    XtraMessageBox.Show(ex.Message);
                }

            }
        }

        private void btnSuaMH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Them = false;
            UnLockControl();
            txtMaKH.Enabled = false;
        }

        private void btnLuuMH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string MaKH = txtMaKH.Text;
            string TenKH = txtTenKH.Text;
            string DiaChi = txtDiaChi.Text;
            string SDTKH = txtSDTKH.Text;
            string DiemTL = "";
            KhachHang_DTO kh = new KhachHang_DTO(MaKH, TenKH, DiaChi, SDTKH,DiemTL);
            if (MaKH == "" || TenKH == "" || DiaChi == "" || SDTKH == "")
            {
                XtraMessageBox.Show("Bạn phải nhập đầy đủ thông tin của khách hàng!", "Thông báo");
            }
            else
            {
                if (Them == true)
                {
                    try
                    {
                        KhachHang_BUS.ThemKH(kh);
                        LoadData_KhachHang();
                        XtraMessageBox.Show("Thêm khách hàng thành công!", "Thông báo");
                        LockControl();
                    }
                    catch (SqlException ex)
                    {
                        XtraMessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        KhachHang_BUS.SuaKH(kh);
                        LoadData_KhachHang();
                        XtraMessageBox.Show("Sửa thông tin khách hàng thành công!", "Thông báo!");
                        LockControl();
                    }
                    catch (SqlException ex)
                    {
                        XtraMessageBox.Show(ex.Message);
                    }
                }
            }         
        }

    }
}
