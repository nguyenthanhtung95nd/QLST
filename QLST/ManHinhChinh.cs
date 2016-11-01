using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using BUS;
using SplashScreen;

namespace QLST
{
    public partial class ManHinhChinh : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public static bool Hotro=true;
            
        string tenTK;
        public ManHinhChinh()
        {
            InitializeComponent();
        }
     
        public ManHinhChinh(string id)
        {
            InitializeComponent();
            this.tenTK = id;
        }
        Form CheckForm(Type fType)
        {
            foreach (var f in this.MdiChildren)
            {
                if (f.GetType() == fType)
                {
                    return f;
                }
            }
            return null;
        }

        private void btnDoiMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DoiMK moDoiMK = new DoiMK(tenTK);
            moDoiMK.ShowDialog();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult warning = XtraMessageBox.Show("Bạn thật sự muốn thoát khỏi chương trình?", "Lưu ý!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (warning == DialogResult.Yes)
                Application.Exit();
        }

        private void btnMatHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = CheckForm(typeof(MatHang));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                MatHang fr = new MatHang();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void btnNhaCungCap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = CheckForm(typeof(NCC));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                NCC fr = new NCC(); fr.MdiParent = this;
                fr.Show();
            }
        }

        private void btnNhanSu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = CheckForm(typeof(NhanSu));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                NhanSu fr = new NhanSu();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void btnKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = CheckForm(typeof(KhachHang));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                KhachHang fr = new KhachHang();
                fr.MdiParent = this;
                fr.Show();
            }
           
        }

        private void btnHoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = CheckForm(typeof(HoaDon));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                HoaDon fr = new HoaDon(tenTK);
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void btnDonDatHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = CheckForm(typeof(DonDatHang));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                DonDatHang fr = new DonDatHang();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void btnThanhToan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = CheckForm(typeof(ThanhToan));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                ThanhToan fr = new ThanhToan(tenTK);
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void btnTimKiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = CheckForm(typeof(TimKiem));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                TimKiem fr = new TimKiem();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void ManHinhChinh_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            toolStripStatusLabelTK.Text = "Nhân viên: " + NhanSu_BUS.LayNS(ThanhToan_BUS.MaNS(tenTK)).Rows[0][0] + "  -----  Chức vụ: " + NhanSu_BUS.LayNS(ThanhToan_BUS.MaNS(tenTK)).Rows[0][1];
            if(NhanSu_BUS.LayNS(ThanhToan_BUS.MaNS(tenTK)).Rows[0][1].ToString() == "Nhân viên")
            {
                rbBaoCao.Visible = false;
                rpgNhapHang.Visible = false;
                rbpMatHang.Visible = false;
                rbpNhaCungCap.Visible = false;
                rbpNhanSu.Visible = false;
                rbpDonDatHang.Visible = false;
            }
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult warning = XtraMessageBox.Show("Bạn thật sự muốn đăng xuất ?", "Lưu ý!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (warning == DialogResult.Yes)
            {
                this.Close();
                Application.Restart();
            }
        }

        private void ManHinhChinh_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string s = "Hôm nay là ngày  " + DateTime.Now.ToString("dd/MM/yyyy") + "  -  Bây giờ là  " + DateTime.Now.ToString("hh:mm:ss tt");
            toolStripStatusLabelTime.Text = s;
        }

        private void btnNhapHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = CheckForm(typeof(NhapHang));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                NhapHang fr = new NhapHang(tenTK);
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void btnDoanhThu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = CheckForm(typeof(BaoCaoDoanhThu));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                BaoCaoDoanhThu fr = new BaoCaoDoanhThu();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void btnThongKeMH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = CheckForm(typeof(ThongKeMatHang));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                ThongKeMatHang fr = new ThongKeMatHang();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void btnHoTro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {         
            Hotro = false;
            hotro();
        }
        public void hotro()
        {
            GioiThieu fr = new GioiThieu();
            fr.ShowDialog();
        }
    }
}
