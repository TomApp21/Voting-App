using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingLibrary
{
    public class ErrorModel
    {
        public string ClassName { get; set; }
        public string FunctionName { get; set; }
        public string TimeOfError { get; set; }
        public string ExceptionMessage { get; set; }
        public int UserId { get; set; }


    }
}
