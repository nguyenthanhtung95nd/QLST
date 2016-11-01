using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class TaiKhoanDAO
    {
        #region Xử lý kiểm tra tài khoản hợp lệ
        public static int kiemTraTaiKhoan(string account, string pwd)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlkt = "SELECT * FROM TAIKHOAN WHERE TenTK = '" + account + "' AND MatKhau = '" + pwd + "'";
            SqlCommand cmd = new SqlCommand(sqlkt, conn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read() == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region Xử lý cập nhật lại mật khẩu
        public static bool capNhatMatKhau(string account, string pwd)
        {
            SqlConnection conn = DataAccess.ketNoi();
            string sqlCapNhat = "UPDATE TAIKHOAN SET MatKhau='" + pwd + "' WHERE TenTK='" + account + "'";
            SqlCommand cmd = new SqlCommand(sqlCapNhat, conn);
            cmd.CommandType = CommandType.Text;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            int check = cmd.ExecuteNonQuery();
            conn.Close();
            if (check == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
