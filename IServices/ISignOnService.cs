using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace IServices
{
    public interface ISignOnService
    {
        bool SignUp(SignOn signUp);
        Guid SignIn(SignOn signIn);
    }
}
