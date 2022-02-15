using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingLibrary;

namespace VotingLibrary
{
    public class HelperClass
    {
        public static ErrorModel PopulateErrorModel(string className, string methodName)
        {
            ErrorModel thisModel = new ErrorModel();
            thisModel.ClassName = className;
            thisModel.FunctionName = methodName;

            return thisModel;
        }

    }
}
