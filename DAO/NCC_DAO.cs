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
    public class NCC_DAO
    {
        public static SqlConnection KetNoi()
        {
            string connstr = ConfigurationManager.ConnectionStrings["CKN"].ConnectionString;
            return new SqlConnection(connstr);
        }

    }

    public class NCC
    {

        public static DataTable LoadData()
        {
            SqlConnection conn = NCC_DAO.KetNoi();
            string sqlSelect = "SELECT * FROM NHACUNGCAP";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static void Them(NCC_DTO ncc)
        {
            SqlConnection conn = NCC_DAO.KetNoi();
            string sqlInsert = "INSERT INTO NHACUNGCAP VALUES(@MaNCC,@TenNCC,@DCNCC,@SDTNCC)";
            SqlCommand cmd = new SqlCommand(sqlInsert, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@MaNCC", SqlDbType.VarChar, 10);
            cmd.Parameters.Add("@TenNCC", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@DCNCC", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@SDTNCC", SqlDbType.VarChar, 11);

            cmd.Parameters["@MaNCC"].Value = ncc.MaNCC;
            cmd.Parameters["@TenNCC"].Value = ncc.TenNCC;
            cmd.Parameters["@DCNCC"].Value = ncc.DCNCC;
            cmd.Parameters["@SDTNCC"].Value = ncc.SDTNCC;

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void Xoa(string ma)
        {
            SqlConnection conn = NCC_DAO.KetNoi();
            string sqlDelete = "DELETE FROM NHACUNGCAP WHERE MaNCC = @MaNCC";
            SqlCommand cmd = new SqlCommand(sqlDelete, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@MaNCC", SqlDbType.VarChar, 10);

            cmd.Parameters["@MaNCC"].Value = ma;

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void Sua(NCC_DTO ncc)
        {
            SqlConnection conn = NCC_DAO.KetNoi();
            string sqlUpdate = "UPDATE NHACUNGCAP SET TenNCC=@TenNCC, DCNCC=@DCNCC, SDTNCC=@SDTNCC WHERE MaNCC=@MaNCC";
            SqlCommand cmd = new SqlCommand(sqlUpdate, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@TenNCC", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@DCNCC", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@SDTNCC", SqlDbType.VarChar, 11);
            cmd.Parameters.Add("@MaNCC", SqlDbType.VarChar, 11);

            cmd.Parameters["@TenNCC"].Value = ncc.TenNCC;
            cmd.Parameters["@DCNCC"].Value = ncc.DCNCC;
            cmd.Parameters["@SDTNCC"].Value = ncc.SDTNCC;
            cmd.Parameters["@MaNCC"].Value = ncc.MaNCC;

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmd.ExecuteNonQuery();conn.Close();
        }
    }
}