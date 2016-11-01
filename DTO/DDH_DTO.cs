using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class DDH_DTO
    {
        private int soDDH;
        public int SoDDH
        {
            get { return soDDH; }
            set { soDDH = value; }
        }

        private string maNCC;
        public string MaNCC
        {
            get { return maNCC; }
            set { maNCC = value; }
        }

        private string ngayLap;
        public string NgayLap
        {
            get { return ngayLap; }
            set { ngayLap = value; }
        }

        private string maNS;
        public string MaNS
        {
            get { return maNS; }
            set { maNS = value; }
        }

        public DDH_DTO(string mancc, string ngay, string mans)
        {
            maNCC = mancc;
            ngayLap = ngay;
            maNS = mans;
        }
    }
}
