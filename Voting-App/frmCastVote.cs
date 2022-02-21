using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VotingLibrary;

namespace Voting_App
{
    public partial class frmCastVote : Form
    {
        #region Declarations

        private Voter loggedInVoter;
        private User _loggedInUser;
        private Election eligibleElection = new Election();
        private List<Candidate> candidates = new List<Candidate>();
        #endregion

        public frmCastVote(User loggedInUser)
        {
            InitializeComponent();
            _loggedInUser = loggedInUser;

            ErrorModel errorModel = new ErrorModel();
            errorModel = HelperClass.PopulateErrorModel("frmCastVote", "Constructor");
            loggedInVoter = SqliteDataAccess.GetVoterDetails(errorModel, _loggedInUser.Id, _loggedInUser.Id);

            GetElection();
        }

        /// <summary>
        /// Retrieves election that the logged in user is eligible for
        /// </summary>
        private void GetElection()
        {
            ErrorModel thisModel = new ErrorModel();
            thisModel = HelperClass.PopulateErrorModel("frmCastVote","GetElection");

            eligibleElection = SqliteDataAccess.LoadElection(loggedInVoter.EligibleForElectionId, thisModel, loggedInVoter.Id);

            if (eligibleElection != null) 
            {
                txtEligibleElection.Text = eligibleElection.ElectionName;
            }
            if (!loggedInVoter.IdentityConfirmed)
            {
                lblVotingCloses.Text = "Awaiting ID verification";
            }
            else if (loggedInVoter.HasVoted)
            {
                lblVotingCloses.Text = "You have already cast a vote for this election";
            }
            else if(Convert.ToDateTime(eligibleElection.EndDate).AddDays(1) < DateTime.Now)
            {
                lblVotingCloses.Text = "Voting has now closed for this election.";
            }
            else if (DateTime.Now < Convert.ToDateTime(eligibleElection.StartDate))
            {
                lblVotingCloses.Text = "Voting starts on " + eligibleElection.StartDate;
            }
            else // load candidates list for the eligible election
            {
                listCandidateListBox.Show();
                btnCastVote.Show();
                lblCandidates.Show();
                LoadCandidatesList();
            }
        }

        /// <summary>
        /// Retrieves candidates associated with election
        /// </summary>
        private void LoadCandidatesList()
        {
            ErrorModel thisModel = new ErrorModel();
            thisModel = HelperClass.PopulateErrorModel("frmCastVote", "LoadCandidatesList");

            candidates = SqliteDataAccess.LoadCandidates(thisModel, eligibleElection.ElectionId, _loggedInUser.Id);
            WireUpCandidateList();
        }

        /// <summary>
        /// Configures candidate list
        /// </summary>
        private void WireUpCandidateList()
        {
            listCandidateListBox.DataSource = null;
            listCandidateListBox.DataSource = candidates;
            listCandidateListBox.DisplayMember = "CandidateName";
            listCandidateListBox.ValueMember = "CandidateId";
        }

        private void btnCastVote_Click(object sender, EventArgs e)
        {
            ErrorModel errorModel = new ErrorModel();
            errorModel = HelperClass.PopulateErrorModel("frmCastVote", "btnCastVote_Click");

            bool blnSuccess = SqliteDataAccess.CastVote(errorModel, loggedInVoter.Id, (int)listCandidateListBox.SelectedValue);

            listCandidateListBox.Hide();
            btnCastVote.Hide();
            lblCandidates.Hide();

            if (blnSuccess)
                lblVotingCloses.Text = "Vote successfully cast.";
            else
                lblVotingCloses.Text = "Error casting vote, please contact system administrator.";
        }
    }
}


