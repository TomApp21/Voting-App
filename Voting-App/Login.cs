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
    public partial class frmLogin : Form
    {
        public frmLogin   ()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            User loginUser = new User();
            loginUser.Username = txtUsername.Text;
            loginUser.Password = txtBoxPassword.Text;

            User loggedInUser = SqliteDataAccess.Login(loginUser);

            if (loggedInUser != null)  // needs changing
            {
                new Dashboard(loggedInUser).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password, Please try again.", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Text = "";
                txtBoxPassword.Text = "";
                txtUsername.Focus();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtBoxPassword.Text = "";
            txtUsername.Focus();
        }

        private void checkbxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPassword.Checked)
            {
                txtBoxPassword.PasswordChar = '\0';

            }
            else
            {
                txtBoxPassword.PasswordChar = '*';

            }
        }

        private void lblCreateAccount_Click(object sender, EventArgs e)
        {
            new frmRegistration().Show();
            this.Hide();
        }
    }
}
