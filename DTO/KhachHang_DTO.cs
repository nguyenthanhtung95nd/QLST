using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class KhachHang_DTO
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string SDTKH { get; set; }
        public string DiemTL { get; set; }
        public KhachHang_DTO (string MaKH  , string TenKH, string DiaChi, string SDTKH, string DiemTL)
        {
            this.MaKH = MaKH;
            this.TenKH = TenKH;
            this.DiaChi = DiaChi;
            this.SDTKH = SDTKH;
            this.DiemTL = DiemTL;
        }
    }
}
