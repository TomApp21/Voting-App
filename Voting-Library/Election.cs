using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingLibrary
{
    public class Election
    {
        public int ElectionId { get; set; }
        public string ElectionName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
