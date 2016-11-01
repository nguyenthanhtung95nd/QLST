using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAO;

namespace BUS
{
    public class HoaDon_BUS
    {
        public static DataTable LoadHoaDon()
        {
            return HoaDon_DAO.LoadHoaDon();
        }

        //Lấy tên khách hàng
        public static string LayKH(string makh)
        {
            return HoaDon_DAO.LayKH(makh);
        }

        public static DataTable LoadChiTietHD(string sohd)
        {
            return HoaDon_DAO.LoadChiTietHD(sohd);
        }

        public static DataTable LoadHDTheoNgay(string ngay)
        {
            return HoaDon_DAO.LoadHoaDonTheoNgay(ngay);
        }

        public static void XoaHD(string sohd)
        {
            HoaDon_DAO.XoaHD(sohd);
        }     
    }
}
