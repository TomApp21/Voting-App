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
        #region Declarations

        private User _loggedInUser = new User();
        private List<Election> elections = new List<Election>();
        #endregion

        #region Constructor
        public frmAddElection(User loggedInUser)
        {
            InitializeComponent();
            _loggedInUser = loggedInUser;
            LoadElectionList();
        }
        #endregion


        /// <summary>
        /// Gets list of elections
        /// </summary>
        private void LoadElectionList()
        {
            ErrorModel thisModel = new ErrorModel();
            thisModel = HelperClass.PopulateErrorModel("frmAddElection", "LoadElectionList");

            elections = SqliteDataAccess.LoadElections(thisModel, _loggedInUser.Id);

            WireUpElectionList();
        }

        /// <summary>
        /// Configures election list
        /// </summary>
        private void WireUpElectionList()
        {
            listElectionListBox.DataSource = null;
            listElectionListBox.DataSource = elections;
            listElectionListBox.DisplayMember = "ElectionName";
        }

        private void btnAddElection_Click(object sender, EventArgs e)
        {
            Election election = new Election();

            election.ElectionName = txtElectionName.Text;
            election.StartDate = txtStartDate.Text;
            election.EndDate = txtEndDate.Text;


            if (election.EndDate == "" || election.StartDate == "" || election.ElectionName == "")
            {
                MessageBox.Show("Field cannot be empty");
            }
            else
            {
                /// Validates that end date is not before start date and saves election to db if valid
                /// ----------------------------------------------------------------------------------
                if (Convert.ToDateTime(election.EndDate) < Convert.ToDateTime(election.StartDate))
                    MessageBox.Show("End Date cannot be less than the Start Date.");
                else
                    SaveElection(election);
            }

            /// Clear election details on UI
            /// ----------------------------
            txtElectionName.Text = "";
            txtStartDate.Text = "";
            txtEndDate.Text = "";

            LoadElectionList();
        }

        /// <summary>
        /// Saves election to db
        /// </summary>
        /// <param name="election">populated election model</param>
        /// <returns></returns>
        private async Task SaveElection(Election election)
        {
            ErrorModel thisModel = new ErrorModel();
            thisModel = HelperClass.PopulateErrorModel("frmAddElection", "SaveElection");

            await SqliteDataAccess.SaveElection(election, thisModel, _loggedInUser.Id);
        }
    }
}
