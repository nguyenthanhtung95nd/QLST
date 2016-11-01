using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class TimKiemDAO
    {
        #region Tìm kiếm trong danh sách mặt hàng
        public static DataTable loadDanhSachMH()
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT MAMH, TENMH, SLT FROM MATHANG";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable timKiemTheoMaMH(string maMH)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSearch = "SELECT MAMH, TENMH, SLT FROM MATHANG WHERE MAMH LIKE @MA";
            SqlCommand cmd = new SqlCommand(sqlSearch, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@MA", SqlDbType.Char, 5);
            cmd.Parameters["@MA"].Value = maMH;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable timKiemTheoTenMH(string tenMH)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSearch = "SELECT MAMH, TENMH, SLT FROM MATHANG WHERE TENMH LIKE @TEN";
            SqlCommand cmd = new SqlCommand(sqlSearch, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@TEN", SqlDbType.NVarChar, 30);
            cmd.Parameters["@TEN"].Value = "%" + tenMH + "%";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable timKiemTheoSLT(int slt)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSearch = "SELECT MAMH, TENMH, SLT FROM MATHANG WHERE SLT = @SL";
            SqlCommand cmd = new SqlCommand(sqlSearch, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@SL", SqlDbType.Int);
            cmd.Parameters["@SL"].Value = slt;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        #endregion

        #region Tìm kiếm trong danh sách nhân sự
        public static DataTable loadDanhSachNS()
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT MANS, HOTENNS, DCNS, SDTNS FROM NHANSU";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable timKiemTheoMaNS(string maNS)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSearch = "SELECT MANS, HOTENNS, DCNS, SDTNS FROM NHANSU WHERE MANS LIKE @MA";
            SqlCommand cmd = new SqlCommand(sqlSearch, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@MA", SqlDbType.Char, 5);
            cmd.Parameters["@MA"].Value = maNS;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable timKiemTheoTenNS(string tenNS)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSearch = "SELECT MANS, HOTENNS, DCNS, SDTNS FROM NHANSU WHERE HOTENNS LIKE @TEN";
            SqlCommand cmd = new SqlCommand(sqlSearch, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@TEN", SqlDbType.NVarChar, 30);
            cmd.Parameters["@TEN"].Value = "%" + tenNS + "%";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable timKiemTheoSDTNS(string sdt)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSearch = "SELECT MANS, HOTENNS, DCNS, SDTNS FROM NHANSU WHERE SDTNS LIKE @SDT";
            SqlCommand cmd = new SqlCommand(sqlSearch, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@SDT", SqlDbType.VarChar, 11);
            cmd.Parameters["@SDT"].Value = "%" + sdt + "%";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable timKiemTheoDCNS(string dc)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSearch = "SELECT MANS, HOTENNS, DCNS, SDTNS FROM NHANSU WHERE DCNS LIKE @DC";
            SqlCommand cmd = new SqlCommand(sqlSearch, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@DC", SqlDbType.NVarChar, 50);
            cmd.Parameters["@DC"].Value = "%" + dc + "%";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        #endregion

        #region Tìm kiếm trong danh sách nhà cung cấp
        public static DataTable loadDanhSachNCC()
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT MANCC, TENNCC, DCNCC, SDTNCC FROM NHACUNGCAP";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable timKiemTheoMaNCC(string maNCC)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSearch = "SELECT MANCC, TENNCC, DCNCC, SDTNCC FROM NHACUNGCAP WHERE MANCC LIKE @MA";
            SqlCommand cmd = new SqlCommand(sqlSearch, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@MA", SqlDbType.Char, 5);
            cmd.Parameters["@MA"].Value = maNCC;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable timKiemTheoTenNCC(string tenNCC)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSearch = "SELECT MANCC, TENNCC, DCNCC, SDTNCC FROM NHACUNGCAP WHERE TENNCC LIKE @TEN";
            SqlCommand cmd = new SqlCommand(sqlSearch, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@TEN", SqlDbType.NVarChar, 30);
            cmd.Parameters["@TEN"].Value = "%" + tenNCC + "%";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable timKiemTheoSDTNCC(string sdt)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSearch = "SELECT MANCC, TENNCC, DCNCC, SDTNCC FROM NHACUNGCAP WHERE SDTNCC LIKE @SDT";
            SqlCommand cmd = new SqlCommand(sqlSearch, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@SDT", SqlDbType.VarChar, 11);
            cmd.Parameters["@SDT"].Value = "%" + sdt + "%";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable timKiemTheoDCNCC(string dc)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSearch = "SELECT MANCC, TENNCC, DCNCC, SDTNCC FROM NHACUNGCAP WHERE DCNCC LIKE @DC";
            SqlCommand cmd = new SqlCommand(sqlSearch, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@DC", SqlDbType.NVarChar, 50);
            cmd.Parameters["@DC"].Value = "%" + dc + "%";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        #endregion

        #region Tìm kiếm trong danh sách khách hàng
        public static DataTable loadDanhSachKH()
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT MAKH, TENKH, DIACHI, SDTKH, DIEMTL FROM KHACHHANG";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable timKiemTheoMaKH(string maKH)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSearch = "SELECT MAKH, TENKH, DIACHI, SDTKH, DIEMTL FROM KHACHHANG WHERE MAKH LIKE @MA";
            SqlCommand cmd = new SqlCommand(sqlSearch, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@MA", SqlDbType.Char, 5);
            cmd.Parameters["@MA"].Value = maKH;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable timKiemTheoTenKH(string tenKH)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSearch = "SELECT MAKH, TENKH, DIACHI, SDTKH, DIEMTL FROM KHACHHANG WHERE TENKH LIKE @TEN";
            SqlCommand cmd = new SqlCommand(sqlSearch, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@TEN", SqlDbType.NVarChar, 30);
            cmd.Parameters["@TEN"].Value = "%" + tenKH + "%";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable timKiemTheoSDTKH(string sdt)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSearch = "SELECT MAKH, TENKH, DIACHI, SDTKH, DIEMTL FROM KHACHHANG WHERE SDTKH LIKE @SDT";
            SqlCommand cmd = new SqlCommand(sqlSearch, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@SDT", SqlDbType.VarChar, 11);
            cmd.Parameters["@SDT"].Value = "%" + sdt + "%";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable timKiemTheoDCKH(string dc)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSearch = "SELECT MAKH, TENKH, DIACHI, SDTKH, DIEMTL FROM KHACHHANG WHERE DIACHI LIKE @DC";
            SqlCommand cmd = new SqlCommand(sqlSearch, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@DC", SqlDbType.NVarChar, 50);
            cmd.Parameters["@DC"].Value = "%" + dc + "%";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable timKiemTheoDTL(int diem)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSearch = "SELECT MAKH, TENKH, DIACHI, SDTKH, DIEMTL FROM KHACHHANG WHERE DIEMTL = @DIEM";
            SqlCommand cmd = new SqlCommand(sqlSearch, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@DIEM", SqlDbType.Int);
            cmd.Parameters["@DIEM"].Value = diem;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        #endregion
    }
}
