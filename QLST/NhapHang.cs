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
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace QLST
{
    public partial class NhapHang : Form
    {
        string id;
        public NhapHang(string tenNS)
        {
            InitializeComponent();
            id = tenNS;
        }

        private void btnThemNCCMoi_Click(object sender, EventArgs e)
        {
            foreach (Form formCon in this.MdiParent.MdiChildren)
            {
                if (formCon.Name == "NCC")
                {
                    formCon.Activate();
                    return;
                }
            }
            NCC moNCC = new NCC();
            moNCC.MdiParent = this.ParentForm;
            moNCC.Show();
        }
        DataTable dtMHDDH;
        private void TaiDanhSachCombobox()
        {
            cmbTenNCC.Properties.Items.Clear();
            for (int i = 0; i < NhapHangBUS.loadDataNCC().Rows.Count; i++)
            {
                cmbTenNCC.Properties.Items.Add(NhapHangBUS.loadDataNCC().Rows[i][1]);
            }

            dtMHDDH = NhapHangBUS.loadDanhSachDH(dtMHDDH);

            dateNgayLapDDH.EditValue = DateTime.Now;
            cmbTenMH.Text = "";
            cmbTenNCC.Text = "";
            txtDonGiaNhap.Text = "0";
            txtSoLuongNhap.Text = "1";
            txtTongTien.Text = "0";
        }

        private void NhapHang_Load(object sender, EventArgs e)
        {
            txtTenNS.Text = NhapHangBUS.loadHotenNS(id);
            txtTenNS.Properties.ReadOnly = true;
            txtTongTien.Properties.ReadOnly = true;
            TaiDanhSachCombobox();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnThemMHMoi_Click(object sender, EventArgs e)
        {

            foreach (Form formCon in this.MdiParent.MdiChildren)
            {
                if (formCon.Name == "MatHang")
                {
                    formCon.Activate();
                    return;
                }
            }
            MatHang moMatHang = new MatHang();
            moMatHang.MdiParent = this.ParentForm;
            moMatHang.Show();
        }
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            grvDSMHNhap.DeleteSelectedRows();
            txtTongTien.Text = NhapHangBUS.tongTienDDH(dtMHDDH).ToString();
            if(dtMHDDH.Rows.Count == 0)
            {
                btnXoa.Enabled = false;
                btnNhapHang.Enabled = false;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            TaiDanhSachCombobox();
            grcDSNhap.DataSource = null;

            cmbTenNCC.Enabled = true;
            cmbTenMH.Enabled = true;
            txtSoLuongNhap.Enabled = true;
            txtDonGiaNhap.Enabled = true;
            dateNgayLapDDH.Enabled = true;

            btnThemHang.Enabled = true;
            btnThemMHMoi.Enabled = true;
            btnThemNCCMoi.Enabled = true;
            btnLamMoi.Enabled = false;
        }

        private void grcDSNhap_Click(object sender, EventArgs e)
        {
            if (dtMHDDH.Rows.Count > 0)
            {
                cmbTenMH.SelectedItem = grvDSMHNhap.GetRowCellValue(grvDSMHNhap.FocusedRowHandle, grvDSMHNhap.Columns[1]).ToString();
            } 
        }
        private void btnThemHang_Click(object sender, EventArgs e)
        {
            if (cmbTenMH.Text != "")
            {
                if (Convert.ToInt32(txtSoLuongNhap.Text) > 0)
                {
                    string maNCC = NhapHangBUS.loadDataNCC().Rows[cmbTenNCC.SelectedIndex][0].ToString();
                    DataRow r = dtMHDDH.Rows.Find(NhapHangBUS.loadDataMH(maNCC).Rows[cmbTenMH.SelectedIndex][0]);
                    if (r == null)
                    {
                        grcDSNhap.DataSource = NhapHangBUS.Them(cmbTenMH.SelectedIndex, Convert.ToInt32(txtSoLuongNhap.Text), Convert.ToInt32(txtDonGiaNhap.Text), maNCC, dtMHDDH);
                    }
                    else
                    {
                        int tongsl = Convert.ToInt32(r[3]) + Convert.ToInt32(txtSoLuongNhap.Text);
                        grcDSNhap.DataSource = NhapHangBUS.Them(cmbTenMH.SelectedIndex, Convert.ToInt32(txtSoLuongNhap.Text), Convert.ToInt32(txtDonGiaNhap.Text), maNCC, dtMHDDH);
                    }
                    txtTongTien.Text = (NhapHangBUS.tongTienDDH(dtMHDDH)).ToString();
                    btnXoa.Enabled = true;
                    btnNhapHang.Enabled = true;
                }
                else
                {
                   XtraMessageBox.Show("Số lượng nhập > 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                XtraMessageBox.Show("Bạn phải chọn một mặt hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            string maNCC = NhapHangBUS.loadDataNCC().Rows[cmbTenNCC.SelectedIndex][0].ToString();
            string ngayLap = dateNgayLapDDH.Text;
            string maNS = NhapHangBUS.loadMaNS(id);
            if (XtraMessageBox.Show("Bạn có muốn nhập hàng và lưu đơn đặt hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {                
                if (NhapHangBUS.thanhToanDDH(maNCC, ngayLap, maNS, dtMHDDH) == true)
                {
                    XtraMessageBox.Show("Đã nhập hàng thành công!", "Thông báo", MessageBoxButtons.OK);
                    TaiDanhSachCombobox();
                    grcDSNhap.DataSource = null;
                    cmbTenMH.Text = "";                 
                    cmbTenNCC.Text = "";                 
                    txtDonGiaNhap.Text = "0";             
                    txtSoLuongNhap.Text = "1";
                    cmbTenNCC.Enabled = false;
                    cmbTenMH.Enabled = false;
                    txtSoLuongNhap.Enabled = false;
                    txtDonGiaNhap.Enabled = false;
                    dateNgayLapDDH.Enabled = false;
                    btnThemHang.Enabled = false;
                    btnXoa.Enabled = false;
                    btnThemMHMoi.Enabled = false;
                    btnThemNCCMoi.Enabled = false;
                    btnNhapHang.Enabled = false;
                    btnLamMoi.Enabled = true;
                }
                else
                {
                    XtraMessageBox.Show("Đã có lỗi trong quá trình nhập hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cmbTenNCC_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbTenNCC.Text != "")
            {
                string maNCC = NhapHangBUS.loadDataNCC().Rows[cmbTenNCC.SelectedIndex][0].ToString();
                cmbTenMH.Properties.Items.Clear();
                cmbTenMH.Text = "";
                for (int i = 0; i < NhapHangBUS.loadDataMH(maNCC).Rows.Count; i++)
                {
                    cmbTenMH.Properties.Items.Add(NhapHangBUS.loadDataMH(maNCC).Rows[i][1]);
                }
            }
        }
    }
}
