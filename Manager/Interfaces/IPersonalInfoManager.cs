using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interfaces
{
    public interface IPersonalInfoManager
    {
        bool CreatePersonalInfo(ServiceContracts.Person personalInfo, Guid AccId);
    }
}
