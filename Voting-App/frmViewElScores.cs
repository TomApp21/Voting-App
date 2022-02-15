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
        List<Election> elections = new List<Election>();
        List<Candidate> candidates = new List<Candidate>();

        Election selectedElection = new Election();

        public frmViewElScores(User loggedInUser)
        {
            InitializeComponent();
            LoadElectionList();

            selectedElection = (Election)dropdownElectionList.SelectedItem;
            LoadChartCandidates(selectedElection.ElectionId);
        }


        private void LoadElectionList()
        {
            elections = SqliteDataAccess.LoadElections();

            WireUpElectionList();
        }

        private void WireUpElectionList()
        {
            dropdownElectionList.DataSource = null;
            dropdownElectionList.DataSource = elections;
            dropdownElectionList.DisplayMember = "ElectionName"; // Column Name
            dropdownElectionList.ValueMember = "ElectionId";
        }

        private void LoadChartCandidates(int electionId)
        {
            candidates = SqliteDataAccess.LoadCandidates(electionId);
            
            WireUpElectionScoreChart();
        }
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
        }
    }
}
