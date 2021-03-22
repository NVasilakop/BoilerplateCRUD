using RepoContracts;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace IServices
{
    public interface IAccountService
    {
        List<Account> GetAccounts();
        Account GetAccount(Guid accId);
        bool InsertAccount(Account account);
    }
}
