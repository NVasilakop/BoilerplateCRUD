using IServices;
using Manager.Interfaces;
using ServiceContracts;
using Services;
using System;

namespace Manager
{
    public class AccountManager: IAccountManager
    {
        private IAccountService _accService;

        public AccountManager( IAccountService accService)
        {
            _accService = accService;
        }

        public bool CreateAccount(ServiceContracts.SignOn signUp,Guid AccId)
        {
            return _accService.InsertAccount(signUp.From_SignOn_To_Account(AccId));
        }

        public Account RetrieveAccount(Guid accId)
        {
            return _accService.GetAccount(accId);
        }
    }
}
