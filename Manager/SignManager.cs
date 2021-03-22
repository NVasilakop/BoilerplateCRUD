using IServices;
using Manager.Interfaces;
using ServiceContracts;
using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager
{
    public class SignManager : ISignManager
    {
        private ISignOnService _signService;
        private IAccountManager _accManager;
        private IPersonalInfoManager _personalInfoManager;
        public SignManager(ISignOnService signService,
            IAccountManager accManager,
            IPersonalInfoManager personalInfoManager)
        {
            _signService = signService;
            _accManager = accManager;
            _personalInfoManager = personalInfoManager;
        }
        public string SignUp(SignOn signUp)
        {
            //SignUp the User
            bool signedUp =  _signService.SignUp(signUp);

            //Find AccId
            Guid AccId = _signService.SignIn(signUp);

            bool insertedAcc;
            //Create the template PersonalInfo 
            bool insertedPersonal = _personalInfoManager.CreatePersonalInfo(Transformations.From_Acc_To_Person(AccId),AccId);

            //Create The Acc
            if (signedUp)
            {
                insertedAcc = _accManager.CreateAccount(signUp, AccId);
            }
            else
            {
                insertedAcc = false;
            }

            string accountNo;
            if (signedUp && insertedAcc && insertedPersonal)
            {
                 accountNo = _accManager.RetrieveAccount(AccId).AccNo.ToString();
                return accountNo;
            }
            else
            {
                return null;
            }
        }
    }
}
