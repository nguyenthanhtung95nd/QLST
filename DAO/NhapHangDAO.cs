using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DTO;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class NhapHangDAO
    {
        public static DataTable loadDanhSachMH(string maNCC)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT * FROM MATHANG WHERE MANCC=@MA";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@MA", SqlDbType.Char, 5);
            cmd.Parameters["@MA"].Value = maNCC;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable loadDanhSachNCC()
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT * FROM NHACUNGCAP";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static string loadMaNS(string id)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT MANS FROM TAIKHOAN WHERE TENTK=@ID";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
            cmd.Parameters["@ID"].Value = id;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0][0].ToString();
        }
        public static string loadTenNS(string id)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT HOTENNS FROM NHANSU N, TAIKHOAN T WHERE N.MANS=T.MANS AND TENTK=@ID";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ID", SqlDbType.Char, 5);
            cmd.Parameters["@ID"].Value = id;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0][0].ToString();
        }
        public static void themDDH(DDH_DTO ddh)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlInsert = "SET DATEFORMAT DMY; INSERT INTO DONDATHANG(MANCC, NGAYLAPDON, MANS) VALUES(@MANCC,@NGAY,@MANS)";
            SqlCommand cmd = new SqlCommand(sqlInsert, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@MANCC", SqlDbType.Char, 5).Value = ddh.MaNCC;
            cmd.Parameters.Add("@NGAY", SqlDbType.DateTime).Value = ddh.NgayLap;
            cmd.Parameters.Add("@MANS", SqlDbType.Char, 5).Value = ddh.MaNS;

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static int laySoDDH()
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlCount = "SELECT SODDH FROM DONDATHANG ORDER BY SODDH DESC";
            SqlDataAdapter daDDH = new SqlDataAdapter(sqlCount, conn);
            DataTable dtDDH = new DataTable();
            daDDH.Fill(dtDDH);
            int soDDH = Convert.ToInt32(dtDDH.Rows[0][0]);
            return soDDH;
        }
        public static void themCTDDH(ChiTietDDH_DTO ctddh)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlInsertCTHD = "SET DATEFORMAT DMY; INSERT INTO CTDONDATHANG VALUES(@SODDH, @MAMH, @SLDH, @DONGIA) ; UPDATE MATHANG SET SLT = SLT + @SLDH WHERE MAMH = @MAMH";
            SqlCommand cmd = new SqlCommand(sqlInsertCTHD, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@SODDH", SqlDbType.Int).Value = ctddh.SoDDH;
            cmd.Parameters.Add("@MAMH", SqlDbType.Char, 5).Value = ctddh.MaMH;
            cmd.Parameters.Add("@SLDH", SqlDbType.Int).Value = ctddh.SlDat;
            cmd.Parameters.Add("@DONGIA", SqlDbType.Int).Value = ctddh.DonGia;

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
