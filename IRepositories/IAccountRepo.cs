using RepoContracts;
using System;
using System.Collections.Generic;

namespace IRepositories
{
    public interface IAccountRepo
    {
        List<AccInfo> GetAccounts();
        AccInfo GetAccount(Guid accId);
        bool InsertAccInfo(AccInfo accInfo);
    }
}
