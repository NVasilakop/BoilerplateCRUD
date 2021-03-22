using Dapper;
using Dapper.Contrib.Extensions;
using ExternalConnections;
using IRepositories;
using RepoContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Repositories
{
    public class SignOnRepo : ISignOnRepo
    {

        private SqlServerConnectionProvider _provider;
        public SignOnRepo(SqlServerConnectionProvider provider)
        {
            _provider = provider;
        }

        public Guid SignIn(string hashedPass)
        {
            Guid signedOn;
            using (var conn = _provider.GetDbConnection())
            {
                signedOn = conn.QueryFirst<Guid>($"SELECT AccNo FROM SignOns WHERE HashedPassUsern='{hashedPass}'");
            }
            return signedOn;
        }

        public bool SignUp(SignOn signUp)
        {
            long inserted;
            using (var conn = _provider.GetDbConnection())
            {
                try
                {
                    using (var scope = new TransactionScope())
                    {
                        inserted = conn.Insert<SignOn>(signUp);
                        if (inserted == 0)
                        {
                            scope.Complete();
                            return inserted == 0;
                        }
                        else
                        {
                            scope.Dispose();
                            return inserted == 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //transaction.Rollback();
                    return false;
                }
            }
        }
    }
}
