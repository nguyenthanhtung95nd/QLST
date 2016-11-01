using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUS;
using System.Data;

namespace QLST
{
    public partial class BaoCaoDoanhThu : DevExpress.XtraEditors.XtraForm
    {
        public BaoCaoDoanhThu()
        {
            InitializeComponent();
        }

        private void BaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void btnXem_Click_1(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0)
            {
                DataTable dt = new DataTable();
                dt = BaoCaoDoanhThu_BUS.DoanhThu();
                gridControl1.DataSource = dt;
                int tongban = 0, tongnhap = 0, tongLN = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tongban = tongban + Convert.ToInt32(dt.Rows[i][1]);
                    tongnhap = tongnhap + Convert.ToInt32(dt.Rows[i][2]);
                }
                tongLN = tongban - tongnhap;
                labelTongBan.Text = "Tổng trị giá bán: " + tongban;
                labelTongNhap.Text = "Tổng trị giá nhập: " + tongnhap;
                labelTongLoiNhuan.Text = "TỔNG LỢI NHUẬN: " + tongLN;
            }

            if (comboBox1.SelectedIndex == 3)
            {
                DataTable dt = new DataTable();
                dt = BaoCaoDoanhThu_BUS.DoanhThuTheoNam(Convert.ToInt32(timeEdit1.Text));
                gridControl1.DataSource = dt;
                int tongban = 0, tongnhap = 0, tongLN = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tongban = tongban + Convert.ToInt32(dt.Rows[i][1]);
                    tongnhap = tongnhap + Convert.ToInt32(dt.Rows[i][2]);
                    tongLN = tongLN + Convert.ToInt32(dt.Rows[i][3]);
                }
                labelTongBan.Text = "Tổng trị giá bán: " + tongban;
                labelTongNhap.Text = "Tổng trị giá nhập: " + tongnhap;
                labelTongLoiNhuan.Text = "TỔNG LỢI NHUẬN: " + tongLN;
            }

            if (comboBox1.SelectedIndex == 2)
            {
                DataTable dt = new DataTable();
                dt = BaoCaoDoanhThu_BUS.DoanhThuTheoThang(timeEdit1.Text);
                gridControl1.DataSource = dt;
                int tongban = 0, tongnhap = 0, tongLN = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tongban = tongban + Convert.ToInt32(dt.Rows[i][1]);
                    tongnhap = tongnhap + Convert.ToInt32(dt.Rows[i][2]);
                    tongLN = tongLN + Convert.ToInt32(dt.Rows[i][3]);
                }
                labelTongBan.Text = "Tổng trị giá bán: " + tongban;
                labelTongNhap.Text = "Tổng trị giá nhập: " + tongnhap;
                labelTongLoiNhuan.Text = "TỔNG LỢI NHUẬN: " + tongLN;
            }

            if (comboBox1.SelectedIndex == 1)
            {
                DataTable dt = new DataTable();
                dt = BaoCaoDoanhThu_BUS.DoanhThuTheoNgay(timeEdit1.Text);
                gridControl1.DataSource = dt;
                int tongban = 0, tongnhap = 0, tongLN = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tongban = tongban + Convert.ToInt32(dt.Rows[i][1]);
                    tongnhap = tongnhap + Convert.ToInt32(dt.Rows[i][2]);
                    tongLN = tongLN + Convert.ToInt32(dt.Rows[i][3]);
                }
                labelTongBan.Text = "Tổng trị giá bán: " + tongban;
                labelTongNhap.Text = "Tổng trị giá nhập: " + tongnhap;
                labelTongLoiNhuan.Text = "TỔNG LỢI NHUẬN: " + tongLN;
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                timeEdit1.Text = String.Empty;
                timeEdit1.Enabled = false;
            }
            else
            {
                timeEdit1.Enabled = true;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                timeEdit1.Properties.EditMask = "dd/MM/yyyy";
            }
            if (comboBox1.SelectedIndex == 2)
            {
                timeEdit1.Properties.EditMask = "M/yyyy";
            }
            if (comboBox1.SelectedIndex == 3)
            {
                timeEdit1.Properties.EditMask = "yyyy";
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
