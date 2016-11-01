using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class BaoCaoDoanhThu_DAO
    {
        public static DataTable DoanhThu()
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect =
                "SELECT TenMH,sum(GiaBan) as tongtgban,sum(SLMH*DonGiaMua) as tongtgmua,(sum(GiaBan)-sum(SLMH*DonGiaMua)) as loinhuan " +
                "FROM MATHANG m,HOADON h,CTHOADON cthd " +
                "WHERE m.MaMH=cthd.MaMH and h.SoHD=cthd.SoHD group by TenMH";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect,conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable DoanhThutheonam(int nam)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect =
                "SELECT TenMH,sum(SLMH*DonGiaMua) as tongtgmua,sum(SLMH*DonGiaBan) as tongtgban,(sum(SLMH*DonGiaBan)-sum(SLMH*DonGiaMua)) as loinhuan " +
                "FROM MATHANG m,HOADON h,CTHOADON cthd " +
                "WHERE m.MaMH=cthd.MaMH and h.SoHD=cthd.SoHD and year(ngaylaphd) = @nam group by TenMH";

            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@nam", SqlDbType.Int);
            cmd.Parameters["@nam"].Value = nam;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable DoanhThutheoThang(string thangnam)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect =
                "SELECT TenMH,sum(GiaBan) as tongtgban,sum(SLMH*DonGiaMua) as tongtgmua,(sum(GiaBan)-sum(SLMH*DonGiaMua)) as loinhuan " +
                "FROM MATHANG m,HOADON h,CTHOADON cthd " +
                "WHERE m.MaMH=cthd.MaMH and h.SoHD=cthd.SoHD and CONVERT(varchar, MONTH(NgayLapHD))+'/'+CONVERT(varchar,YEAR(NgayLapHD)) = '" + thangnam + "' group by TenMH";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect,conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable DoanhThuTheoNgay(string Ngaythangnam)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect =
                "SELECT TenMH,sum(GiaBan) as tongtgban,sum(SLMH*DonGiaMua) as tongtgmua,(sum(GiaBan)-sum(SLMH*DonGiaMua)) as loinhuan " +
                "FROM MATHANG m,HOADON h,CTHOADON cthd " +
                "WHERE m.MaMH=cthd.MaMH and h.SoHD=cthd.SoHD and CONVERT(varchar, NgayLapHD, 103) = '" + Ngaythangnam + "' group by TenMH";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
       
    }
}
