using System;

namespace ServiceContracts
{
    public class Account
    {
        public Guid? AccNo { get; set; }
        public bool Premium { get; set; }
        public bool NewsLetterOn { get; set; }
    }
}
