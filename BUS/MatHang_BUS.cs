using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using DTO;
using System.Data;

namespace BUS
{
    public class MatHang_BUS
    {
        public static DataTable LoadDataMH()
        {
            return MatHang_DAO.LoadData();
        }
        public static DataTable LoadDataNCC()
        {
            return MatHang_DAO.LoadDataNCC();
        }

        public static void XoaMH(string ma)
        {
            MatHang_DAO.Xoa(ma);
        }
        public static void SuaMH(MatHang_DTO mh)
        {
            MatHang_DAO.Sua(mh);
        }
        public static void ThemMH(MatHang_DTO mh)
        {
            MatHang_DAO.Them(mh);
        }
    }
}
