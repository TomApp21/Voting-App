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
    public partial class frmRegistration : Form
    {

        public frmRegistration()
        {
            InitializeComponent();
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtboxPassword.Text == "" || txtBoxConPass.Text == "")
            {
                MessageBox.Show("Username and Password fields are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txtboxPassword.Text == txtBoxConPass.Text)
            {
                User newUser = new User();
                newUser.Username = txtUsername.Text;
                newUser.Password = txtboxPassword.Text;
                newUser.IsVoter = true;

                newUser.Error = HelperClass.PopulateErrorModel("frmRegistration", "btnRegister_Click");

                string rtnMsg = SqliteDataAccess.Register(newUser);

                txtUsername.Text = "";
                txtboxPassword.Text = "";
                txtBoxConPass.Text = "";

                if (rtnMsg.Contains("registered"))
                    MessageBox.Show("Your Account has been successfully created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(rtnMsg, "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Passwords do not match, Please re-enter.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBoxConPass.Text = "";
                txtboxPassword.Text = "";
                txtboxPassword.Focus();
            }
        }

        private void checkbxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPassword.Checked)
            {
                txtboxPassword.PasswordChar = '\0';
                txtBoxConPass.PasswordChar = '\0';

            }
            else
            {
                txtboxPassword.PasswordChar = '*';
                txtBoxConPass.PasswordChar = '*';

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBoxConPass.Text = "";
            txtboxPassword.Text = "";
            txtUsername.Text = "";
            txtUsername.Focus();
        }

        private void lblBackToLogin_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }
    }
}
