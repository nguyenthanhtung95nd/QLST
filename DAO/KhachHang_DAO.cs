using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using DTO;

namespace DAO
{
    public class KhachHang_DAO
    {

        public static DataTable LoadData()
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT * FROM KHACHHANG";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static void Them(KhachHang_DTO kh)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlInsert = "INSERT INTO KHACHHANG VALUES(@MaKH,@TenKH,@DiaChi,@SDTKH,@DiemTL)";
            SqlCommand cmd = new SqlCommand(sqlInsert, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@MaKH", SqlDbType.VarChar, 10);
            cmd.Parameters.Add("@TenKH", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@SDTKH", SqlDbType.VarChar, 11);
            cmd.Parameters.Add("@DiemTL", SqlDbType.VarChar, 11);

            cmd.Parameters["@MaKH"].Value = kh.MaKH;
            cmd.Parameters["@TenKH"].Value = kh.TenKH;
            cmd.Parameters["@DiaChi"].Value = kh.DiaChi;
            cmd.Parameters["@SDTKH"].Value = kh.SDTKH;
            cmd.Parameters["@DiemTL"].Value = kh.DiemTL;

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void Xoa(string ma)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlDelete = "DELETE FROM KHACHHANG WHERE MaKH = @MaKH";
            SqlCommand cmd = new SqlCommand(sqlDelete, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@MaKH", SqlDbType.VarChar, 10);

            cmd.Parameters["@MaKH"].Value = ma;

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void Sua(KhachHang_DTO kh)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlUpdate = "UPDATE KHACHHANG SET TenKH=@TenKH, DiaChi=@DiaChi, SDTKH=@SDTKH WHERE MaKH = @MaKH";
            SqlCommand cmd = new SqlCommand(sqlUpdate, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@TenKH", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@SDTKH", SqlDbType.VarChar, 11);
            cmd.Parameters.Add("@MaKH", SqlDbType.VarChar, 11);

            cmd.Parameters["@TenKH"].Value = kh.TenKH;
            cmd.Parameters["@DiaChi"].Value = kh.DiaChi;
            cmd.Parameters["@SDTKH"].Value = kh.SDTKH;
            cmd.Parameters["@MaKH"].Value = kh.MaKH;

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmd.ExecuteNonQuery(); 
            conn.Close();
        }
    }
}
