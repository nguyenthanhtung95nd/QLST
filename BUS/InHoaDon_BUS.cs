using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;
using System.Data;
using DAO;

namespace BUS
{
    public class InHoaDon_BUS
    {

        //Sử lý xuất hóa đơn thành 1 file Excel
        public static void InHD(string sohd)
        {
            System.Data.DataTable TTHD = new System.Data.DataTable();
            System.Data.DataTable CTHD = new System.Data.DataTable();
            TTHD = InHoaDon_DAO.ThongTinHoaDon(sohd);
            CTHD = InHoaDon_DAO.InChiTietHoaDon(sohd);

            app hd = new app();
            hd.Application.Workbooks.Add(Type.Missing);
            hd.Columns.ColumnWidth = 15;

            hd.Cells[1, 1] = "SIÊU THỊ MINION MART";
            hd.Cells[2, 1] = "HÓA ĐƠN BÁN HÀNG";
            hd.Cells[3, 1] = "Số hóa đơn: " + sohd;
            hd.Cells[3, 2] = "Ngày: " + TTHD.Rows[0][0];
            hd.Cells[4, 1] = "Khách hàng: ";
            if(TTHD.Rows[0][1].ToString() != "")
            {
                hd.Cells[4, 1] = "Khách hàng: " + InHoaDon_DAO.TenKH(TTHD.Rows[0][1].ToString());
            }
            hd.Cells[5, 1] = "Nhân viên: " + TTHD.Rows[0][2];

            for (int i = 1; i <= CTHD.Columns.Count; i++)
            {
                hd.Cells[7, i] = CTHD.Columns[i - 1].ToString();
            }

            for (int i = 0; i < CTHD.Rows.Count; i++)
            {
                for (int j = 0; j < CTHD.Columns.Count; j++)
                {
                    hd.Cells[i + 8,j + 1] = CTHD.Rows[i][j];
                }
                if(i == CTHD.Rows.Count - 1)
                {
                    hd.Cells[i + 9, 3] = String.Format("{0,-10}", "Tổng Tiền");
                    hd.Cells[i + 9, 4] = "= SUM(D8:D"+(i+8)+")";
                    hd.Cells[i + 10, 1] = "Giảm giá hóa đơn: " + TTHD.Rows[0][3] + "%";
                    hd.Cells[i + 11, 1] = "THÀNH TIỀN : " + TTHD.Rows[0][4] + " vnđ";
                    hd.Cells[i + 13, 1] = "Xin Cảm Ơn Và Hẹn Gặp Lại Quý Khách!";
                }
            }

            string link = Environment.UserName;
            hd.ActiveWorkbook.SaveCopyAs(@"C:\Users\"+link+@"\Desktop\"+ "HoaDonSo" + sohd + ".xlsx");
            hd.ActiveWorkbook.Saved = true;   
            hd.Quit();
        }
    }
}
