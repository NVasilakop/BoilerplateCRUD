using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RepoContracts
{
    public class PersonalInfo
    {
        [Key]
        public Guid PersonalInfoID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid AccNo { get; set; }
    }
}
