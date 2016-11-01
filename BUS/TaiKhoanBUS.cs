using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAO;
using DTO;
using System.Data;
using System.Security.Cryptography;

namespace BUS
{
    public class TaiKhoanBUS
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
        public static int kTraTaiKhoan(string acc, string pw)
        {
            return TaiKhoanDAO.kiemTraTaiKhoan(acc, taoChuoiMD5(pw));
        }
        public static bool cNhatMatKhau(string acc, string pw)
        {
            return TaiKhoanDAO.capNhatMatKhau(acc, taoChuoiMD5(pw));
        }
    }
}
