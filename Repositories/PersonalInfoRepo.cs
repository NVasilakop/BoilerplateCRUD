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
    public class PersonalInfoRepo : IPersonalInfoRepo
    {
        private SqlServerConnectionProvider _provider;
        public PersonalInfoRepo(SqlServerConnectionProvider provider)
        {
            _provider = provider;
        }

        public bool CreatePersonalInfo(PersonalInfo personalInfo)
        {
            long inserted;
            personalInfo.PersonalInfoID = Guid.NewGuid();
            using (var conn = _provider.GetDbConnection())
            {
                try
                {
                    using (var scope = new TransactionScope())
                    {
                        inserted = conn.Insert<PersonalInfo>(personalInfo);
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
                    return false;
                }
            }
        }

        public PersonalInfo GetPersonalInfo(Guid? personalInfoID)
        {
            PersonalInfo personalInfo = new PersonalInfo();
            using (var conn = _provider.GetDbConnection())
            {
                personalInfo = conn.QueryFirst<PersonalInfo>($"SELECT * FROM PersonalInfos WHERE PersonalInfoID='{personalInfoID}'");
            }
            return personalInfo;
        }

        public bool UpdatePersonalInfo(PersonalInfo personalInfo)
        {
            bool updated;
            using (var conn = _provider.GetDbConnection())
            {
                try
                {
                    using (var scope = new TransactionScope())
                    {
                        updated = conn.Update<PersonalInfo>(personalInfo);
                        if (updated)
                        {
                            scope.Complete();
                            return updated;
                        }
                        else
                        {
                            scope.Dispose();
                            return updated;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
