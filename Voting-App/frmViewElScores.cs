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
    public partial class frmViewElScores : Form
    {
        #region Declarations
        Election selectedElection = new Election();
        User _loggedInUser = new User();

        List<Election> elections = new List<Election>();
        List<Candidate> candidates = new List<Candidate>();
        #endregion

        public frmViewElScores(User loggedInUser)
        {
            InitializeComponent();
            _loggedInUser = loggedInUser;
            LoadElectionList();

            selectedElection = (Election)dropdownElectionList.SelectedItem;
            LoadChartCandidates(selectedElection.ElectionId);
        }

        /// <summary>
        /// Loads election list
        /// </summary>
        private void LoadElectionList()
        {
            ErrorModel thisModel = new ErrorModel();
            elections = SqliteDataAccess.LoadElections(thisModel, _loggedInUser.Id);

            WireUpElectionList();
        }

        /// <summary>
        /// Configures election dropdown
        /// </summary>
        private void WireUpElectionList()
        {
            dropdownElectionList.DataSource = null;
            dropdownElectionList.DataSource = elections;
            dropdownElectionList.DisplayMember = "ElectionName"; // Column Name
            dropdownElectionList.ValueMember = "ElectionId";
        }

        /// <summary>
        /// Retrieves all candidates associatede with an election
        /// </summary>
        /// <param name="electionId">id of selcetd election</param>
        private void LoadChartCandidates(int electionId)
        {
            ErrorModel thisModel = new ErrorModel();
            thisModel = HelperClass.PopulateErrorModel("frmViewElScores", "LoadChartCandidates");

            candidates = SqliteDataAccess.LoadCandidates(thisModel, electionId, _loggedInUser.Id);
            
            WireUpElectionScoreChart();
        }

        /// <summary>
        /// Configues the voter graph
        /// </summary>
        private void WireUpElectionScoreChart()
        {
            chartElectionScore.DataSource = candidates;
            chartElectionScore.Series["Candidates"].XValueMember = "CandidateName";
            chartElectionScore.Series["Candidates"].YValueMembers = "VoteCount";
            chartElectionScore.Titles.Clear(); 
        }

        private void dropdownElectionList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            selectedElection = (Election)dropdownElectionList.SelectedItem;
            int id = selectedElection.ElectionId;
            LoadChartCandidates(selectedElection.ElectionId);

            if (Convert.ToDateTime(selectedElection.EndDate).AddDays(1) < DateTime.Now)
                lblFinished.Text = "This election has finished.";
            else
                lblFinished.Text = "";
        }
    }
}
