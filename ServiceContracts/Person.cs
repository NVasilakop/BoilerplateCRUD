using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts
{
    public class Person
    {
        public Guid PersonalInfoID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid AccNo { get; set; }
    }
}
