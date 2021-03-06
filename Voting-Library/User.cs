using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingLibrary;

namespace VotingLibrary
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public bool IsVoter { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsAuditor { get; set; }

        public ErrorModel Error { get; set; }

    }
}
