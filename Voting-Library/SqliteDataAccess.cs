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
    public class SqliteDataAccess
    {
        public SqliteDataAccess()
        {
            
        }
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }


        #region Elections

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="thisModel"></param>
        /// <returns></returns>
        public static Election LoadElection(int id, ErrorModel thisModel)
        {
            Election election = new Election();

            try
            {
                using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
                {
                    var query= conn.Query<Election>("select * from Elections WHERE ElectionId=@ElectionId", new { ElectionId = id });
                    return query.FirstOrDefault();
                }
            }
            catch (SQLiteException ex)
            {
                thisModel.ExceptionMessage = ex.Message;
                thisModel.TimeOfError = DateTime.Now.ToString();
                thisModel.UserId = id;

                LogError(thisModel);

                return election;
            }
        }

        public static List<Election> LoadElections(ErrorModel thisModel, int loggedInUserId)
        {
            List<Election> elections = new List<Election>();

            try
            {
                using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
                {
                    var query = conn.Query<Election>("SELECT * from Elections", new DynamicParameters());
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                thisModel.ExceptionMessage = ex.Message;
                thisModel.TimeOfError = DateTime.Now.ToString();
                thisModel.UserId = loggedInUserId;

                LogError(thisModel);

                return elections;
            }
        }

        public static async Task SaveElection(Election election, ErrorModel thisModel, int loggedInUserId)
        {
            try
            {
                using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
                {
                    conn.Execute("insert into Elections (ElectionName, StartDate, EndDate) values (@ElectionName, @StartDate, @EndDate) ", election);
                }
            }
            catch (Exception ex)
            {
                thisModel.ExceptionMessage = ex.Message;
                thisModel.TimeOfError = DateTime.Now.ToString();
                thisModel.UserId = loggedInUserId;

                LogError(thisModel);
            }
        }

        #endregion


        #region Register & Login

        public static string Register(User user)
        {
            string rtnMsg;
            try
            {
                using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = conn.Query<User>("insert into Users (Username, Password, IsVoter ) values (@Username, @Password, @IsVoter)", user);
                }
                return rtnMsg = "User successfully registered.";
            }
            catch(Exception ex)
            {
                user.Error.ExceptionMessage = ex.Message;
                user.Error.TimeOfError = DateTime.Now.ToString();

                LogError(user.Error);

                return rtnMsg = ex.Message;
            }
        }
        public static User Login(User user)
        {
            User loggedInUser = new User();

            try
            {
                using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
                {
                    var query = conn.Query<User>($"SELECT * FROM Users Where Username= @Username AND Password = @Password", user).FirstOrDefault();
                    return query;
                }
            }
            catch (SQLiteException ex) 
            {
                user.Error.ExceptionMessage = ex.Message;
                user.Error.TimeOfError = DateTime.Now.ToString();

                LogError(user.Error);
                return loggedInUser;
            }
        }

        #endregion

        #region Confirm Identity

 
        /// <summary>
        /// Retrieves details associated with a voter
        /// </summary>
        /// <param name="thisModel">Error Model</param>
        /// <param name="id">Id of voter to retrieve</param>
        /// <param name="loggedInUserId">Logged in user id</param>
        /// <returns></returns>
        public static Voter GetVoterDetails(ErrorModel thisModel, int id, int loggedInUserId)
        {
            Voter output = null;
            try
            {
                using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
                {
                    var query = conn.Query<Voter>($"SELECT * FROM Users Where Id=@id", new { Id = id });
                    return query.FirstOrDefault();
                }
            }
            catch (SQLiteException ex)
            {
                thisModel.ExceptionMessage = ex.Message;
                thisModel.TimeOfError = DateTime.Now.ToString();
                thisModel.UserId = loggedInUserId;
                LogError(thisModel);

                return output;
            }
        }

        /// <summary>
        /// Loads voters who are awaiting identity confirmatiom.
        /// </summary>
        /// <returns></returns>
        public static List<Voter> LoadVotersList(ErrorModel thisModel, int loggedInUserId)
        {
            List<Voter> voters = new List<Voter>();
            try
            {
                using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = conn.Query<Voter>($"SELECT * FROM Users Where IdentityConfirmed IS NULL AND IsAdmin=0 AND NINumber IS NOT NULL"); 
                    return output.ToList();
                }
            }
            catch (SQLiteException ex)
            {

                return voters;
            }
        }

        public static void ApproveVoterIdentity(int id)
        {
            try
            {
                using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = conn.Query<User>($"UPDATE Users SET IdentityConfirmed=@IdentityConfirmed WHERE Id=@Id",
                        new { IdentityConfirmed = 1, Id = id });
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void DenyVoterIdentity(int id)
        {
            try
            {
                using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = conn.Query<User>($"UPDATE Users SET IdentityConfirmed=@IdentityConfirmed WHERE Id=@Id",
                        new { IdentityConfirmed = 0, Id = id });
                }
            }
            catch (SQLiteException ex)
            {

            }
        }


        #endregion

        #region Register Voter


        public static void RegisterVoter(Voter voter)
        {
            try
            {
                using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = conn.Execute($"UPDATE Users SET FirstName=@FirstName, LastName=@LastName, AddressLine1=@AddressLine1, AddressLine2=@AddressLine2, Postcode=@Postcode, DateOfBirth=@DateOfBirth, NINumber=@NINumber, EligibleForElectionId=@Eid WHERE Id=@Id",
                        new { FirstName = voter.FirstName, Id = voter.Id, LastName = voter.LastName, AddressLine1 = voter.AddressLine1, AddressLine2 = voter.AddressLine2, Postcode = voter.Postcode, DateOfBirth = voter.DateOfBirth, NINumber = voter.NINumber, Eid = voter.EligibleForElectionId });
                }
            }
            catch (SQLiteException ex)
            {

            }

        }


        #endregion

        #region Cast Vote
        public static bool CastVote(int voterId, int candidateId)
        {
            Boolean blnReturn = false;

            try
            {
                using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
                {
                    if (voterId != null && voterId != null && candidateId != null & candidateId != 0)
                    {
                        var query = conn.Query<Voter>($"UPDATE Users SET HasVoted=1 WHERE Id=@Id", new { Id = voterId });

                        var query2 = conn.Query<Candidate>($"UPDATE Candidates SET VoteCount=VoteCount+1 WHERE CandidateId=@CandidateId",
                            new { CandidateId = candidateId });

                        blnReturn = true;
                    }
                    return blnReturn;
                }
            }
            catch (SQLiteException ex)
            {
                // log
                return blnReturn;
            }
        }


        #endregion

        #region Candidates

        public static List<Candidate> LoadCandidates(int electionId)
        {
            List<Candidate> candidates = new List<Candidate>();
            try
            {
                using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
                {
                    var query = conn.Query<Candidate>("SELECT * FROM Candidates Where ElectionId=@ElectionId", new { ElectionId = electionId });
                    return query.ToList();
                }
            }
            catch (SQLiteException ex)
            {
                // add log
                return candidates;
            }
        }

        public static async Task SaveCandidate(Candidate candidate)
        {
            try
            {
                using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
                {
                    conn.Execute("insert into Candidates (CandidateName, VoteCount, ElectionId) values (@CandidateName, @VoteCount, @ElectionId) ", candidate);
                }
            }
            catch (SQLiteException ex)
            {
            }
        }


        #endregion


        #region Error Logging 

        public static string LogError(ErrorModel error)
        {
            string rtnMsg;
            try
            {
                using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = conn.Query<ErrorModel>("insert into ErrorAudit (Id, ClassName, FunctionName, TimeOfError, ExceptionMessage, UserId ) values (@Id, @ClassName, @FunctionName, @TimeOfError, @ExceptionMessage, @UserId)", error);
                }
                return rtnMsg = "Error added to audit log";
            }
            catch (Exception ex)
            {
                // show pop=up? 
                return rtnMsg = ex.Message;
            }
        }
        #endregion

        #region Demo

        // Demo Functions
        // --------------
        public static List<PersonModel> LoadPeople()
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = conn.Query<PersonModel>("select * from Person", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SavePerson(PersonModel person)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("insert into Person (FirstName, LastName) values (@FirstName, @LastName) ", person);
            }
        }


        #endregion
    }
}




//public static void GetUserDetai(Voter voter)
//{
//    using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
//    {
//        var output = conn.Query<User>($"UPDATE Users SET FirstName=@FirstName, LastName=@LastName, Address=@Address, DateOfBirth=@DateOfBirth, NINumber=@NINumber WHERE Id=@Id",
//            new { FirstName = voter.FirstName, Id = voter.Id, LastName = voter.LastName, Address = voter.Address, DateOfBirth = voter.DateOfBirth, NINumber = voter.NINumber });

//    }
//}