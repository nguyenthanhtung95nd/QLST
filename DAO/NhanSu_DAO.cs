using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
using System.Configuration;

namespace DAO
{
    public class NhanSu
    {

        public static DataTable LayNS(string manv)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT HoTenNS,ChucVu FROM NHANSU Where MaNS = '"+manv+"'";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable LoadData()
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT N.MaNS,HoTenNS,SDTNS,DCNS,ChucVu,TenTK,MatKhau FROM NHANSU N, TAIKHOAN T Where N.MaNS = T.MaNS";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static void Them(NhanSu_DTO nv , TaiKhoanDTO tk)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlInsertNS = "INSERT INTO NHANSU VALUES(@MaNS,@HoTenNS,@SDTNS,@DCNS,@ChucVu)";
            SqlCommand cmd = new SqlCommand(sqlInsertNS, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@MaNS", SqlDbType.VarChar, 10); 
            cmd.Parameters.Add("@HoTenNS", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@SDTNS", SqlDbType.NVarChar, 11);
            cmd.Parameters.Add("@DCNS", SqlDbType.VarChar, 100);
            cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar, 50);

            cmd.Parameters["@MaNS"].Value = nv.MaNS;
            cmd.Parameters["@HoTenNS"].Value = nv.HoTenNS;
            cmd.Parameters["@SDTNS"].Value = nv.SDTNS;
            cmd.Parameters["@DCNS"].Value = nv.DCNS;
            cmd.Parameters["@ChucVu"].Value = nv.ChucVu;


           
            string sqlInsertTK = "INSERT INTO TAIKHOAN VALUES(@TenTk,@MatKhau,@MaNS)";
            SqlCommand cmdTK = new SqlCommand(sqlInsertTK, conn);
            cmdTK.CommandType = CommandType.Text;

            cmdTK.Parameters.Add("@TenTk", SqlDbType.VarChar, 10);
            cmdTK.Parameters.Add("@MatKhau", SqlDbType.VarChar, 32);
            cmdTK.Parameters.Add("@MaNS", SqlDbType.VarChar, 11);
            cmdTK.Parameters["@TenTk"].Value = tk.Id;
            cmdTK.Parameters["@MatKhau"].Value = tk.Password;
            cmdTK.Parameters["@MaNS"].Value = tk.MaNS;

            if (conn.State == ConnectionState.Closed)conn.Open();
            cmd.ExecuteNonQuery();
            cmdTK.ExecuteNonQuery();
            conn.Close();
        }
        public static void Xoa(string ma)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlDelete = "DELETE FROM NHANSU WHERE MaNS = @MaNS";
            string sqlDeleteTK = "DELETE FROM TAIKHOAN WHERE MaNS = @MaNS";
            SqlCommand cmd = new SqlCommand(sqlDelete, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@MaNS", SqlDbType.VarChar, 10);

            cmd.Parameters["@MaNS"].Value = ma;

            SqlCommand cmdTK = new SqlCommand(sqlDeleteTK, conn);
            cmdTK.CommandType = CommandType.Text;

            cmdTK.Parameters.Add("@MaNS", SqlDbType.VarChar, 10);

            cmdTK.Parameters["@MaNS"].Value = ma;

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmdTK.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void Sua(NhanSu_DTO nv)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlUpdate = "UPDATE NHANSU SET HoTenNS=@HoTenNS, SDTNS=@SDTNS, DCNS=@DCNS, ChucVu=@ChucVu WHERE MaNS=@MaNS";
            SqlCommand cmd = new SqlCommand(sqlUpdate, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@HoTenNS", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@SDTNS", SqlDbType.VarChar, 11);
            cmd.Parameters.Add("@DCNS", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar, 11);
            cmd.Parameters.Add("@MaNS", SqlDbType.VarChar, 11);

            cmd.Parameters["@HoTenNS"].Value = nv.HoTenNS;
            cmd.Parameters["@SDTNS"].Value = nv.SDTNS;
            cmd.Parameters["@DCNS"].Value = nv.DCNS;
            cmd.Parameters["@ChucVu"].Value = nv.ChucVu;
            cmd.Parameters["@MaNS"].Value = nv.MaNS;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmd.ExecuteNonQuery(); conn.Close();
        }
    }
}
