using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using System.Data;

namespace BUS
{
    public class BaoCaoDoanhThu_BUS
    {

        public static DataTable DoanhThu()
        {
            return BaoCaoDoanhThu_DAO.DoanhThu();
        }

        public static DataTable DoanhThuTheoNgay(string Ngaythangnam)
        {
            return BaoCaoDoanhThu_DAO.DoanhThuTheoNgay(Ngaythangnam);
        }

        public static DataTable DoanhThuTheoThang(string thangnam)
        {
            return BaoCaoDoanhThu_DAO.DoanhThutheoThang(thangnam);
        }
        
        public static DataTable DoanhThuTheoNam(int nam)
        {
            return BaoCaoDoanhThu_DAO.DoanhThutheonam(nam);
        }


    }
}
