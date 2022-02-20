using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingLibrary;

namespace VotingLibrary
{
    public class Voter : User
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public bool IdentityConfirmed { get; set; }
        public string NINumber { get; set; }
        public string AddressLine1 { get; set; } 
        public string AddressLine2 { get; set; } 
        public string Postcode { get; set; }
        public int EligibleForElectionId { get; set; }
        public bool HasVoted { get; set; }
        public string FullName
        {
            get
            {
                return $"{ FirstName } { LastName }";
            }
        }

        public string Address
        {
            get
            {
                return $"{ AddressLine1 }, { AddressLine2 }, { Postcode }";
            }            
        }

        public bool HasRegistered()
        {
            bool blnReturn = false;

            if (NINumber != null)
                blnReturn = true;

            return blnReturn;
        }
    }
}
