using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAO;

namespace BUS
{
    public class DonDatHang_BUS
    {
        public static DataTable LoadDonDatHang()
        {
            return DonDatHang_DAO.LoadDonDatHang();
        }

        public static DataTable LoadChiTietDonDatHang(string soddh)
        {
            return DonDatHang_DAO.LoadChiTietDonDatHang(soddh);
        }

        public static DataTable LoadDonDatHangTheoNgay(string ngay)
        {
            return DonDatHang_DAO.LoadHoaDonTheoNgay(ngay);
        }

        public static void XoaDDH(string soddh)
        {
            DonDatHang_DAO.XoaDDH(soddh);
        }     
    }
}
