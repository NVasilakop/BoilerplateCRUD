using RepoContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRepositories
{
    public interface IPersonalInfoRepo
    {
        PersonalInfo GetPersonalInfo(Guid? personalInfoID);
        bool CreatePersonalInfo(PersonalInfo personalInfo);
        bool UpdatePersonalInfo(PersonalInfo personalInfo);
    }
}
