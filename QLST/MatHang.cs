using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS;
using DTO;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace QLST
{
    public partial class MatHang : Form
    {
        public MatHang()
        {
            InitializeComponent();
        }

        void LoadDataNCC()
        {

            cbNCC.Properties.DataSource = MatHang_BUS.LoadDataNCC();
            cbNCC.Properties.ValueMember = "MaNCC";
            cbNCC.Properties.DisplayMember = "TenNCC";
            cbNCC.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            cbNCC.Properties.SearchMode = SearchMode.AutoComplete;
            cbNCC.Properties.AutoSearchColumnIndex = 1;

        }
        void LoadDataMatHang()
        {
            grDanhSach.DataSource = MatHang_BUS.LoadDataMH();
        }

        private void MatHang_Load(object sender, EventArgs e)
        {
            LoadDataMatHang();
            LoadDataNCC();
            LockControl();
        }

        private void btnThoatMH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        void LockControl()
        {
            txtMaMH.Enabled = false;
            txtTenMH.Enabled = false;
            txtQuyCach.Enabled = false;
            txtDGBan.Enabled = false;
            txtDGMua.Enabled = false;
            txtKM.Enabled = false;
            cbNCC.Enabled = false;
            txtSLT.Enabled = false;

            btnThemMH.Enabled = true;
            btnXoaMH.Enabled = false;
            btnSuaMH.Enabled = false;
            btnLuuMH.Enabled = false;
            btnHuyMH.Enabled = false;
            btnThoatMH.Enabled = true;
        }
        void UnLockControl()
        {
            txtMaMH.Enabled = true;
            txtTenMH.Enabled = true;
            txtQuyCach.Enabled = true;
            txtDGBan.Enabled = true;
            txtDGMua.Enabled = true;
            txtKM.Enabled = true;
            cbNCC.Enabled = true;
            txtSLT.Enabled = true;

            btnThemMH.Enabled = false;
            btnXoaMH.Enabled = false;
            btnSuaMH.Enabled = false;
            btnLuuMH.Enabled = true;
            btnHuyMH.Enabled = true;
            btnThoatMH.Enabled = false;
        }
        void ResetTexBox()
        {
            txtMaMH.Text = String.Empty;
            txtTenMH.Text = String.Empty;
            txtQuyCach.Text = String.Empty;
            cbNCC.EditValue = "";
            txtDGBan.Text = String.Empty;
            txtDGMua.Text = String.Empty;
            txtSLT.Text = String.Empty;
            txtKM.Text = String.Empty;
        }

        private void btnHuyMH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ResetTexBox();
            LockControl();
        }

        private bool Them = true;
        private void btnThemMH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Them = true;
            ResetTexBox();
            UnLockControl();
            cbNCC.EditValue = "";
        }
        private void btnSuaMH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Them = false;
            UnLockControl();
            txtMaMH.Enabled = false;
            cbNCC.Enabled = false;
            txtSLT.Enabled = false; 
            txtMaMH.Enabled = false;
        }

        private void btnXoaMH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult check = XtraMessageBox.Show("Bạn có chắc chắn muốn xoá nhà mặt hàng này?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (check == DialogResult.Yes)
            {
                try
                {
                    MatHang_BUS.XoaMH(txtMaMH.Text);
                    LoadDataMatHang();
                    LoadDataNCC();
                }
                catch (SqlException ex)
                {

                    XtraMessageBox.Show(ex.Message);
                }

            }

        }

        private void grDanhSach_Click(object sender, EventArgs e)
        {

            LockControl();
            btnSuaMH.Enabled = true;
            btnXoaMH.Enabled = true;
            try
            {
                txtMaMH.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                txtTenMH.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                txtQuyCach.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
                cbNCC.EditValue = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[8]).ToString();
                txtDGMua.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString();
                txtDGBan.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString();
                txtSLT.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6]).ToString();
                txtKM.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[7]).ToString();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnTaiDanhSachMH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadDataMatHang();
            LoadDataNCC();
            LockControl();
            ResetTexBox();
        }

        private void btnLuuMH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string MaMH = txtMaMH.Text;
            string TenMH = txtTenMH.Text;
            string QuyCach = txtQuyCach.Text;
            string TenNCC = cbNCC.EditValue.ToString();
            string DonGiaMua = txtDGMua.Text;
            string DonGiaBan = txtDGBan.Text;
            string SLT = txtSLT.Text;
            string KM = txtKM.Text;

            MatHang_DTO mh = new MatHang_DTO(MaMH, TenMH, QuyCach, TenNCC, DonGiaMua, DonGiaBan, SLT, KM);

            if (MaMH == "" || TenMH == "" || TenNCC == "" || DonGiaMua == "" || DonGiaBan == "" || SLT == "" || QuyCach == "")
            {
                XtraMessageBox.Show("Bạn phải nhập đầy đủ thông tin của mặt hàng!", "Thông báo");}
            else
            {
                if (Them == true)
                {
                    try
                    {
                        MatHang_BUS.ThemMH(mh);
                        LoadDataMatHang();
                        LoadDataNCC();
                        XtraMessageBox.Show("Them thông tin mặt hàng thành công!", "Thông báo!");
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
                        MatHang_BUS.SuaMH(mh);
                        LoadDataMatHang();
                        LoadDataNCC();
                        XtraMessageBox.Show("Sửa thông tin mặt hàng thành công!", "Thông báo!");
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
