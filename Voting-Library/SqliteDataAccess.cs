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
        /// <summary>
        /// Retrieves connection string used for db connection
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        #region Register & Login

        /// <summary>
        /// Register a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Handles a user logging in
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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
            catch (Exception ex) 
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                thisModel.ExceptionMessage = ex.Message;
                thisModel.TimeOfError = DateTime.Now.ToString();
                thisModel.UserId = loggedInUserId;
                LogError(thisModel);

                return voters;
            }
        }

        /// <summary>
        /// Sets a flag in user table to indicate identity has been confirmed
        /// </summary>
        public static void ApproveVoterIdentity(ErrorModel thisModel, int voterId, int loggedInUserId)
        {
            try
            {
                using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = conn.Query<User>($"UPDATE Users SET IdentityConfirmed=@IdentityConfirmed WHERE Id=@Id",
                        new { IdentityConfirmed = 1, Id = voterId });
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

        /// <summary>
        /// Sets a flag in user table to indicate identity has been denied
        /// </summary>
        public static void DenyVoterIdentity(ErrorModel thisModel, int voterId, int loggedInUserId)
        {
            try
            {
                using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = conn.Query<User>($"UPDATE Users SET IdentityConfirmed=@IdentityConfirmed WHERE Id=@Id",
                        new { IdentityConfirmed = 0, Id = voterId });
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

        #region Register Voter

        /// <summary>
        /// Updates user table with voter details
        /// </summary>
        public static bool RegisterVoter(ErrorModel thisModel, Voter voter, int loggedInUserId)
        {
            bool blnReturn = false;
            try
            {
                using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = conn.Execute($"UPDATE Users SET FirstName=@FirstName, LastName=@LastName, AddressLine1=@AddressLine1, AddressLine2=@AddressLine2, Postcode=@Postcode, DateOfBirth=@DateOfBirth, NINumber=@NINumber, EligibleForElectionId=@Eid WHERE Id=@Id",
                        new { FirstName = voter.FirstName, Id = voter.Id, LastName = voter.LastName, AddressLine1 = voter.AddressLine1, AddressLine2 = voter.AddressLine2, Postcode = voter.Postcode, DateOfBirth = voter.DateOfBirth, NINumber = voter.NINumber, Eid = voter.EligibleForElectionId });
                }
                blnReturn = true;
            }
            catch (Exception ex)
            {
                thisModel.ExceptionMessage = ex.Message;
                thisModel.TimeOfError = DateTime.Now.ToString();
                thisModel.UserId = loggedInUserId;
                LogError(thisModel);
            }
            return blnReturn;
        }

        #endregion

        #region Cast Vote

        /// <summary>
        /// Updates the vote count on a candidate and sets flag in the voters table so they can't
        /// vote again.
        /// </summary>
        /// <returns></returns>
        public static bool CastVote(ErrorModel thisModel, int voterId, int candidateId)
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
            catch (Exception ex)
            {
                thisModel.ExceptionMessage = ex.Message;
                thisModel.TimeOfError = DateTime.Now.ToString();
                thisModel.UserId = voterId;
                LogError(thisModel);

                return blnReturn;
            }
        }


        #endregion

        #region Candidates

        /// <summary>
        /// Loads candidates associated with an election
        /// </summary>
        /// <returns>list of candidates</returns>
        public static List<Candidate> LoadCandidates(ErrorModel thisModel, int electionId, int loggedInUserId)
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
            catch (Exception ex)
            {
                thisModel.ExceptionMessage = ex.Message;
                thisModel.TimeOfError = DateTime.Now.ToString();
                thisModel.UserId = loggedInUserId;
                LogError(thisModel);

                return candidates;
            }
        }

        /// <summary>
        /// Adds candidate to an election in db
        /// </summary>
        /// <returns></returns>
        public static async Task SaveCandidate(ErrorModel thisModel, Candidate candidate, int userId)
        {
            try
            {
                using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
                {
                    conn.Execute("insert into Candidates (CandidateName, VoteCount, ElectionId) values (@CandidateName, @VoteCount, @ElectionId) ", candidate);
                }
            }
            catch (Exception ex)
            {
                thisModel.ExceptionMessage = ex.Message;
                thisModel.TimeOfError = DateTime.Now.ToString();
                thisModel.UserId = userId;
                LogError(thisModel);
            }
        }


        #endregion

        #region Elections

        /// <summary>
        /// Loads an election based on id given.
        /// </summary>
        /// <returns></returns>
        public static Election LoadElection(int id, ErrorModel thisModel, int userId)
        {
            Election election = new Election();

            try
            {
                using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
                {
                    var query = conn.Query<Election>("select * from Elections WHERE ElectionId=@ElectionId", new { ElectionId = id });
                    return query.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                thisModel.ExceptionMessage = ex.Message;
                thisModel.TimeOfError = DateTime.Now.ToString();
                thisModel.UserId = userId;

                LogError(thisModel);

                return election;
            }
        }

        /// <summary>
        /// Loads all elections
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Saves an election to db
        /// </summary>
        /// <returns></returns>
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


        #region Error Logging 

        /// <summary>
        /// Adds errir log to error audit table.
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static string LogError(ErrorModel error)
        {
            string rtnMsg;
            try
            {
                using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = conn.Query<ErrorModel>("insert into ErrorAudit (ClassName, FunctionName, TimeOfError, ExceptionMessage, UserId ) values (@ClassName, @FunctionName, @TimeOfError, @ExceptionMessage, @UserId)", error);
                }
                return rtnMsg = "Error added to audit log";
            }
            catch (SQLiteException ex)
            {
                return rtnMsg = ex.Message;
            }
        }
        #endregion

    }
}



