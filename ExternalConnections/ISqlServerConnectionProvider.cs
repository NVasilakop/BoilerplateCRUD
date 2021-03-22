using System;
using System.Data;

namespace ExternalConnections
{
    public interface ISqlServerConnectionProvider
    {
        public IDbConnection GetDbConnection();
    }
}
