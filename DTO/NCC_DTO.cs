using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class NCC_DTO
    {
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string DCNCC { get; set; }
        public string SDTNCC { get; set; }
        public NCC_DTO (string MaNCC, string TenNCC, string DCNCC, string SDTNCC)
        {
            this.MaNCC = MaNCC;
            this.TenNCC = TenNCC;
            this.DCNCC = DCNCC;
            this.SDTNCC = SDTNCC;
        }
    }
}
