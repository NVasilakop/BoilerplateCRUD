using RepoContracts;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public static class TransformationsFromRepo
    {
        public static List<Account> TransformAccInfo(this List<AccInfo> accs)
        {
            List<Account> accList = new List<Account>();
            accs.ForEach(item => accList.Add(From_AccInfo_To_Account(item)));
            return accList;
        }

        public static Account From_AccInfo_To_Account(AccInfo accInfo)
        {
            return new Account
            {
                AccNo = accInfo.AccNo,
                NewsLetterOn = accInfo.NewsLetterOn,
                Premium = accInfo.Premium  
            };
        }

        public static Person From_PersonalInfo_To_Person(this PersonalInfo persInfo)
        {
            return new Person
            {
                AccNo = persInfo.AccNo,
                DateOfBirth = persInfo.DateOfBirth,
                Name = persInfo.Name,
                Surname = persInfo.Surname,
                PersonalInfoID = persInfo.PersonalInfoID
            };
        }

    }
}
