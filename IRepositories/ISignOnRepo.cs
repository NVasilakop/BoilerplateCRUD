using RepoContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRepositories
{
    public interface ISignOnRepo
    {
        bool SignUp(SignOn signUp);
        Guid SignIn(string signOn);

    }
}
