using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public class ThanhToan_DAO
    {
        public  static DataTable LoadMH()
        {
            //Lấy dữ liệ mặt hàng
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT * FROM MATHANG ORDER BY MaMH";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //Lấy thông tin khách hàng
        public static DataTable LoadKH()
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT * FROM KHACHHANG ORDER BY MaKH";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        //Thực hiện cộng điểm cho khách hàng có đăng ký
        public static void CongDiemKH(string diem, string MaKH)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string UpdateDiem = string.Format("UPDATE KHACHHANG SET DiemTL = DiemTL + {0} where MaKH = '{1}'", diem,MaKH);
            SqlCommand sqldiem = new SqlCommand(UpdateDiem, conn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            sqldiem.ExecuteNonQuery();
            conn.Close();
        }

        //Tạo hóa đơn

        public static void ThemHoaDon(HoaDon_DTO hd)
        {       
            SqlConnection conn = DataAccess.ketNoi();
            string sqlInsertHD = "INSERT INTO HOADON VALUES(GETDATE(),"+hd.MaKH+",@MaNS,@GiamGia,@TongTriGia)";
            SqlCommand cmdHD = new SqlCommand(sqlInsertHD, conn);
            cmdHD.CommandType = CommandType.Text;

            

            cmdHD.Parameters.Add("@MaNS", SqlDbType.VarChar, 10);
            cmdHD.Parameters.Add("@GiamGia", SqlDbType.VarChar, 4);
            cmdHD.Parameters.Add("@TongTriGia", SqlDbType.VarChar, 11);

            

            cmdHD.Parameters["@MaNS"].Value = hd.MaNS;
            cmdHD.Parameters["@GiamGia"].Value = hd.GiamGia;
            cmdHD.Parameters["@TongTriGia"].Value = hd.TongTriGia;

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmdHD.ExecuteNonQuery();
            conn.Close();
        }

        public static string LaySoHD()
        {
            SqlConnection conn = DataAccess.ketNoi();
            string Hoadon = "SELECT * From HOADON";
            SqlDataAdapter daHD = new SqlDataAdapter(Hoadon, conn);
            DataTable dtHD = new DataTable();
            daHD.Fill(dtHD);
            return dtHD.Rows[dtHD.Rows.Count - 1][0].ToString();
        }


        //Chi tiết hóa đơn
        public static void ThemCTHD(ChiTietHD_DTO CT)
        {          
            SqlConnection conn = DataAccess.ketNoi();
            string sqlInsertCTHD = "INSERT INTO CTHOADON VALUES(@SoHD,@MaMH,@SLMH,@GiaBan) ; UPDATE MATHANG SET SLT = SLT - @SLMH WHERE MaMH = @MaMH";
            SqlCommand cmd = new SqlCommand(sqlInsertCTHD, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@SoHD", SqlDbType.VarChar, 10);
            cmd.Parameters.Add("@MaMH", SqlDbType.VarChar, 10);
            cmd.Parameters.Add("@SLMH", SqlDbType.VarChar, 5);
            cmd.Parameters.Add("@GiaBan", SqlDbType.VarChar, 11);

            cmd.Parameters["@SoHD"].Value = CT.SoHD;
            cmd.Parameters["@MaMH"].Value = CT.MaMH;
            cmd.Parameters["@SLMH"].Value = CT.SLMH;
            cmd.Parameters["@GiaBan"].Value = CT.GiaBan;

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Lấy mã của nhân viên đăng nhập
        public static string MaNS(string mans)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT * FROM TAIKHOAN WHERE TenTK = '" + mans +"'";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            mans = dt.Rows[0][2].ToString();
            return mans;
        }
    }
}
