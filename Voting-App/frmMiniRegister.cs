﻿using Newtonsoft.Json;
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
        private Voter voter;

        List<Election> elections = new List<Election>();

        public frmMiniRegister(User loggedInUser)
        {
            InitializeComponent();
            LoadElectionList();

            //var serializedParent = JsonConvert.SerializeObject(loggedInUser);
            //voter = JsonConvert.DeserializeObject<Voter>(serializedParent);


            voter = SqliteDataAccess.GetVoterDetails(loggedInUser.Id); 



            //Comment out if want to access registration page after registering
            // -----------------------------------------------------------------
            if (voter.NINumber != null)
            {
                pnlRegDetails.Visible = false;
                lblMiniTitle.Visible = false;
                lblAlreadyRegisted.Text = "Already Registered To Vote.";
                lblAlreadyRegisted.Visible = true;
            }
        }

        private void frmMiniRegister_Load(object sender, EventArgs e)
        {

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

                    // add bool return for 

                    SqliteDataAccess.RegisterVoter(voter);

                    btnRegister.Enabled = false;
                    lblRegistrationComplete.Visible = true;
                    
                    DisableTextBoxEntry();
                }
            }
            else
            {
                MessageBox.Show("Invalid date/format. Please try again.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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


    }
}