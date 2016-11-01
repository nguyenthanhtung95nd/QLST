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
    public partial class ThanhToan : Form
    {
        private string MaNS;

        public ThanhToan(string id)
        {
            InitializeComponent();
            MaNS = id;
        }

        private DataTable dt;

        private void ThanhToan_Load(object sender, EventArgs e)
        {
            load();
            MaNS = ThanhToan_BUS.MaNS(MaNS);
        }

        private void load()
        {
            comboBoxEditMH.Properties.Items.Clear();
            comboBoxEditKhachHang.Properties.Items.Clear();
            for (int i = 0; i < ThanhToan_BUS.LoadMH().Rows.Count; i++)
            {
                comboBoxEditMH.Properties.Items.Add(ThanhToan_BUS.LoadMH().Rows[i][1]);
            }

            for (int i = 0; i < ThanhToan_BUS.LoadKH().Rows.Count; i++)
            {
                comboBoxEditKhachHang.Properties.Items.Add(ThanhToan_BUS.LoadKH().Rows[i][1]);
            }
            comboBoxEditKhachHang.Text = "";

                       
            dt = ThanhToan_BUS.loaddtOrder(dt);

            gridControl1.DataSource = null;
            
            spinEditGiamGia.Enabled = true;
            spinEditGiamGia.Value = 0;
            comboBoxEditKhachHang.Enabled = true;
            comboBoxEditMH.Enabled = true;
            spinEditSL.Enabled = true;
            gridControl1.Enabled = true;
            txtTongTien.Text = "0";

            btnThem.Enabled = true;
            btnLamMoi.Enabled = false;
            btnInHD.Enabled = false;
        }

        private void btnThoatTT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (comboBoxEditMH.Text != "")
            {

                if (spinEditSL.Value > 0)
                {
                    DataRow r = dt.Rows.Find(ThanhToan_BUS.LoadMH().Rows[comboBoxEditMH.SelectedIndex][0]);
                    if (r == null)
                    {
                        if (Convert.ToInt32(spinEditSL.Value) <=
                            Convert.ToInt32(ThanhToan_BUS.LoadMH().Rows[comboBoxEditMH.SelectedIndex][6]))
                            //kiểm tra số lượng còn lại có đủ yêu cầu mua hay không
                        {
                            gridControl1.DataSource = ThanhToan_BUS.Them(comboBoxEditMH.SelectedIndex,
                                                                         Convert.ToInt32(spinEditSL.Value), dt);
                        }
                        else
                        {
                            MessageBox.Show("Số lượng hàng hóa còn lại không đủ theo yêu cầu!", "THÔNG BÁO",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        int quantity = int.Parse(r[2].ToString()) + Convert.ToInt32(spinEditSL.Value);
                        if (quantity <= Convert.ToInt32(ThanhToan_BUS.LoadMH().Rows[comboBoxEditMH.SelectedIndex][6]))
                        {
                            gridControl1.DataSource = ThanhToan_BUS.Them(comboBoxEditMH.SelectedIndex,
                                                                         Convert.ToInt32(spinEditSL.Value), dt);
                        }
                        else
                        {
                            MessageBox.Show("Số lượng hàng hóa còn lại không đủ theo yêu cầu!", "THÔNG BÁO",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    txtTongTien.Text = ThanhToan_BUS.TinhTien(dt, spinEditGiamGia.Text);
                    btnThanhToan.Enabled = true;
                    btnXoa.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Số lượng > 0!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Bạn phải chọn mặt hàng!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                comboBoxEditMH.SelectedItem =
                    gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
            } 
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {            
            load();          
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            gridView1.DeleteSelectedRows();
            txtTongTien.Text = ThanhToan_BUS.TinhTien(dt, spinEditGiamGia.Text);
            if(dt.Rows.Count == 0)
            {
                btnThanhToan.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string KH = "NULL";
            if(comboBoxEditKhachHang.Text != "")
            {
                KH = ThanhToan_BUS.LoadKH().Rows[comboBoxEditKhachHang.SelectedIndex][0].ToString();
            }

            if (MessageBox.Show("Bạn có muốn thanh toán và lưu hóa đơn này?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(ThanhToan_BUS.ThanhToan(txtTongTien.Text, spinEditGiamGia.Text,KH,MaNS,dt) == true)
                {
                    MessageBox.Show("Đã thanh toán thành công !", "THÔNG BÁO", MessageBoxButtons.OK);

                    btnThanhToan.Enabled = false;
                    btnThem.Enabled = false;
                    btnXoa.Enabled = false;
                    btnLamMoi.Enabled = true;
                    btnInHD.Enabled = true;

                    gridControl1.Enabled = false;
                    spinEditGiamGia.Enabled = false;
                    comboBoxEditKhachHang.Enabled = false;
                    comboBoxEditMH.Enabled = false;
                    comboBoxEditMH.Text = "";
                    spinEditSL.Enabled = false;
                    spinEditSL.Value = 0;
                    
                }
                else
                {
                    MessageBox.Show("Đã có lỗi trong quá trình thanh toán !","THÔNG BÁO",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
        }

        private void spinEditGiamGia_EditValueChanged(object sender, EventArgs e)
        {
            txtTongTien.Text = ThanhToan_BUS.TinhTien(dt, spinEditGiamGia.Value.ToString());
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            InHoaDon_BUS.InHD(ThanhToan_BUS.LaySoHD());
            MessageBox.Show("Hóa đơn đã được in !");
        }
    }
}
