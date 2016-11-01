using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DonDatHang_DAO
    {
        public static DataTable LoadDonDatHang()
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT D.SoDDH,TenNCC,NgayLapDon,HoTenNS, SUM(SLDH*DonGia) AS'TongTriGia' " +
                               "FROM DONDATHANG D,NHACUNGCAP H, NHANSU N ,CTDONDATHANG C " +
                               "WHERE D.MaNS = N.MaNS AND D.MaNCC = H.MaNCC AND D.SoDDH = C.SoDDH " +
                               "GROUP BY D.SoDDH,TenNCC,NgayLapDon,HoTenNS " +
                               "ORDER BY SoDDH";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable LoadHoaDonTheoNgay(string ngay)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT D.SoDDH,TenNCC,NgayLapDon,HoTenNS, SUM(SLDH*DonGia) AS'TongTriGia' " +
                               "FROM DONDATHANG D,NHACUNGCAP H, NHANSU N ,CTDONDATHANG C " +
                               "WHERE D.MaNS = N.MaNS AND D.MaNCC = H.MaNCC AND D.SoDDH = C.SoDDH AND CONVERT(varchar, NgayLapDon, 103) = '"+ngay+"'" +
                               "GROUP BY D.SoDDH,TenNCC,NgayLapDon,HoTenNS " +
                               "ORDER BY SoDDH";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable LoadChiTietDonDatHang(string soddh)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT C.MaMH,TenMH,SLDH,DonGia FROM CTDONDATHANG C, MATHANG M WHERE C.MaMH = M.MaMH AND SoDDH = " + soddh;
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static void XoaDDH(string soddh)
        {
            SqlConnection conn = DataAccess.ketNoi();
           
            string sqldeleteHD = "DELETE FROM CTDONDATHANG Where SoDDH = @SoDDH ; DELETE FROM DONDATHANG Where SoDDH = @SoDDH";
            SqlCommand cmdHD = new SqlCommand(sqldeleteHD, conn);
            cmdHD.CommandType = CommandType.Text;
            cmdHD.Parameters.Add("@SoDDH", SqlDbType.VarChar, 10);
            cmdHD.Parameters["@SoDDH"].Value = soddh;

            if (conn.State == ConnectionState.Closed)
                conn.Open(); cmdHD.ExecuteNonQuery();
            conn.Close();
        }
    }
}
