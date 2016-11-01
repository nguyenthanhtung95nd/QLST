using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class HoaDon_DTO
    {
        public string MaKH { get; set; }
        public string MaNS { get; set; }
        public string GiamGia { get; set; }
        public string TongTriGia { get; set; }

        public HoaDon_DTO (string MaKH, string MaNS, string GiamGia, string TongTriGia)
        {
            this.MaKH = MaKH;
            this.MaNS = MaNS;
            this.GiamGia = GiamGia;
            this.TongTriGia = TongTriGia;
        }
    }
}
