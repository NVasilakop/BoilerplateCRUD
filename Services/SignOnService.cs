using IRepositories;
using IServices;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Services
{
    public class SignOnService : ISignOnService
    {
        private ISignOnRepo _signOnRepo;
        public SignOnService(ISignOnRepo signOnRepo)
        {
            _signOnRepo = signOnRepo;
        }
        public Guid SignIn(SignOn signIn)
        {
           return _signOnRepo.SignIn(Convert.ToBase64String(HashData(signIn)));
        }

        public bool SignUp(SignOn signUp)
        {
            var data = HashData(signUp);

            return _signOnRepo.SignUp(signUp.From_Service_To_Repo(data));
        }

        private byte[] HashData(SignOn signUp)
        {
            var data = Encoding.ASCII.GetBytes(signUp.Username + signUp.Password);
            var sha1 = new SHA1CryptoServiceProvider();
            var sha1data = sha1.ComputeHash(data);
            return sha1data;
        }
    }
}
