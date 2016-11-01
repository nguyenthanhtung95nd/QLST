using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class ThongKeMatHang_DAO
    {

        public static DataTable HangTonKho()
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect =
                "SELECT TenMH,QuyCach,DonGiaMua,DonGiaBan,SLT,TenNCC FROM MATHANG M, NHACUNGCAP N WHERE M.MaNCC = N.MaNCC AND SLT > 0";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable HangBanChayNgay(string ngaythangnam)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect =
                "SELECT TenMH,QuyCach,DonGiaBan,SUM(SLMH)SoLuongBan,TenNCC " +
                "FROM MATHANG M, NHACUNGCAP N,HOADON H, CTHOADON C " +
                "WHERE M.MaNCC = N.MaNCC AND M.MaMH = C.MaMH AND H.SoHD = C.SoHD AND CONVERT(varchar, NgayLapHD, 103) = '" + ngaythangnam +
                "' GROUP BY TenMH,QuyCach,DonGiaBan,TenNCC " +
                "HAVING SUM(SLMH)>=10";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable HangBanChayThang(string thangnam)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect =
                "SELECT TenMH,QuyCach,DonGiaBan,SUM(SLMH)SoLuongBan,TenNCC " +
                "FROM MATHANG M, NHACUNGCAP N,HOADON H, CTHOADON C " +
                "WHERE M.MaNCC = N.MaNCC AND M.MaMH = C.MaMH AND H.SoHD = C.SoHD AND CONVERT(varchar, MONTH(NgayLapHD))+'/'+CONVERT(varchar,YEAR(NgayLapHD)) = '" + thangnam +
                "' GROUP BY TenMH,QuyCach,DonGiaBan,TenNCC " +
                "HAVING SUM(SLMH)>=50";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable HangBanChayNam(int nam)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect =
                "SELECT TenMH,QuyCach,DonGiaBan,SUM(SLMH)SoLuongBan,TenNCC " +
                "FROM MATHANG M, NHACUNGCAP N,HOADON H, CTHOADON C " +
                "WHERE M.MaNCC = N.MaNCC AND M.MaMH = C.MaMH AND H.SoHD = C.SoHD AND YEAR(NgayLapHD) = "+nam+
                "GROUP BY TenMH,QuyCach,DonGiaBan,TenNCC " +
                "HAVING SUM(SLMH)>=100";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
