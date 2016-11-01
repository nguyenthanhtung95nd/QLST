using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class MatHang_DTO
    {
        public string  MaMH { get; set; }
        public string  TenMH { get; set; }
        public string  QuyCach { get; set; }
        public string  MaNCC { get; set; }
        public string  DonGiaMua { get; set; }
        public string  DonGiaBan { get; set; }
        public string  SLT { get; set; }
        public string  KM { get; set; }

        public MatHang_DTO (string MaMH, string TenMH, string QuyCach, string MaNCC, string DonGiaMua, string DonGiaBan, string SLT, string KM)
        {
            this.MaMH = MaMH;
            this.TenMH = TenMH;
            this.QuyCach = QuyCach;
            this.MaNCC = MaNCC;
            this.DonGiaMua = DonGiaMua;
            this.DonGiaBan = DonGiaBan;
            this.SLT = SLT;
            this.KM = KM;
        }
    }
}
