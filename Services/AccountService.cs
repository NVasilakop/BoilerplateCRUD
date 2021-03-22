using IRepositories;
using IServices;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepo _accRepo;
        public AccountService(IAccountRepo accRepo)
        {
            _accRepo = accRepo;
        }

        public List<Account> GetAccounts()
        {
            var items = _accRepo.GetAccounts();
            return items.TransformAccInfo();
        }

        public Account GetAccount(Guid accId)
        {
            Account account= TransformationsFromRepo.From_AccInfo_To_Account(_accRepo.GetAccount(accId));
            return account;
        }

        public bool InsertAccount(Account account)
        {
            return _accRepo.InsertAccInfo(account.From_Account_To_AccInfo());
        }
    }
}
