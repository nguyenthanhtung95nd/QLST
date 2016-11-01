using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class ChiTietHD_DTO
    {
        public string SoHD { get; set; }
        public string MaMH { get; set; }
        public string SLMH { get; set; }
        public string GiaBan { get; set; }

        public ChiTietHD_DTO (string SoHD  , string MaMH, string SLMH, string GiaBan)
        {
            this.SoHD = SoHD;
            this.MaMH = MaMH;
            this.SLMH = SLMH;
            this.GiaBan = GiaBan;
        }
    }
}
