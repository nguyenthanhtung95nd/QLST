using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DTO;
using DAO;
namespace BUS
{
    public class ThanhToan_BUS
    {

        public static string MaNS(string mans)
        {
            return ThanhToan_DAO.MaNS(mans);
        }

        public static DataTable loaddtOrder(DataTable tbOrder)
        {
            tbOrder = new DataTable("Order");
            tbOrder.Columns.Add("MaMH");
            tbOrder.Columns.Add("TenMH");
            tbOrder.Columns.Add("SL");
            tbOrder.Columns.Add("QuyCach");
            tbOrder.Columns.Add("DonGiaBan");
            tbOrder.Columns.Add("KM");
            tbOrder.Columns.Add("DonGia");            
            tbOrder.PrimaryKey = new DataColumn[] { tbOrder.Columns[0] };
            return tbOrder;
        }

        public static DataTable Them(int masomh, int SL, DataTable tb)
        {
            
                int giaban = 0, soluong = 0;
                string mamh = "";
                giaban = Convert.ToInt32(ThanhToan_DAO.LoadMH().Rows[masomh][5].ToString());
                soluong = Convert.ToInt32(ThanhToan_DAO.LoadMH().Rows[masomh][6].ToString());
                mamh = ThanhToan_DAO.LoadMH().Rows[masomh][0].ToString();
                DataRow r = tb.Rows.Find(mamh);


                if (r == null)// Nếu trong bảng dtOrder chưa có hàng hóa đang chọn thì tạo một dòng mới cho hàng hóa
                {                   
                        r = tb.NewRow();
                        r[0] = mamh;
                        r[1] = ThanhToan_DAO.LoadMH().Rows[masomh][1].ToString();
                        r[2] = SL;
                        r[3] = ThanhToan_DAO.LoadMH().Rows[masomh][2].ToString();
                        r[4] = giaban;
                        r[5] = ThanhToan_DAO.LoadMH().Rows[masomh][7];
                        r[6] = (float)SL * ((float)giaban - (float)giaban * ((float)Convert.ToDouble(ThanhToan_DAO.LoadMH().Rows[masomh][7])/(float)100));
                        
                        tb.Rows.Add(r);
                }
                else// Nếu trong bảng dtOrder đã có hàng hóa đang chọn thì chỉ tăng số lượng và tính lại giá bán cho hàng hóa đó
                {
                    int quantity = int.Parse(r[2].ToString()) + SL;                 
                    r[2] = quantity;
                    r[6] = (float)quantity * ((float)giaban - (float)giaban * ((float)Convert.ToDouble(ThanhToan_DAO.LoadMH().Rows[masomh][7]) / (float)100));               
                }
                return tb;          
        }

        public static DataTable LoadMH()
        {
            return ThanhToan_DAO.LoadMH();
        }

        public static  DataTable LoadKH()
        {
            return ThanhToan_DAO.LoadKH();
        }

        public static string TinhTien(DataTable dt , string giamgia)
        {
            float tongtien = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tongtien = tongtien + (float)Convert.ToDouble(dt.Rows[i][6].ToString());
            }

            if (giamgia != "")
            {
                tongtien = tongtien - (tongtien*((float) Convert.ToDouble(giamgia)/100));
            }
            return String.Format("{0:0}", tongtien);
        }

        public static bool ThanhToan(string tongtien, string giamgia, string makh,string mans, DataTable dt)
        {
            try
            {
                int diem = Convert.ToInt32(tongtien)/10000;

                if (makh != "NULL")
                {
                    ThanhToan_DAO.CongDiemKH(Convert.ToString(diem), makh);
                    makh = "'" + makh + "'";
                }

                HoaDon_DTO HD = new HoaDon_DTO(makh, mans, giamgia, tongtien);

                ThanhToan_DAO.ThemHoaDon(HD);

                string sohd = ThanhToan_DAO.LaySoHD();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ChiTietHD_DTO ct = new ChiTietHD_DTO(sohd, dt.Rows[i][0].ToString(), dt.Rows[i][2].ToString(),
                                                         dt.Rows[i][6].ToString());
                    ThanhToan_DAO.ThemCTHD(ct);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public static string LaySoHD()
        {
            return ThanhToan_DAO.LaySoHD();
        }
    }
}
