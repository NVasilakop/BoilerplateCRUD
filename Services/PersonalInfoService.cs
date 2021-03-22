using IRepositories;
using IServices;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class PersonalInfoService : IPersonalInfoService
    {
        private IPersonalInfoRepo _personalInfoRepo;
        public PersonalInfoService(IPersonalInfoRepo personalRepo)
        {
            _personalInfoRepo = personalRepo;
        }
        public Person GetPersonalInfo(Guid? personalInfoID)
        {
            return _personalInfoRepo.GetPersonalInfo(personalInfoID).From_PersonalInfo_To_Person();
        }

        public bool InsertPersonalInfo(ServiceContracts.Person personalInfo)
        {
            return _personalInfoRepo.CreatePersonalInfo(personalInfo.From_Service_To_Repo());
        }

        public bool UpdatePersonalInfo(Person person)
        {
            return _personalInfoRepo.UpdatePersonalInfo(person.From_Service_To_Repo());
        }
    }
}
