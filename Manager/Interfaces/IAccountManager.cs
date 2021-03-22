using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interfaces
{
    public interface IAccountManager
    {
        bool CreateAccount(ServiceContracts.SignOn signUp, Guid AccId);
        Account RetrieveAccount(Guid accId);
    }
}
