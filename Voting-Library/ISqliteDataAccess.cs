using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingLibrary;

namespace Voting_Library
{
    public interface ISqliteDataAccess
    {
        Election LoadElection(int id, ErrorModel thisModel, int userId);
        List<Election> LoadElections(ErrorModel thisModel, int loggedInUserId);
        Task SaveElection(Election election, ErrorModel thisModel, int loggedInUserId);
        string Register(User user);
        User Login(User user);
        Voter GetVoterDetails(ErrorModel thisModel, int id, int loggedInUserId);
        List<Voter> LoadVotersList(ErrorModel thisModel, int loggedInUserId);
        void ApproveVoterIdentity(ErrorModel thisModel, int voterId, int loggedInUserId);
        void DenyVoterIdentity(ErrorModel thisModel, int voterId, int loggedInUserId);
        void RegisterVoter(ErrorModel thisModel, Voter voter, int loggedInUserId);
        bool CastVote(ErrorModel thisModel, int voterId, int candidateId);
        List<Candidate> LoadCandidates(ErrorModel thisModel, int electionId, int loggedInUserId);
        Task SaveCandidate(ErrorModel thisModel, Candidate candidate, int userId);
        string LogError(ErrorModel error);






    }
}
