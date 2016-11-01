using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class HoaDon_DAO
    {
        public static DataTable LoadHoaDon()
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT SoHD,NgayLapHD,MaKH,HoTenNS,GiamGia,TongTriGia FROM HOADON H, NHANSU N WHERE H.MaNS = N.MaNS ORDER BY SoHD";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable LoadHoaDonTheoNgay(string ngay)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT SoHD,NgayLapHD,MaKH,HoTenNS,GiamGia,TongTriGia FROM HOADON H, NHANSU N WHERE H.MaNS = N.MaNS AND  CONVERT(varchar, NgayLapHD, 103) = '"+ ngay + "' ORDER BY SoHD";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static string LayKH(string makh)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT TenKH FROM KHACHHANG WHERE MaKH = '" +makh+"'";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return makh = Convert.ToString(dt.Rows[0][0]);
        }

        public static DataTable LoadChiTietHD(string sohd)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT C.MaMH,TenMH,SLMH,GiaBan FROM CTHOADON C, MATHANG M WHERE C.MaMH = M.MaMH AND SoHD = " + sohd;
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static void XoaHD(string sohd)
        {
            SqlConnection conn = DataAccess.ketNoi();
                //viet cau lenh sql 
            string sqldeleteHD = "DELETE FROM CTHOADON Where SoHD = @SoHD ; DELETE FROM HOADON Where SoHD = @SoHD";
            SqlCommand cmdHD = new SqlCommand(sqldeleteHD, conn);
            cmdHD.CommandType = CommandType.Text;
            cmdHD.Parameters.Add("@SoHD", SqlDbType.VarChar, 10);
            cmdHD.Parameters["@SoHD"].Value = sohd;

            //thuc hien cau lenh sql

            if (conn.State == ConnectionState.Closed)
                conn.Open();cmdHD.ExecuteNonQuery();
            conn.Close();
        }
    }
}
