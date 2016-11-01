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
    public partial class ThongKeMatHang : DevExpress.XtraEditors.XtraForm
    {
        public ThongKeMatHang()
        {
            InitializeComponent();
        }

        private void ThongKeMatHang_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            gridControl1.DataSource = ThongKeMatHang_BUS.HangTonKho();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                timeEdit1.Properties.EditMask = "dd/MM/yyyy";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                timeEdit1.Properties.EditMask = "M/yyyy";
            }
            if (comboBox1.SelectedIndex == 2)
            {
                timeEdit1.Properties.EditMask = "yyyy";
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                DataTable dt = new DataTable();
                dt = ThongKeMatHang_BUS.HangBanChayNgay(timeEdit1.Text);
                gridControl2.DataSource = dt;
            }

            if (comboBox1.SelectedIndex == 1)
            {
                DataTable dt = new DataTable();
                dt = ThongKeMatHang_BUS.HangBanChayThang(timeEdit1.Text);
                gridControl2.DataSource = dt;
            }

            if (comboBox1.SelectedIndex == 2)
            {
                DataTable dt = new DataTable();
                dt = ThongKeMatHang_BUS.HangBanChayNam(Convert.ToInt32(timeEdit1.Text));
                gridControl2.DataSource = dt;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}