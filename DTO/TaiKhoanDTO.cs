using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class TaiKhoanDTO
    {
        string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        string password;

        public string Password{
            get { return password; }
            set { password = value; }
        }
        string maNS;

        public string MaNS
        {
            get { return maNS; }
            set { maNS = value; }
        }

        public TaiKhoanDTO(string tendn, string pw, string ma)
        {
            this.id = tendn;
            this.password = pw;
            this.maNS = ma;
        }
    }
}
