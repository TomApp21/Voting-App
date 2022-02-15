namespace VotingLibrary
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
        public int VoteCount { get; set; }
        public int ElectionId { get; set; }
    }
}