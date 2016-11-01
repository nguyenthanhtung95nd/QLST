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
    public partial class HoaDon : Form
    {
        private string MaNS;

        public HoaDon(string id)
        {
            InitializeComponent();
            MaNS = MaNS = ThanhToan_BUS.MaNS(id);
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            LoadcmbHoaDon();
            if(NhanSu_BUS.LayNS(MaNS).Rows[0][1].ToString() == "Nhân viên")
            {
                btnXoaHD.Enabled = false;
            }
        }

        private void LoadcmbHoaDon()
        {
            if (HoaDon_BUS.LoadHoaDon().Rows.Count != 0)
            {
                comboBoxEditHoaDon.Properties.Items.Clear();
                for (int i = 0; i < HoaDon_BUS.LoadHoaDon().Rows.Count; i++)
                {
                    comboBoxEditHoaDon.Properties.Items.Add(HoaDon_BUS.LoadHoaDon().Rows[i][0]);
                }
                comboBoxEditHoaDon.SelectedIndex = 0;
                loadCTHD();
            }
            else
            {
                comboBoxEditHoaDon.Text = "";
                gridControl.DataSource = null;
            }
        }

        private void btnThoat_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void comboBoxEditHoaDon_SelectedValueChanged(object sender, System.EventArgs e)
        {
            if (comboBoxEditHoaDon.Text != "")
            {
                loadCTHD();
                btnInHD.Enabled = true;
            }
            else
            {
                btnInHD.Enabled = false;
            }
        }

        private void loadCTHD()
        {          
            int i = Convert.ToInt16(comboBoxEditHoaDon.Text);
            for (int j = 0; j < HoaDon_BUS.LoadHoaDon().Rows.Count; j++)
            {
                if(i == Convert.ToInt16(HoaDon_BUS.LoadHoaDon().Rows[j][0]))
                {
                    dateEditNgayLap.EditValue = Convert.ToDateTime(HoaDon_BUS.LoadHoaDon().Rows[j][1]);
                    txtGiamGia.Text = Convert.ToString(HoaDon_BUS.LoadHoaDon().Rows[j][4]);
                    txtTongTien.Text = Convert.ToString(HoaDon_BUS.LoadHoaDon().Rows[j][5]);
                    txtNhanVien.Text = Convert.ToString(HoaDon_BUS.LoadHoaDon().Rows[j][3]);
                    if (Convert.ToString(HoaDon_BUS.LoadHoaDon().Rows[j][2]) != "")
                    {
                        txtEditKH.Text = HoaDon_BUS.LayKH(Convert.ToString(HoaDon_BUS.LoadHoaDon().Rows[j][2]));
                    }
                    else
                    {
                        txtEditKH.ResetText();
                    }
                    gridControl.DataSource = HoaDon_BUS.LoadChiTietHD(Convert.ToString(HoaDon_BUS.LoadHoaDon().Rows[j][0]));
                    break;
                }
            }         
        }

        private void btnXoaHD_Click(object sender, System.EventArgs e)
        {
            if (comboBoxEditHoaDon.Text != "")
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa hóa đơn này?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { 
                    try
                    {
                        HoaDon_BUS.XoaHD(comboBoxEditHoaDon.SelectedItem.ToString());
                        MessageBox.Show("Đã xóa hóa đơn.");
                        dateEditNgayLap.Text = String.Empty;
                        txtEditKH.Text = String.Empty;
                        txtNhanVien.Text = String.Empty;
                        txtTongTien.Text = String.Empty;
                        txtGiamGia.Text = String.Empty;
                        dateEditHDTheoNgay_EditValueChanged(sender,e);
                    }
                    catch (SqlException ex)
                    {
                        XtraMessageBox.Show(ex.Message);
                    }
                }               
            }
            else
            {
                XtraMessageBox.Show("Không có hóa đơn nào!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dateEditHDTheoNgay_EditValueChanged(object sender, EventArgs e)
        {
            comboBoxEditHoaDon.Properties.Items.Clear();

            dateEditNgayLap.Text = "";
            txtEditKH.Text = "";
            txtNhanVien.Text = "";
            txtGiamGia.Text = "";
            txtTongTien.Text = "";
            if (dateEditHDTheoNgay.SelectedText == "")
            {
                LoadcmbHoaDon();
            }
            else
            {
                if (HoaDon_BUS.LoadHDTheoNgay(Convert.ToString(dateEditHDTheoNgay.SelectedText)).Rows.Count != 0)
                {                    
                    for (int i = 0;i < HoaDon_BUS.LoadHDTheoNgay(Convert.ToString(dateEditHDTheoNgay.SelectedText)).Rows.Count;i++)
                    {
                        comboBoxEditHoaDon.Properties.Items.Add(HoaDon_BUS.LoadHDTheoNgay(Convert.ToString(dateEditHDTheoNgay.SelectedText)).Rows[i][0]);
                    }
                    comboBoxEditHoaDon.SelectedIndex = 0;
                    loadCTHD();
                }
                else
                {
                    comboBoxEditHoaDon.Text = "";
                    gridControl.DataSource = null;
                    btnInHD.Enabled = false;
                }
            }
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            InHoaDon_BUS.InHD(comboBoxEditHoaDon.Text);
            XtraMessageBox.Show("Hóa đơn đã được in !");
        }
    }
}
