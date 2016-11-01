using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAO;
using DTO;
using System.Data;

namespace BUS
{
    public class TimKiemBUS
    {
        #region Danh sách mặt hàng
        public static DataTable loadDataMH()
        {
            return TimKiemDAO.loadDanhSachMH();
        }
        public static DataTable timTheoMaMH(string maMH)
        {
            return TimKiemDAO.timKiemTheoMaMH(maMH);
        }
        public static DataTable timTheoTenMH(string tenMH)
        {
            return TimKiemDAO.timKiemTheoTenMH(tenMH);
        }
        public static DataTable timTheoSLT(int SLT)
        {
            return TimKiemDAO.timKiemTheoSLT(SLT);
        }
        #endregion

        #region Danh sách nhân sự
        public static DataTable loadDataNS()
        {
            return TimKiemDAO.loadDanhSachNS();
        }
        public static DataTable timTheoMaNS(string maNS)
        {
            return TimKiemDAO.timKiemTheoMaNS(maNS);
        }
        public static DataTable timTheoTenNS(string tenNS)
        {
            return TimKiemDAO.timKiemTheoTenNS(tenNS);
        }
        public static DataTable timTheoDCNS(string dcNS)
        {
            return TimKiemDAO.timKiemTheoDCNS(dcNS);
        }
        public static DataTable timTheoSDTNS(string sdtNS)
        {
            return TimKiemDAO.timKiemTheoSDTNS(sdtNS);
        }
        #endregion

        #region Danh sách nhà cung cấp
        public static DataTable loadDataNCC()
        {
            return TimKiemDAO.loadDanhSachNCC();
        }
        public static DataTable timTheoMaNCC(string maNCC)
        {
            return TimKiemDAO.timKiemTheoMaNCC(maNCC);
        }
        public static DataTable timTheoTenNCC(string tenNCC)
        {
            return TimKiemDAO.timKiemTheoTenNCC(tenNCC);
        }
        public static DataTable timTheoDCNCC(string dcNCC)
        {
            return TimKiemDAO.timKiemTheoDCNCC(dcNCC);
        }
        public static DataTable timTheoSDTNCC(string sdtNCC)
        {
            return TimKiemDAO.timKiemTheoSDTNCC(sdtNCC);
        }
        #endregion

        #region Danh sách khách hàng
        public static DataTable loadDataKH()
        {
            return TimKiemDAO.loadDanhSachKH();
        }
        public static DataTable timTheoMaKH(string maKH)
        {
            return TimKiemDAO.timKiemTheoMaKH(maKH);
        }
        public static DataTable timTheoTenKH(string tenKH)
        {
            return TimKiemDAO.timKiemTheoTenKH(tenKH);
        }
        public static DataTable timTheoDCKH(string dcKH)
        {
            return TimKiemDAO.timKiemTheoDCKH(dcKH);
        }
        public static DataTable timTheoSDTKH(string sdtKH)
        {
            return TimKiemDAO.timKiemTheoSDTKH(sdtKH);
        }
        public static DataTable timTheoDTL(int diemTL)
        {
            return TimKiemDAO.timKiemTheoDTL(diemTL);
        }
        #endregion
    }
}
