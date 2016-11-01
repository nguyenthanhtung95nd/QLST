using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using DAO;
using DTO;

namespace BUS
{
    public class NhanSu_BUS
    {

        public static string taoChuoiMD5(string pw)
        {
            string chuoimd5 = "";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(pw);
            MD5CryptoServiceProvider mahoamd5 = new MD5CryptoServiceProvider();
            mang = mahoamd5.ComputeHash(mang);
            foreach (byte b in mang)
            {
                chuoimd5 += b.ToString("X2");
            }
            return chuoimd5;
        }
        public static DataTable LoadDataNS()
        {
            return NhanSu.LoadData();
        }
        public static void ThemNS(NhanSu_DTO ns, TaiKhoanDTO tk)
        {
            tk.Password = taoChuoiMD5(tk.Password);
            NhanSu.Them(ns,tk);
        }
        public static void XoaNS(string ma)
        {
            NhanSu.Xoa(ma);
        }
        public static void SuaNS(NhanSu_DTO ns)
        {
            NhanSu.Sua(ns);
        }

        public static DataTable LayNS(string manv)
        {
            return NhanSu.LayNS(manv);
        }
    }
}
