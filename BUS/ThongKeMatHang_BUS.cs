using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using System.Data;

namespace BUS
{
    public class ThongKeMatHang_BUS
    {
        public static DataTable HangTonKho()
        {
            return ThongKeMatHang_DAO.HangTonKho();
        }

        public static DataTable HangBanChayNgay(string ngaythangnam)
        {
            return ThongKeMatHang_DAO.HangBanChayNgay(ngaythangnam);
        }

        public static DataTable HangBanChayThang(string thangnam)
        {
            return ThongKeMatHang_DAO.HangBanChayThang(thangnam);
        }

        public static DataTable HangBanChayNam(int nam)
        {
            return ThongKeMatHang_DAO.HangBanChayNam(nam);
        }
    }
}
