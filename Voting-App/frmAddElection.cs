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
    public partial class frmAddElection : Form
    {
        List<Election> elections = new List<Election>();

        public frmAddElection(User loggedInUser)
        {
            InitializeComponent();
            LoadElectionList();
        }


        private void LoadElectionList()
        {
            elections = SqliteDataAccess.LoadElections();

            WireUpElectionList();
        }

        private void WireUpElectionList()
        {
            listElectionListBox.DataSource = null;
            listElectionListBox.DataSource = elections;
            listElectionListBox.DisplayMember = "ElectionName";
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            LoadElectionList();
        }

        private void btnAddElection_Click(object sender, EventArgs e)
        {
            Election election = new Election();

            election.ElectionName = txtElectionName.Text;
            election.StartDate = txtStartDate.Text;
            election.EndDate = txtEndDate.Text;

            SaveElection(election);
         
            txtElectionName.Text = "";
            txtStartDate.Text = "";
            txtEndDate.Text = "";

            LoadElectionList();

        }

        private async Task SaveElection(Election election)
        {
            await SqliteDataAccess.SaveElection(election);
        }
    }
}
