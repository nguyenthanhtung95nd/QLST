using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DTO;
using DAO;

namespace BUS
{
    public class KhachHang_BUS
    {
        public static DataTable LoadDataKH()
        {
            return KhachHang_DAO.LoadData();
        }
        public static void ThemKH(KhachHang_DTO kh)
        {
            KhachHang_DAO.Them(kh);
        }
        public static void XoaKH(string ma)
        {
            KhachHang_DAO.Xoa(ma);
        }
        public static void SuaKH(KhachHang_DTO kh)
        {
            KhachHang_DAO.Sua(kh);}
    }
}
