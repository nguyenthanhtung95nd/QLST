using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using BUS;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLST
{
    public partial class DonDatHang : Form
    {
        public DonDatHang()
        {
            InitializeComponent();
        }

        private void btnThoatDDH_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DonDatHang_Load(object sender, EventArgs e)
        {
            LoadcmbDDH();
        }

        private void LoadcmbDDH()
        {
            if (DonDatHang_BUS.LoadDonDatHang().Rows.Count != 0)
            {
                comboBoxEditDonDH.Properties.Items.Clear();
                for (int i = 0; i < DonDatHang_BUS.LoadDonDatHang().Rows.Count; i++)
                {
                    comboBoxEditDonDH.Properties.Items.Add(DonDatHang_BUS.LoadDonDatHang().Rows[i][0]);
                }
                comboBoxEditDonDH.SelectedIndex = 0;
                LoadCTDDH();
            }
            else
            {
                comboBoxEditDonDH.Text = "";
                gridControl1.DataSource = null;
            }
        }

        private void LoadCTDDH()
        {
            int i = Convert.ToInt16(comboBoxEditDonDH.Text);
            for (int j = 0; j < DonDatHang_BUS.LoadDonDatHang().Rows.Count; j++)
            {
                if (i == Convert.ToInt16(DonDatHang_BUS.LoadDonDatHang().Rows[j][0]))
                {
                    txtNhaCC.Text = Convert.ToString(DonDatHang_BUS.LoadDonDatHang().Rows[j][1]);
                    dateEditNgayLapDDH.EditValue = Convert.ToDateTime(DonDatHang_BUS.LoadDonDatHang().Rows[j][2]);                 
                    txtNhanVien.Text = Convert.ToString(DonDatHang_BUS.LoadDonDatHang().Rows[j][3]);
                    txtTongTien.Text = Convert.ToString(DonDatHang_BUS.LoadDonDatHang().Rows[j][4]);           
                    gridControl1.DataSource = DonDatHang_BUS.LoadChiTietDonDatHang(Convert.ToString(i));
                    break;
                }
            } 
        }

        private void comboBoxEditDonDH_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadCTDDH();
        }

        private void btnXoaDonDatHang_Click(object sender, EventArgs e)
        {
            if (comboBoxEditDonDH.Text != "")
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa đơn đặt hàng này?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        DonDatHang_BUS.XoaDDH(comboBoxEditDonDH.SelectedItem.ToString());
                        XtraMessageBox.Show("Đã xóa hóa đơn.");
                        dateEditNgayLapDDH.Text = String.Empty;
                        txtNhaCC.Text = String.Empty;
                        txtNhanVien.Text = String.Empty;
                        txtTongTien.Text = String.Empty;
                        dateDDHTheoNgay_EditValueChanged(sender, e);
                    }
                    catch (SqlException ex)
                    {
                        XtraMessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Không có đơn đặt hàng nào!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dateDDHTheoNgay_EditValueChanged(object sender, EventArgs e)
        {
            comboBoxEditDonDH.Properties.Items.Clear();

            dateEditNgayLapDDH.Text = "";
            txtNhaCC.Text = "";
            txtNhanVien.Text = "";
            txtTongTien.Text = "";
            if (dateDDHTheoNgay.SelectedText == "")
            {
                LoadcmbDDH();
            }
            else
            {
                if (DonDatHang_BUS.LoadDonDatHangTheoNgay(Convert.ToString(dateDDHTheoNgay.SelectedText)).Rows.Count != 0)
                {
                    for (int i = 0; i < DonDatHang_BUS.LoadDonDatHangTheoNgay(Convert.ToString(dateDDHTheoNgay.SelectedText)).Rows.Count; i++)
                    {
                        comboBoxEditDonDH.Properties.Items.Add(DonDatHang_BUS.LoadDonDatHangTheoNgay(Convert.ToString(dateDDHTheoNgay.SelectedText)).Rows[i][0]);
                    }
                    comboBoxEditDonDH.SelectedIndex = 0;
                    LoadCTDDH();
                }
                else
                {
                    comboBoxEditDonDH.Text = "";
                    gridControl1.DataSource = null;
                }
            }
        }
    }
}
