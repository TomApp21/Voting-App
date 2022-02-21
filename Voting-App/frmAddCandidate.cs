using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VotingLibrary;

namespace Voting_App
{
    public partial class frmAddCandidate : Form
    {
        #region Declarations

        User _loggedInUser = new User();
        Election selectedElection = new Election();
        List<Election> elections = new List<Election>();
        List<Candidate> candidates = new List<Candidate>();
        #endregion

        #region Constructor
        public frmAddCandidate(User loggedInUser)
        {
            InitializeComponent();
            _loggedInUser = loggedInUser;

            LoadElectionList();

            /// Get all candidates belonging to the defaulted election
            /// Show add candidate button
            if (elections.Count != 0)
            {
                selectedElection = (Election)dropdownElectionList.SelectedItem;
                LoadCandidatesList(selectedElection.ElectionId);
                btnAddCandidate.Show();
            }
            /// Show message indicating no elections
            else
                lblEligibleElection.Show();
        }
        #endregion

        /// <summary>
        /// Retrieves elections that have not yet started
        /// </summary>
        private void LoadElectionList()
        {
            /// Declare error model to be passed to DAL
            /// --------------------------------------
            ErrorModel thisModel = new ErrorModel();
            thisModel = HelperClass.PopulateErrorModel("frmAddCandidate", "LoadElectionList");

            /// Retrieve Elections
            /// ------------------
            elections = SqliteDataAccess.LoadElections(thisModel, _loggedInUser.Id);

            /// Remove elections that have ended from the list
            /// ---------------------------------------------------------
            foreach (Election election in elections.ToList())
            {
                if (Convert.ToDateTime(election.EndDate) < DateTime.Now)
                    elections.Remove(election);
            }    
            WireUpElectionList();
        }

        /// <summary>
        /// Configures the election dropdown list
        /// </summary>
        private void WireUpElectionList()
        {
            dropdownElectionList.DataSource = null;
            dropdownElectionList.DataSource = elections;
            dropdownElectionList.DisplayMember = "ElectionName"; 
            dropdownElectionList.ValueMember = "ElectionId";
        }

        private void btnAddCandidate_Click(object sender, EventArgs e)
        {
            if (txtCandidateName.Text != "" && dropdownElectionList.SelectedItem != null)
            {
                Candidate candidate = new Candidate();

                candidate.CandidateName = txtCandidateName.Text;
                candidate.ElectionId = (int)dropdownElectionList.SelectedValue;

                SaveCandidate(candidate);

                // Clear text
                // ------------
                txtCandidateName.Text = "";

                // Re-load candidate list
                // ----------------------
                LoadCandidatesList(candidate.ElectionId);
            }
            else
                MessageBox.Show("Field cannot be empty");
        }

        /// <summary>
        /// Saves candidate to election in db
        /// </summary>
        /// <param name="candidate">candidate entered by admin</param>
        /// <returns></returns>
        private async Task SaveCandidate(Candidate candidate)
        {
            ErrorModel thisModel = new ErrorModel();
            thisModel = HelperClass.PopulateErrorModel("frmAddCandidate", "SaveCandidate");

            await SqliteDataAccess.SaveCandidate(thisModel, candidate, _loggedInUser.Id);
        }

        /// <summary>
        /// Handles drop down election list changing.
        /// Refreshes candidate list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dropdownElectionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedElection = (Election)dropdownElectionList.SelectedItem;
            int id = selectedElection.ElectionId;
            LoadCandidatesList(id);
        }

        /// <summary>
        /// Retrieves candidates associated with an election
        /// </summary>
        /// <param name="electionId"></param>
        private void LoadCandidatesList(int electionId)
        {
            ErrorModel thisModel = new ErrorModel();
            thisModel = HelperClass.PopulateErrorModel("frmAddCandidate", "LoadCandidatesList");
            candidates = SqliteDataAccess.LoadCandidates(thisModel, electionId, _loggedInUser.Id);
            WireUpCandidateList();
        }

        /// <summary>
        /// Configures candidate list box
        /// </summary>
        private void WireUpCandidateList()
        {
            listCandidateListBox.DataSource = null;
            listCandidateListBox.DataSource = candidates;
            listCandidateListBox.DisplayMember = "CandidateName";
            listCandidateListBox.ValueMember = "CandidateId";
        }
    }
}
