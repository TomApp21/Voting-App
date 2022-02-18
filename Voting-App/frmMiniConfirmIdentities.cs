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
        Voter selectedVoter = new Voter();
        User _loggedInUser = new User();

        public frmMiniConfirmIdentities(User loggedInUser)
        {
            InitializeComponent();
            _loggedInUser = loggedInUser;
            LoadUsersList();
        }

        List<Voter> voters = new List<Voter>();


        private void LoadUsersList()
        {
            ErrorModel thisModel = new ErrorModel();
            thisModel = HelperClass.PopulateErrorModel("frmMiniConfirmIdentities", "LoadUsersList");
            
            voters = SqliteDataAccess.LoadVotersList(thisModel, _loggedInUser.Id);
            WireUpVotersList();
        }

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

        private void WireUpVotersDetailBoxes(int selectedVoterId)
        {
            selectedVoter = SqliteDataAccess.GetVoterDetails(selectedVoterId);

            if (selectedVoter != null)
            {
                txtFirstName.Text = selectedVoter.FirstName;
                txtboxLastName.Text = selectedVoter.LastName;
                txtAddLine1.Text = selectedVoter.Address;
                txtBoxDob.Text = selectedVoter.DateOfBirth;
                txtNatIns.Text = selectedVoter.NINumber;

                ErrorModel thisErrorModel = new ErrorModel();
                thisErrorModel = HelperClass.PopulateErrorModel("frmMiniConfirmIdentities", "WireUpVotersDetailBoxes");

                txtElection.Text = SqliteDataAccess.LoadElection(selectedVoter.EligibleForElectionId, thisErrorModel).ElectionName.ToString();
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
                SqliteDataAccess.ApproveVoterIdentity(selectedVoter.Id);
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
            SqliteDataAccess.DenyVoterIdentity(selectedVoter.Id);
            lblConfirmation.Text = selectedVoter.FullName + "'s identity has been denied.";

            lblConfirmation.Visible = true;
            btnApprove.Hide();
            btnDeny.Hide();

            // show message + re-load list
            // ---------------------------
            await showProcessedMsg();
            clearTextBoxes();
            LoadUsersList();



            // clear text boxes if no identities left to be confirmed
            // ------------------------------------------------------
            //if (voters == null)
            //    clearTextBoxes();



        }

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

        private void clearTextBoxes()
        {
            txtAddLine1.Text = "";
            txtBoxDob.Text = "";
            txtboxLastName.Text = "";
            txtElection.Text = "";
            txtFirstName.Text = "";
            txtNatIns.Text = "";
        }


        private void listElectionListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //if (e.Index < 0) return;
            ////if the item state is selected them change the back color 
            //if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            //    e = new DrawItemEventArgs(e.Graphics,
            //                              e.Font,
            //                              e.Bounds,
            //                              e.Index,
            //                              e.State ^ DrawItemState.Selected,
            //                              e.ForeColor,
            //                              Color.MediumPurple);//Choose the color

            //// Draw the background of the ListBox control for each item.
            //e.DrawBackground();
            //// Draw the current item text

            //    e.Graphics.DrawString(listElectionListBox.Text, e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);

            //// If the ListBox has focus, draw a focus rectangle around the selected item.
            //e.DrawFocusRectangle();

            //listElectionListBox.DisplayMember = "FullName";

        }
    }
}
