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

namespace QLST
{
    public partial class TimKiem : Form
    {
        public TimKiem()
        {
            InitializeComponent();
        }

        #region Xử lý form load
        private void TimKiem_Load(object sender, EventArgs e)
        {
            checkDiaChi.Enabled = false;
            checkSDT.Enabled = false;
            checkDTL.Enabled = false;

            grctTimKiem.DataSource = TimKiemBUS.loadDataMH();
        }
        #endregion

        #region Xử lý button thoát form.
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult warning = (XtraMessageBox.Show("Bạn thật sự muốn ngừng tìm kiếm?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning));
            if (warning == DialogResult.Yes) 
                this.Close();
        }
        #endregion

        #region Xủ lý radio button cho group control chọn danh mục.
        int ChonDanhMuc = 1;
        int ChonThongTin = 1;

        private void checkMatHang_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMatHang.CheckState == CheckState.Checked)
            {
                ChonDanhMuc = 1;
                checkSLT.Enabled = true;
                checkDiaChi.Enabled = false;
                checkSDT.Enabled = false;
                checkDTL.Enabled = false;
                if (checkSLT.Checked == true || checkDTL.Checked == true || checkDiaChi.Checked == true || checkSDT.Checked == true)
                {
                    checkMaSo.CheckState = CheckState.Checked;
                    ChonThongTin = 1;
                }
            }
        }

        private void checkNhanSu_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNhanSu.CheckState == CheckState.Checked)
            {
                ChonDanhMuc = 2;
                checkDTL.Enabled = false;
                checkSLT.Enabled = false;
                checkDiaChi.Enabled = true;
                checkSDT.Enabled = true;
                if (checkDTL.Checked == true || checkSLT.Checked == true)
                {
                    checkMaSo.CheckState = CheckState.Checked;
                    ChonThongTin = 1;
                }
            }
        }

        private void checkNCC_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNCC.CheckState == CheckState.Checked)
            {
                ChonDanhMuc = 3;
                checkDTL.Enabled = false;
                checkSLT.Enabled = false;
                checkDiaChi.Enabled = true;
                checkSDT.Enabled = true;
                if (checkDTL.Checked == true || checkSLT.Checked == true)
                {
                    checkMaSo.CheckState = CheckState.Checked;
                    ChonThongTin = 1;
                }
            }
        }

        private void checkKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            if (checkKhachHang.CheckState == CheckState.Checked)
            {
                ChonDanhMuc = 4;
                checkDTL.Enabled = true;
                checkSLT.Enabled = false;
                checkDiaChi.Enabled = true;
                checkSDT.Enabled = true;
                if (checkSLT.Checked == true)
                {
                    checkMaSo.CheckState = CheckState.Checked;
                    ChonThongTin = 1;
                }
            }
        }
        #endregion

        #region Xử lý radio button cho group control chọn thông tin cần tìm.
        private void checkMaSo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMaSo.CheckState == CheckState.Checked)
            {
                ChonThongTin = 1;
            }
        }
        private void checkTen_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTen.CheckState == CheckState.Checked)
            {
                ChonThongTin = 2;
            }
        }
        private void checkDiaChi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDiaChi.CheckState == CheckState.Checked)
            {
                ChonThongTin = 3;
            }
        }
        private void checkSDT_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSDT.CheckState == CheckState.Checked)
            {
                ChonThongTin = 4;
            }
        }
        private void checkSLT_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSLT.CheckState == CheckState.Checked)
            {
                ChonThongTin = 5;
            }
        }
        private void checkDTL_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDTL.CheckState == CheckState.Checked)
            {
                ChonThongTin = 6;
            }
        }
        #endregion

        #region Xử lý button tải danh sách cho từng danh mục khác nhau.
        private void btnTaiDanhSach_Click(object sender, EventArgs e)
        {
            switch (ChonDanhMuc)
            {
                case 1:
                    grctTimKiem.MainView = grvMatHang;
                    grctTimKiem.DataSource = TimKiemBUS.loadDataMH();
                    break;
                case 2:
                    grctTimKiem.MainView = grvNhanSu;
                    grctTimKiem.DataSource = TimKiemBUS.loadDataNS();
                    break;
                case 3:
                    grctTimKiem.MainView = grvNCC;
                    grctTimKiem.DataSource = TimKiemBUS.loadDataNCC();
                    break;
                case 4:
                    grctTimKiem.MainView = grvKhachHang;
                    grctTimKiem.DataSource = TimKiemBUS.loadDataKH();
                    break;
            }
        }
        #endregion

        #region Xử lý button tìm kiếm cho từng trường hợp khác nhau.
        private void btnTim_Click(object sender, EventArgs e)
        {
            switch (ChonDanhMuc)
            {
                case 1:
                    grctTimKiem.MainView = grvMatHang;
                    switch (ChonThongTin)
                    {
                        case 1:
                            grctTimKiem.DataSource = TimKiemBUS.timTheoMaMH(txteTuKhoa.Text);
                            break;
                        case 2:
                            grctTimKiem.DataSource = TimKiemBUS.timTheoTenMH(txteTuKhoa.Text);
                            break;
                        case 5:
                            try
                            {
                                grctTimKiem.DataSource = TimKiemBUS.timTheoSLT(Int32.Parse(txteTuKhoa.Text));
                            }
                            catch
                            {
                                XtraMessageBox.Show("Vui lòng nhập một số!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    grctTimKiem.MainView = grvNhanSu;
                    switch (ChonThongTin)
                    {
                        case 1:
                            grctTimKiem.DataSource = TimKiemBUS.timTheoMaNS(txteTuKhoa.Text);
                            break;
                        case 2:
                            grctTimKiem.DataSource = TimKiemBUS.timTheoTenNS(txteTuKhoa.Text);
                            break;
                        case 3:
                            grctTimKiem.DataSource = TimKiemBUS.timTheoDCNS(txteTuKhoa.Text);
                            break;
                        case 4:
                            try
                            {
                                grctTimKiem.DataSource = TimKiemBUS.timTheoSDTNS(txteTuKhoa.Text);
                            }
                            catch
                            {
                                XtraMessageBox.Show("Số điện thoại phải là số gồm 11 chữ số bắt đầu bằng 012 \nhoặc 10 chữ số bắt đầu bằng 09.", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    grctTimKiem.MainView = grvNCC;
                    switch (ChonThongTin)
                    {
                        case 1:
                            grctTimKiem.DataSource = TimKiemBUS.timTheoMaNCC(txteTuKhoa.Text);
                            break;
                        case 2:
                            grctTimKiem.DataSource = TimKiemBUS.timTheoTenNCC(txteTuKhoa.Text);
                            break;
                        case 3:
                            grctTimKiem.DataSource = TimKiemBUS.timTheoDCNCC(txteTuKhoa.Text);
                            break;
                        case 4:
                            try
                            {
                                grctTimKiem.DataSource = TimKiemBUS.timTheoSDTNCC(txteTuKhoa.Text);
                            }
                            catch
                            {
                                XtraMessageBox.Show("Số điện thoại phải là số gồm 11 chữ số bắt đầu bằng 012 \nhoặc 10 chữ số bắt đầu bằng 09.", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case 4:
                    grctTimKiem.MainView = grvKhachHang;
                    switch (ChonThongTin)
                    {
                        case 1:
                            grctTimKiem.DataSource = TimKiemBUS.timTheoMaKH(txteTuKhoa.Text);
                            break;
                        case 2:
                            grctTimKiem.DataSource = TimKiemBUS.timTheoTenKH(txteTuKhoa.Text);
                            break;
                        case 3:
                            grctTimKiem.DataSource = TimKiemBUS.timTheoDCKH(txteTuKhoa.Text);
                            break;
                        case 4:
                            try
                            {
                                grctTimKiem.DataSource = TimKiemBUS.timTheoSDTKH(txteTuKhoa.Text);
                            }
                            catch
                            {
                                XtraMessageBox.Show("Số điện thoại phải là số gồm 11 chữ số bắt đầu bằng 012 \nhoặc 10 chữ số bắt đầu bằng 09.", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case 6:
                            try
                            {
                                grctTimKiem.DataSource = TimKiemBUS.timTheoDTL(Int32.Parse(txteTuKhoa.Text));
                            }
                            catch
                            {
                                XtraMessageBox.Show("Vui lòng nhập một số!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        default:
                            break;
                    }
                    break;
            }
        }
        private void btnTim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnTim_Click(sender, e);
        }
        #endregion

        #region Xử lý chú thích khi đưa chuột lại gần radio button điểm tích luỹ và số lượng tồn.
        private void checkSLT_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt1 = new ToolTip();
            tt1.SetToolTip(checkSLT, "Số lượng tồn lớn hơn hoặc bằng số cần tìm");
        }

        private void checkDTL_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt2 = new ToolTip();
            tt2.SetToolTip(checkDTL,"Điểm tích luỹ lớn hơn hoặc bằng số cần tìm");
        }
        #endregion

        
    }
}
