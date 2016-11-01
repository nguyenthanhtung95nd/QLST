using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using DAO;
using System.Data;

namespace BUS
{
    public class NCC_BUS
    {
        public static DataTable LoadDataNCC()
        {
            return NCC.LoadData();
        }
        public static void ThemNCC(NCC_DTO ncc)
        {
            NCC.Them(ncc);
        }
        public static void XoaNCC(string ma)
        {
            NCC.Xoa(ma);
        }
        public static void SuaNCC(NCC_DTO ncc)
        {
            NCC.Sua(ncc);
        }
    }
}
