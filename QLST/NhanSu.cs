using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS;
using DTO;
using System.Data.SqlClient;
using DevExpress.XtraEditors;

namespace QLST
{
    public partial class NhanSu : Form
    {
        public NhanSu()
        {
            InitializeComponent();
        }
        private void LoadDataNS()
        {
            gridControl1.DataSource = NhanSu_BUS.LoadDataNS();
        }
        private void NhanSu_Load(object sender, EventArgs e)
        {
            LockControl();
            LoadDataNS();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            LockControl();
            btnSua.Enabled = true;
            btnXoaNS.Enabled = true;
            try
            {
                txtMaNS.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                txtHoTenNS.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                txtSDTNS.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
                txtDCNS.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();             
                string chucvu = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString();
                txtID.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString();
                txtPass.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6]).ToString(); 
                if(chucvu == "Quản lý")
                {
                    checkEditQuanLy.CheckState = CheckState.Checked;
                    checkEditNhanVien.CheckState = CheckState.Unchecked;
                }
                else
                {
                    checkEditNhanVien.CheckState = CheckState.Checked;
                    checkEditQuanLy.CheckState = CheckState.Unchecked;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        void LockControl()
        {
            txtMaNS.Enabled = false;
            txtHoTenNS.Enabled = false;
            txtSDTNS.Enabled = false;
            txtDCNS.Enabled = false;
            txtID.Enabled = false;
            txtPass.Enabled = false;
            checkEditQuanLy.Enabled = false;
            checkEditNhanVien.Enabled = false;

            btnThemNS.Enabled = true;
            btnXoaNS.Enabled = false;
            btnSua.Enabled = false;
            btnLuuNS.Enabled = false;
            btnHuyNS.Enabled = false;
            btnThoatNS.Enabled = true;
        }
        void UnLockControl()
        {
            txtMaNS.Enabled = true;
            txtHoTenNS.Enabled = true;
            txtSDTNS.Enabled = true;
            txtDCNS.Enabled = true;
            txtID.Enabled = true;
            txtPass.Enabled = true;
            checkEditQuanLy.Enabled = true;
            checkEditNhanVien.Enabled = true;

            btnThemNS.Enabled = false;
            btnXoaNS.Enabled = false;
            btnSua.Enabled = false;
            btnLuuNS.Enabled = true;
            btnHuyNS.Enabled = true;
            btnThoatNS.Enabled = false;
        }
        void ResetTextbox()
        {
            txtMaNS.Text = String.Empty;
            txtHoTenNS.Text = String.Empty;
            txtSDTNS.Text = String.Empty;
            txtDCNS.Text = String.Empty;
            txtPass.Text = String.Empty;
            txtID.Text = String.Empty;
            checkEditQuanLy.CheckState = CheckState.Unchecked;
            checkEditNhanVien.CheckState = CheckState.Unchecked;}

        private void btnTaiDanhSachNCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadDataNS();
            LockControl();
            ResetTextbox();
        }

        private void btnTaiDanhSachNS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadDataNS();
            LockControl();
            ResetTextbox();
        }

        private bool Them = true;
        private void btnThemNS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtPass.Enabled = true;
            txtID.Enabled = true;
            Them = true;
            ResetTextbox();
            UnLockControl();
        }

        private void btnXoaNS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult check = XtraMessageBox.Show("Bạn có chắc chắn muốn xoá nhân viên này?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (check == DialogResult.Yes)
            {
                try
                {
                    NhanSu_BUS.XoaNS(txtMaNS.Text);
                    LoadDataNS();
                }
                catch (SqlException ex)
                {

                    XtraMessageBox.Show(ex.Message);
                }

            }
        }

        private void btnThoatNS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnHuyNS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ResetTextbox();
            LockControl();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Them = false;
            UnLockControl();
            txtMaNS.Enabled = false;
            txtID.Enabled = false;
            txtPass.Enabled = false;}

        private void btnLuuNS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            string MaNS = txtMaNS.Text;
            string HoTenNS = txtHoTenNS.Text;
            string SDTNS = txtSDTNS.Text;
            string DCNS = txtDCNS.Text;
            string ID = txtID.Text;
            string Pass = txtPass.Text;
            string ChucVu = "";
            if(checkEditQuanLy.CheckState == CheckState.Checked)
            {
                ChucVu = checkEditQuanLy.Text;
            }
            else
            {
                ChucVu = checkEditNhanVien.Text;
            }
            NhanSu_DTO ns = new NhanSu_DTO(MaNS, HoTenNS, SDTNS, DCNS, ChucVu);
            TaiKhoanDTO tk = new TaiKhoanDTO(ID,Pass, MaNS);
            if (MaNS == "" || HoTenNS == "" || SDTNS == "" || DCNS == ""||ChucVu==""||ID==""||Pass=="")
                XtraMessageBox.Show("Bạn phải nhập đầy đủ thông tin của nhân viên!", "Thông báo");
            if (Them == true)
            {
                try
                {
                    NhanSu_BUS.ThemNS(ns,tk);
                    LoadDataNS();
                    XtraMessageBox.Show("Thêm nhân viên thành công!", "Thông báo");
                    LockControl();
                }
                catch (SqlException ex){
                    XtraMessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    NhanSu_BUS.SuaNS(ns);
                    LoadDataNS();
                    XtraMessageBox.Show("Sửa thông tin nhân viên thành công!", "Thông báo!");
                    LockControl();
                }
                catch (SqlException ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void checkEditQuanLy_CheckedChanged(object sender, EventArgs e)
        {
            if(checkEditQuanLy.CheckState == CheckState.Checked)
            {
                checkEditNhanVien.CheckState = CheckState.Unchecked;
            }
        }

        private void checkEditNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEditNhanVien.CheckState == CheckState.Checked)
            {
                checkEditQuanLy.CheckState = CheckState.Unchecked;
            }
        }

    }
}
