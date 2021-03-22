using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace IServices
{
    public interface IPersonalInfoService
    {
        Person GetPersonalInfo(Guid? personalInfoID);
        bool InsertPersonalInfo(ServiceContracts.Person personalInfo);
        bool UpdatePersonalInfo(Person person);

    }
}
