using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class MatHang_DAO
    {
        public static DataTable LoadData()
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT MaMH, TenMH,QuyCach,TenNCC, DonGiaMua, DonGiaBan, SLT, KM, M.MaNCC FROM MATHANG M,NHACUNGCAP N WHERE M.MaNCC = N.MaNCC";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable LoadDataNCC()
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlSelect = "SELECT * from NHACUNGCAP ";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            DataTable dtNCC = new DataTable();
            da.Fill(dtNCC);
            return dtNCC;
        }
        public static void Xoa(string ma)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlDelete = "DELETE FROM MATHANG WHERE MaMH = @MaMH";
            SqlCommand cmd = new SqlCommand(sqlDelete, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@MaMH", SqlDbType.VarChar, 10);
            cmd.Parameters["@MaMH"].Value = ma;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void Sua(MatHang_DTO mh)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlUpdate = "UPDATE MATHANG SET TenMH=@TenMH, QuyCach=@QuyCach,MaNCC=@MaNCC ,DonGiaMua =@DonGiaMua,DonGiaBan=@DonGiaBan, SLT=@SLT,KM=@KM WHERE MaMH = @MaMH";
            SqlCommand cmd = new SqlCommand(sqlUpdate, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@TenMH", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@QuyCach", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@MaNCC", SqlDbType.VarChar, 10);
            cmd.Parameters.Add("@DonGiaMua", SqlDbType.VarChar, 11);
            cmd.Parameters.Add("@DonGiaBan", SqlDbType.VarChar, 11);
            cmd.Parameters.Add("@SLT", SqlDbType.VarChar, 11);
            cmd.Parameters.Add("@KM", SqlDbType.VarChar, 11);
            cmd.Parameters.Add("@MaMH", SqlDbType.VarChar, 10);

            cmd.Parameters["@TenMH"].Value = mh.TenMH;
            cmd.Parameters["@QuyCach"].Value = mh.QuyCach;
            cmd.Parameters["@MaNCC"].Value = mh.MaNCC;
            cmd.Parameters["@DonGiaMua"].Value = mh.DonGiaMua;
            cmd.Parameters["@DonGiaBan"].Value = mh.DonGiaBan;
            cmd.Parameters["@SLT"].Value = mh.SLT;
            cmd.Parameters["@KM"].Value = mh.KM;
            cmd.Parameters["@MaMH"].Value = mh.MaMH;

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmd.ExecuteNonQuery(); conn.Close();
        }

        public static void Them(MatHang_DTO mh)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlInsert = "INSERT INTO MATHANG VALUES(@MaMH,@TenMH,@QUYCACH,@MANCC,@DonGiaMua,@DonGiaBan,@SLT,@KM)";
            SqlCommand cmd = new SqlCommand(sqlInsert, conn);
            cmd.CommandType = CommandType.Text;

            string sqlSelectMaNCC = "SELECT MaNCC FROM NHACUNGCAP WHERE TenNCC = '" + mh.MaNCC + "'";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelectMaNCC, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmd.Parameters.Add("@MaMH", SqlDbType.VarChar, 10);
            cmd.Parameters.Add("@TenMH", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@QuyCach", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@MaNCC", SqlDbType.VarChar, 10);
            cmd.Parameters.Add("@DonGiaMua", SqlDbType.VarChar, 11);
            cmd.Parameters.Add("@DonGiaBan", SqlDbType.VarChar, 11);
            cmd.Parameters.Add("@SLT", SqlDbType.VarChar, 11);
            cmd.Parameters.Add("@KM", SqlDbType.VarChar, 11);

            cmd.Parameters["@MaMH"].Value = mh.MaMH;
            cmd.Parameters["@TenMH"].Value = mh.TenMH;
            cmd.Parameters["@QuyCach"].Value = mh.QuyCach;
            cmd.Parameters["@MaNCC"].Value = mh.MaNCC;
            cmd.Parameters["@DonGiaMua"].Value = mh.DonGiaMua;
            cmd.Parameters["@DonGiaBan"].Value = mh.DonGiaBan;
            cmd.Parameters["@SLT"].Value = mh.SLT;
            cmd.Parameters["@KM"].Value = mh.KM;

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
