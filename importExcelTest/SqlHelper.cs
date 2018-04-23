using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace negar
{
    class SqlHelper
    {
        SqlConnection cn;
        public SqlHelper(string connectionString)
        {
            cn = new SqlConnection(connectionString);
        }
        public bool IsConnection
        {
            get
            {
                if (cn.State == System.Data.ConnectionState.Closed)
                    cn.Open();
                return true;

            }
        }
        
         
    }
}
