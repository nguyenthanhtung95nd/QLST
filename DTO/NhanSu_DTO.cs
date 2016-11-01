using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class NhanSu_DTO
    {
        public string MaNS { get; set; }
        public string HoTenNS { get; set; }
        public string SDTNS { get; set; }
        public string DCNS { get; set; }
        public string ChucVu { get; set; }
        public NhanSu_DTO (string MaNS, string HoTenNS, string SDTNS, string DCNS,string ChucVu)
        {
            this.MaNS = MaNS;
            this.HoTenNS = HoTenNS;
            this.SDTNS = SDTNS;
            this.DCNS = DCNS;
            this.ChucVu = ChucVu;
        }
    }
}
