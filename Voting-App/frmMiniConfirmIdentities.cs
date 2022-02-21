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
    public partial class frmMiniConfirmIdentities : Form
    {
        #region Declarations

        Voter selectedVoter = new Voter();
        User _loggedInUser = new User();
        List<Voter> voters = new List<Voter>();
        #endregion


        public frmMiniConfirmIdentities(User loggedInUser)
        {
            InitializeComponent();
            _loggedInUser = loggedInUser;
            LoadUsersList();
        }

        /// <summary>
        /// Load users awaiting identity verification
        /// </summary>
        private void LoadUsersList()
        {
            ErrorModel thisModel = new ErrorModel();
            thisModel = HelperClass.PopulateErrorModel("frmMiniConfirmIdentities", "LoadUsersList");
            
            voters = SqliteDataAccess.LoadVotersList(thisModel, _loggedInUser.Id);
            WireUpVotersList();
        }

        /// <summary>
        /// Configure voters list box
        /// </summary>
        private void WireUpVotersList()
        {
            listElectionListBox.DataSource = null;
            listElectionListBox.DataSource = voters;
            listElectionListBox.DisplayMember = "FullName";
            listElectionListBox.ValueMember = "Id";

            if (voters.Count != 0)
            {
                WireUpVotersDetailBoxes((int)listElectionListBox.SelectedValue);
                btnApprove.Enabled = true;
                btnDeny.Enabled = true;
            }
            else
            {
                btnApprove.Enabled = false;
                btnDeny.Enabled = false;
            }
        }

        /// <summary>
        /// Sets up user/voter details in textbox
        /// </summary>
        /// <param name="selectedVoterId">id of the selected voter</param>
        private void WireUpVotersDetailBoxes(int selectedVoterId)
        {
            ErrorModel errorModel = new ErrorModel();
            errorModel = HelperClass.PopulateErrorModel("frmViewElScores", "WireUpVotersDetailBoxes");
            selectedVoter = SqliteDataAccess.GetVoterDetails(errorModel, selectedVoterId, _loggedInUser.Id);

            if (selectedVoter != null)
            {
                txtFirstName.Text = selectedVoter.FirstName;
                txtboxLastName.Text = selectedVoter.LastName;
                txtAddLine1.Text = selectedVoter.Address;
                txtBoxDob.Text = selectedVoter.DateOfBirth;
                txtNatIns.Text = selectedVoter.NINumber;

                ErrorModel thisErrorModel = new ErrorModel();
                thisErrorModel = HelperClass.PopulateErrorModel("frmMiniConfirmIdentities", "WireUpVotersDetailBoxes");

                txtElection.Text = SqliteDataAccess.LoadElection(selectedVoter.EligibleForElectionId, thisErrorModel, _loggedInUser.Id).ElectionName.ToString();
            }
        }

        private void listElectionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            listElectionListBox.SelectedIndex = 0;
            selectedVoter = (Voter)listElectionListBox.SelectedItem;
            int selectedVoterId = selectedVoter.Id;

            WireUpVotersDetailBoxes(selectedVoterId);
        }

        private async void btnApprove_Click(object sender, EventArgs e)
        {
            if (voters != null)
            {
                ErrorModel errorModel = new ErrorModel();
                errorModel = HelperClass.PopulateErrorModel("frmMiniConfirmIdentities", "btnApprove_Click");

                SqliteDataAccess.ApproveVoterIdentity(errorModel, selectedVoter.Id, _loggedInUser.Id);
                lblConfirmation.Text = selectedVoter.FullName + "'s identity has been confirmed.";

                lblConfirmation.Visible = true;
                btnApprove.Hide();
                btnDeny.Hide();


                await showProcessedMsg();
                clearTextBoxes();
                LoadUsersList();
            }
            else
                clearTextBoxes();

        }

        private async void btnDeny_Click(object sender, EventArgs e)
        {
            if (voters != null)
            {
                ErrorModel errorModel = new ErrorModel();
                errorModel = HelperClass.PopulateErrorModel("frmMiniConfirmIdentities", "btnDeny_Click");


                SqliteDataAccess.DenyVoterIdentity(errorModel, selectedVoter.Id, _loggedInUser.Id);
                lblConfirmation.Text = selectedVoter.FullName + "'s identity has been denied.";

                lblConfirmation.Visible = true;
                btnApprove.Hide();
                btnDeny.Hide();

                // show message + re-load list
                // ---------------------------
                await showProcessedMsg();
                clearTextBoxes();
                LoadUsersList();
            }
            else
                clearTextBoxes();
        }

        /// <summary>
        /// Shows confirmation label + hides buttons for 3 seconds
        /// </summary>
        /// <returns></returns>
        private async Task showProcessedMsg()
        {
            var t = new Timer();
            t.Interval = 3000; // it will Tick in 3 seconds
            t.Tick += (s, e) =>
            {
                lblConfirmation.Hide();
                btnApprove.Show();
                btnDeny.Show();
                t.Stop();
            };
            t.Start();
        }

        /// <summary>
        /// Clears text boxes
        /// </summary>
        private void clearTextBoxes()
        {
            txtAddLine1.Text = "";
            txtBoxDob.Text = "";
            txtboxLastName.Text = "";
            txtElection.Text = "";
            txtFirstName.Text = "";
            txtNatIns.Text = "";
        }
    }
}
