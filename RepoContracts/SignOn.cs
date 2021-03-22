using System;
using System.Collections.Generic;
using System.Text;

namespace RepoContracts
{
    public class SignOn
    {
        public Guid SignOnID { get; set; }
        public string HashedPassUsern { get; set; }
        public Guid AccNo { get; set; }
    }
}
