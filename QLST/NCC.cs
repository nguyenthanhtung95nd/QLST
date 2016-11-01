using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DTO;
using BUS;
using System.Data.SqlClient;
using DevExpress.XtraEditors;

namespace QLST
{
    public partial class NCC : Form
    {
        public NCC()
        {
            InitializeComponent();
        }

        private void LoadDataNCC()
        {
            gridControl1.DataSource = NCC_BUS.LoadDataNCC();
        }

        private void NCC_Load(object sender, EventArgs e)
        {
            LockControl();
            LoadDataNCC();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            LockControl();
            btnSuaNCC.Enabled = true;
            btnXoaNCC.Enabled = true;
            try
            {
                txtMaNCC.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                txtTenNCC.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                txtDCNCC.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
                txtSDTNCC.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private bool Them = true;
        private void btnThemNCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Them = true;
            ResetTextbox();
            UnLockControl();
        }

        private void btnLuuNCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            string MaNCC = txtMaNCC.Text;
            string TenNCC = txtTenNCC.Text;
            string DCNCC = txtDCNCC.Text;
            string SDTNCC = txtSDTNCC.Text;      
            NCC_DTO ncc = new NCC_DTO(MaNCC,TenNCC,DCNCC,SDTNCC);
            if (MaNCC == "" || TenNCC == "" || DCNCC == "" || SDTNCC == "")
            {
                XtraMessageBox.Show("Bạn phải nhập đầy đủ thông tin của nhà cung cấp!", "Thông báo");
            }
            else
            {
                if (Them == true)
                {
                    try
                    {
                        NCC_BUS.ThemNCC(ncc);
                        LoadDataNCC();
                        XtraMessageBox.Show("Thêm thông tin nhà cung cấp hàng thành công!", "Thông báo");
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
                        NCC_BUS.SuaNCC(ncc);
                        LoadDataNCC();
                        XtraMessageBox.Show("Sửa thông tin nhà cung cấp thành công!", "Thông báo!");
                        LockControl();
                    }
                    catch (SqlException ex)
                    {
                        XtraMessageBox.Show(ex.Message);
                    }
                }
            }}

        private void btnXoaNCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {          
            DialogResult check = XtraMessageBox.Show("Bạn có chắc chắn muốn xoá thông tin nhà cung cấp này?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (check == DialogResult.Yes)
            {
                try
                {
                    NCC_BUS.XoaNCC(txtMaNCC.Text);
                    LoadDataNCC();
                }
                catch (SqlException ex)
                {

                    XtraMessageBox.Show(ex.Message);
                }
                
            }
        }

        private void btnSuaNCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Them = false;
            UnLockControl();
            txtMaNCC.Enabled = false;
        }

        private void btnThoatNCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        void LockControl()
        {
            txtMaNCC.Enabled = false;
            txtTenNCC.Enabled = false;
            txtDCNCC.Enabled = false;
            txtSDTNCC.Enabled = false;

            btnThemNCC.Enabled = true;
            btnXoaNCC.Enabled = false;
            btnSuaNCC.Enabled = false;
            btnLuuNCC.Enabled = false;
            btnHuyNCC.Enabled = false;
            btnThoatNCC.Enabled = true;
        }
        void UnLockControl()
        {
            txtMaNCC.Enabled = true;
            txtTenNCC.Enabled = true;
            txtDCNCC.Enabled = true;
            txtSDTNCC.Enabled = true;

            btnThemNCC.Enabled = false;
            btnXoaNCC.Enabled = false;
            btnSuaNCC.Enabled = false;
            btnLuuNCC.Enabled = true;
            btnHuyNCC.Enabled = true;
            btnThoatNCC.Enabled = false;
        }
        void ResetTextbox()
        {
            txtMaNCC.Text = String.Empty;
            txtTenNCC.Text = String.Empty;
            txtDCNCC.Text = String.Empty;
            txtSDTNCC.Text = String.Empty;
        }

        private void btnTaiDanhSachNCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadDataNCC();
            LockControl();
            ResetTextbox();
        }

        private void btnHuyNCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ResetTextbox();
            LockControl();
        }
    }
}
