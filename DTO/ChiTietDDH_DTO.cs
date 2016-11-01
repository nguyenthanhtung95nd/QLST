using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class ChiTietDDH_DTO
    {
        private int soDDH;
        public int SoDDH
        {
            get { return soDDH; }
            set { soDDH = value; }
        }

        private string maMH;
        public string MaMH
        {
            get { return maMH; }
            set { maMH = value; }
        }

        private int slDat;
        public int SlDat
        {
            get { return slDat; }
            set { slDat = value; }
        }

        private int donGia;
        public int DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }

        public ChiTietDDH_DTO(int so, string ma, int sl, int gia)
        {
            soDDH = so;
            maMH = ma;
            slDat = sl;
            donGia = gia;
        }
    }
}
