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
        List<Election> elections = new List<Election>();
        List<Candidate> candidates = new List<Candidate>();

        Candidate selectedCandidate = new Candidate();
        Election selectedElection = new Election();


        public frmAddCandidate(User loggedInUser)
        {
            InitializeComponent();
            LoadElectionList();

            selectedElection = (Election)dropdownElectionList.SelectedItem;
            LoadCandidatesList(selectedElection.ElectionId);

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

        private void btnAddCandidate_Click(object sender, EventArgs e)
        {
            // if election started, can't add candidate

            if (txtCandidateName.Text != "" && dropdownElectionList.SelectedItem != null)
            {
                Candidate candidate = new Candidate();

                candidate.CandidateName = txtCandidateName.Text;
                candidate.ElectionId = (int)dropdownElectionList.SelectedValue;

                SaveCandidate(candidate);
                txtCandidateName.Text = "";

                LoadCandidatesList(candidate.ElectionId);
            }
 
        }

        private async Task SaveCandidate(Candidate candidate)
        {
            await SqliteDataAccess.SaveCandidate(candidate);
        }


        private void dropdownElectionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedElection = (Election)dropdownElectionList.SelectedItem;
            int id = selectedElection.ElectionId;
            LoadCandidatesList(id);
        }

        private void LoadCandidatesList(int electionId)
        {
            candidates = SqliteDataAccess.LoadCandidates(electionId);
            WireUpCandidateList();
        }

        private void WireUpCandidateList()
        {
            listCandidateListBox.DataSource = null;
            listCandidateListBox.DataSource = candidates;
            listCandidateListBox.DisplayMember = "CandidateName";
            listCandidateListBox.ValueMember = "CandidateId";        
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            LoadCandidatesList(selectedCandidate.ElectionId);
        }
    }
}
