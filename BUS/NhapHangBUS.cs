using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAO;
using DTO;
using System.Data;

namespace BUS
{
    public class NhapHangBUS
    {
        public static DataTable loadDataMH(string maNC)
        {
            return NhapHangDAO.loadDanhSachMH(maNC);
        }
        public static DataTable loadDataNCC()
        {
            return NhapHangDAO.loadDanhSachNCC();
        }
        public static string loadMaNS(string id)
        {
            return NhapHangDAO.loadMaNS(id);
        }
        public static string loadHotenNS(string maNS)
        {
            return NhapHangDAO.loadTenNS(maNS);
        }
        public static DataTable loadDanhSachDH(DataTable bangDH)
        {
            bangDH = new DataTable("DH");
            bangDH.Columns.Add("MAMH");
            bangDH.Columns.Add("TENMH");
            bangDH.Columns.Add("QUYCACH");
            bangDH.Columns.Add("SLDH");
            bangDH.Columns.Add("DONGIA");
            bangDH.Columns.Add("TONGTRIGIA");
            bangDH.PrimaryKey = new DataColumn[] { bangDH.Columns[0] };
            return bangDH;
        }
        public static DataTable Them(int sttmaMH, int SLDH, int dongia, string maNCC, DataTable bangDH)
        {
            string maMH = NhapHangDAO.loadDanhSachMH(maNCC).Rows[sttmaMH][0].ToString();
            string tenMH = NhapHangDAO.loadDanhSachMH(maNCC).Rows[sttmaMH][1].ToString();
            string qc = NhapHangDAO.loadDanhSachMH(maNCC).Rows[sttmaMH][2].ToString();
            long tongGiaTien = Convert.ToInt64(NhapHangDAO.loadDanhSachMH(maNCC).Rows[sttmaMH][5]);
            DataRow r = bangDH.Rows.Find(maMH);

            if (r == null)
            {
                tongGiaTien = SLDH * dongia;
                r = bangDH.NewRow();
                r[0] = maMH;
                r[1] = tenMH;
                r[2] = qc;
                r[3] = SLDH;
                r[4] = dongia;               
                r[5] = tongGiaTien;

                bangDH.Rows.Add(r);
            }
            else
            {
                int TongSLDH = Convert.ToInt32(r[3]) + SLDH;
                r[3] = TongSLDH;
                r[4] = dongia;
                r[5] = TongSLDH*dongia;
            }
            return bangDH;
        }
        public static long tongTienDDH(DataTable bangDH)
        {
            long tongtien = 0;
            for (int i = 0; i < bangDH.Rows.Count; i++)
            {
                tongtien = tongtien + Convert.ToInt64(bangDH.Rows[i][5].ToString());
            }
            return tongtien;
        }
        public static bool thanhToanDDH(string maNCC, string ngay, string maNS, DataTable bangDH)
        {
            try
            {               
                DDH_DTO DDH = new DDH_DTO(maNCC, ngay, maNS);
                NhapHangDAO.themDDH(DDH);
                int sohd = NhapHangDAO.laySoDDH();
                for (int i = 0; i < bangDH.Rows.Count; i++)
                {
                    ChiTietDDH_DTO ctDDH = new ChiTietDDH_DTO(sohd, bangDH.Rows[i][0].ToString(), Convert.ToInt32(bangDH.Rows[i][3]), Convert.ToInt32(bangDH.Rows[i][4]));
                    NhapHangDAO.themCTDDH(ctDDH);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
