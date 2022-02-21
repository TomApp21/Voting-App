using Newtonsoft.Json;
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
    public partial class frmMiniRegister : Form
    {
        #region Declarations

        private Voter voter;
        private List<Election> elections = new List<Election>();
        private User _loggedInUser = new User();
        #endregion

        public frmMiniRegister(User loggedInUser)
        {
            InitializeComponent();
            _loggedInUser = loggedInUser;

            LoadElectionList();

            ErrorModel errorModel = new ErrorModel();
            errorModel = HelperClass.PopulateErrorModel("frmMiniRegister", "Constructor");

            voter = SqliteDataAccess.GetVoterDetails(errorModel, _loggedInUser.Id, _loggedInUser.Id);

            if (voter.HasRegistered())
            {
                pnlRegDetails.Visible = false;
                lblMiniTitle.Visible = false;
                lblAlreadyRegisted.Text = "Already Registered To Vote.";
                lblAlreadyRegisted.Visible = true;
            }
        }



        private void btnRegister_Click_1(object sender, EventArgs e)
        {

            if (IsValidDate(txtBoxDob.Text))
            {
                if (txtFirstName.Text == "" || txtboxLastName.Text == "" || txtNatIns.Text == "" || txtPostcode.Text == "" ||
                    txtAddLine1.Text == "" || txtAddressLine2.Text == "" || txtPostcode.Text == "")
                {
                    MessageBox.Show("Field(s) are empty, Please try again.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    voter.FirstName = txtFirstName.Text;
                    voter.LastName = txtboxLastName.Text;
                    voter.AddressLine1 = txtAddLine1.Text;
                    voter.AddressLine2 = txtAddressLine2.Text;
                    voter.Postcode = txtPostcode.Text;
                    voter.DateOfBirth = txtBoxDob.Text;
                    voter.NINumber = txtNatIns.Text;
                    voter.EligibleForElectionId = (int)dropdownElectionList.SelectedValue;

                    ErrorModel thisModel = new ErrorModel();
                    thisModel = HelperClass.PopulateErrorModel("frmMiniRegister", "btnRegister_Click");

                    bool success = SqliteDataAccess.RegisterVoter(thisModel, voter, _loggedInUser.Id);

                    if (success)
                    {
                        btnRegister.Enabled = false;
                        lblRegistrationComplete.Visible = true;

                        DisableTextBoxEntry();
                    }
                    else
                        MessageBox.Show("Vote Registration Failed");
                }
            }
            else
            {
                MessageBox.Show("Invalid date/format. Please try again.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load elections
        /// </summary>
        private void LoadElectionList()
        {
            ErrorModel thisModel = new ErrorModel();
            thisModel = HelperClass.PopulateErrorModel("frmMiniRegister", "LoadElectionList");

            elections = SqliteDataAccess.LoadElections(thisModel, _loggedInUser.Id);
            WireUpElectionList();
        }

        /// <summary>
        ///  Configure election drop-down
        /// </summary>
        private void WireUpElectionList()
        {
            dropdownElectionList.DataSource = null;
            dropdownElectionList.DataSource = elections;
            dropdownElectionList.DisplayMember = "ElectionName"; // Column Name
            dropdownElectionList.ValueMember = "ElectionId";
        }


        /// <summary>
        /// Determines if date of birth string is a valid date and in correct format
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsValidDate(string value)
        {
            DateTime tempDate;
            bool validDate = DateTime.TryParseExact(value, "dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out tempDate);
            if (validDate)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Disables text box entry after successful registration.
        /// </summary>
        private void DisableTextBoxEntry()
        {
            txtFirstName.ReadOnly = true;
            txtboxLastName.ReadOnly = true;
            txtAddLine1.ReadOnly = true;
            txtAddressLine2.ReadOnly = true;
            txtPostcode.ReadOnly = true;
            txtBoxDob.ReadOnly = true;
            txtNatIns.ReadOnly = true;
            dropdownElectionList.Enabled = false;
        }
        private void frmMiniRegister_Load(object sender, EventArgs e)
        {

        }

    }
}
