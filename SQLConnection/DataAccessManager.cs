using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace SQLConnection
{
    public class DataAccessManager
    {
        private string _connectionstring;

        public DataAccessManager(string ServerName, string DBName)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = ServerName;
            builder.InitialCatalog = DBName;
            builder.TrustServerCertificate = true;
            builder.IntegratedSecurity = true;

            _connectionstring = builder.ConnectionString;
        }
    }
}
