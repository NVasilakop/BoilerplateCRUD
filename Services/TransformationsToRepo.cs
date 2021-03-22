using RepoContracts;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public static class TransformationsToRepo
    {
        public static AccInfo From_Account_To_AccInfo(this Account account)
        {
            return new AccInfo
            {
                NewsLetterOn = account.NewsLetterOn,
                Premium = account.Premium,
                AccNo = account.AccNo ?? default(Guid)
            };
        }

        public static RepoContracts.SignOn From_Service_To_Repo(this ServiceContracts.SignOn signOn,byte[] hashedData)
        {
            return new RepoContracts.SignOn
            {
                AccNo = Guid.NewGuid(),
                HashedPassUsern = Convert.ToBase64String(hashedData),
                SignOnID = Guid.NewGuid()
            };
        }

        public static RepoContracts.PersonalInfo From_Service_To_Repo(this ServiceContracts.Person person)
        {
            return new RepoContracts.PersonalInfo
            {
                AccNo = person.AccNo,
                DateOfBirth = person.DateOfBirth,
                Name = person.Name,
                PersonalInfoID = person.PersonalInfoID,
                Surname = person.Surname
            };
        }

    }
}
