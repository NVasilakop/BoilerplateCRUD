using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interfaces
{
    public interface ISignManager
    {
        string SignUp(SignOn signUp);
    }
}
