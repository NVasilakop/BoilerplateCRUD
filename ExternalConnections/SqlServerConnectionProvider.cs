using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ExternalConnections
{
    public class SqlServerConnectionProvider 
    {
        private readonly string _connectionString;

        public SqlServerConnectionProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetDbConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
