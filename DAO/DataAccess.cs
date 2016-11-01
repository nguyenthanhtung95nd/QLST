using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Configuration;

namespace DAO
{
    public class DataAccess
    {
        public static SqlConnection ketNoi()
        {
            string connstr = ConfigurationManager.ConnectionStrings["CKN"].ConnectionString;
            return new SqlConnection(connstr);
        }
    }
}
