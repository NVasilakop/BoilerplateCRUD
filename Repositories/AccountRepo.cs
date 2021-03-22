using Dapper;
using Dapper.Contrib.Extensions;
using ExternalConnections;
using IRepositories;
using RepoContracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;

namespace Repositories
{
    public class AccountRepo : IAccountRepo
    {
        private SqlServerConnectionProvider _provider;
        public AccountRepo(SqlServerConnectionProvider provider)
        {
            _provider = provider;
        }

        public AccInfo GetAccount(Guid accId)
        {
            AccInfo result;
             using (var conn = _provider.GetDbConnection())
            {
                result = conn.QueryFirst<AccInfo>($"SELECT * FROM AccInfos WHERE AccNo='{accId}' ");
            }
            return result;
        }

        public List<AccInfo> GetAccounts()
        {
            List<AccInfo> results = new List<AccInfo>();
            using (var conn = _provider.GetDbConnection())
            {
                results = conn.Query<AccInfo>("SELECT * FROM AccInfos").AsList();
            }
            return results;
        }

        public bool InsertAccInfo(AccInfo accInfo)
        {
            accInfo.AccNo = accInfo.AccNo != default(Guid)? accInfo.AccNo : Guid.NewGuid();
            using (var conn = _provider.GetDbConnection())
            {
                //IDbTransaction transaction = conn.BeginTransaction();
                try
                {
                    using (var scope = new TransactionScope())
                    {
                        long result = conn.Insert<AccInfo>(accInfo);
                        if (result == 0)
                        {
                            //transaction.Commit();
                            scope.Complete();
                            return result == 0;
                        }
                        else
                        {
                            //transaction.Rollback();
                            scope.Dispose();
                            return result == 0;
                        }
                    }
                }
                catch(Exception ex)
                {
                    //transaction.Rollback();
                    return false;
                }
            }


        }
    }
}
