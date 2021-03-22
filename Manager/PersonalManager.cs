using IServices;
using Manager.Interfaces;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager
{
    public class PersonalManager : IPersonalInfoManager
    {
        private IPersonalInfoService _personalInfoService;
        public PersonalManager(IPersonalInfoService personalInfoService)
        {
            _personalInfoService = personalInfoService;
        }

        public bool CreatePersonalInfo(Person personalInfo,Guid AccId)
        {
           return _personalInfoService.InsertPersonalInfo(personalInfo);
        }
    }
}
