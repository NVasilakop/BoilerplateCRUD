using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RepoContracts
{
    public class AccInfo
    {
        [Key]
        public Guid AccNo { get; set; }
        public bool Premium { get; set; }
        public bool NewsLetterOn { get; set; }

    }
}
