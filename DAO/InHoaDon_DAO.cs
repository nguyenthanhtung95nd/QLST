using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class InHoaDon_DAO
    {
        public static DataTable ThongTinHoaDon(string sohd)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT CONVERT(varchar, NgayLapHD, 103) AS'Ngay',MaKH,HoTenNS,GiamGia,TongTriGia FROM HOADON H, NHANSU N WHERE H.MaNS = N.MaNS AND SoHD = '" + sohd + "'";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable InChiTietHoaDon(string sohd)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT TenMH AS N'Tên mặt hàng',QuyCach AS N'Quy cách',SLMH AS N'Số lượng mua',GiaBan AS N'Đơn Giá' FROM CTHOADON C, MATHANG M WHERE C.MaMH = M.MaMH AND C.SoHD = '" + sohd + "'";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static string TenKH(string maKH)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT TenKH FROM KHACHHANG WHERE MaKH = '"+maKH+"'";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0][0].ToString();
        }
    }
}
