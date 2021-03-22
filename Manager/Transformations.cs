using System;
using System.Collections.Generic;
using System.Text;

namespace Manager
{
    public static class Transformations
    {
        public static ServiceContracts.Account From_SignOn_To_Account(this ServiceContracts.SignOn signUp,Guid accId)
        {
            return new ServiceContracts.Account
            {
                AccNo = accId
            };
        }

        public static ServiceContracts.Person From_Acc_To_Person(Guid accId) 
        {
            return new ServiceContracts.Person
            {
                AccNo = accId,
                DateOfBirth = DateTime.Now,
                Name = " ",
                Surname = " "
            };
        }
    }
}
