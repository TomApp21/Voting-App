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
using System.Runtime.InteropServices;

namespace Voting_App
{
    public partial class Dashboard : Form
    {
        private User loggedInUser;

        // Parameters which allow panel to be moved
        // ----------------------------------------
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        public Dashboard(User loggedInUser)
        {
            InitializeComponent();

            this.loggedInUser = loggedInUser;
            lblUsername.Text = "Hello " + loggedInUser.Username;

            // Hide/Show navigation components depending on user privelege
            // ------------------------------------------------------------
            if (loggedInUser.IsAdmin)
            {
                btnRegister.Visible = false;
                btnCastVote.Visible = false;
                btnViewElectionScores.Visible = false;
            }
            if (loggedInUser.IsAuditor)
            {
                btnAddCandidates.Visible = false;
                btnAddElection.Visible = false;
                btnRegister.Visible = false;
                btnCastVote.Visible = false;
                btnConfirmIdentity.Visible = false;
            }
            if (loggedInUser.IsVoter)
            {
                btnAddCandidates.Visible = false;
                btnAddElection.Visible = false;
                btnConfirmIdentity.Visible = false;
                btnViewElectionScores.Visible = false;
            }

            // Highlight which nav button is active
            // ------------------------------------
            pnlNav.Height = btnDashboard.Height;
            pnlNav.Top = btnDashboard.Top;
            pnlNav.Left = btnDashboard.Left;

            lblTitle.Text = "Dashboard";

            // Clear current form, show dashboard form
            // ---------------------------------------
            this.pnlFormLoader.Controls.Clear();
            frmMiniDashboard FrmDashboard_Vrb = new frmMiniDashboard(loggedInUser) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        /// <summary>
        /// Loads dashboard form
        /// </summary>
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDashboard.Height;
            pnlNav.Top = btnDashboard.Top;
            pnlNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Dashboard";
            this.pnlFormLoader.Controls.Clear();
            frmMiniDashboard FrmDashboard_Vrb = new frmMiniDashboard(loggedInUser) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }


        /// <summary>
        /// Loads register to vote form
        /// </summary>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnRegister.Height;
            pnlNav.Top = btnRegister.Top;
            btnRegister.BackColor = Color.FromArgb(46, 51, 73); 

            lblTitle.Text = "Register";
            this.pnlFormLoader.Controls.Clear();
            frmMiniRegister FrmRegister_Vrb = new frmMiniRegister(loggedInUser) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmRegister_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FrmRegister_Vrb);
            FrmRegister_Vrb.Show();
        }


        /// <summary>
        /// Loads confirm identity form
        /// </summary>
        private void btnConfirmIdentity_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnConfirmIdentity.Height;
            pnlNav.Top = btnConfirmIdentity.Top;
            btnConfirmIdentity.BackColor = Color.FromArgb(46, 51, 73); // change

            lblTitle.Text = "Confirm Identities";
            this.pnlFormLoader.Controls.Clear();
            frmMiniConfirmIdentities FrmConfirmIdentities_Vrb = new frmMiniConfirmIdentities(loggedInUser) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmConfirmIdentities_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FrmConfirmIdentities_Vrb);
            FrmConfirmIdentities_Vrb.Show();
        }

        /// <summary>
        /// Loads add election form
        /// </summary>
        private void btnAddElection_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnAddElection.Height;
            pnlNav.Top = btnAddElection.Top;
            btnAddElection.BackColor = Color.FromArgb(46, 51, 73); // change

            lblTitle.Text = "Add Election";
            this.pnlFormLoader.Controls.Clear();
            frmAddElection FrmAddElection_Vrb = new frmAddElection(loggedInUser) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmAddElection_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FrmAddElection_Vrb);
            FrmAddElection_Vrb.Show();
        }


        /// <summary>
        /// Loads add candidates form
        /// </summary>
        private void btnAddCandidates_Click_1(object sender, EventArgs e)
        {
            pnlNav.Height = btnAddCandidates.Height;
            pnlNav.Top = btnAddCandidates.Top;
            btnAddCandidates.BackColor = Color.FromArgb(46, 51, 73); // change

            lblTitle.Text = "Add Candidate";
            this.pnlFormLoader.Controls.Clear();
            frmAddCandidate FrmAddCandidate_Vrb = new frmAddCandidate(loggedInUser) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmAddCandidate_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FrmAddCandidate_Vrb);
            FrmAddCandidate_Vrb.Show();
        }


        /// <summary>
        /// Loads cast vote form
        /// </summary>
        private void btnCastVote_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnCastVote.Height;
            pnlNav.Top = btnCastVote.Top;
            btnCastVote.BackColor = Color.FromArgb(46, 51, 73); // change

            lblTitle.Text = "Cast Vote";
            this.pnlFormLoader.Controls.Clear();
            frmCastVote FrmCastVote_Vrb = new frmCastVote(loggedInUser) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmCastVote_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FrmCastVote_Vrb);
            FrmCastVote_Vrb.Show();
        }

        /// <summary>
        /// Loads view election scores form
        /// </summary>
        private void btnViewElectionScores_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnViewElectionScores.Height;
            pnlNav.Top = btnViewElectionScores.Top;
            btnViewElectionScores.BackColor = Color.FromArgb(46, 51, 73); // change

            lblTitle.Text = "View Scores";
            this.pnlFormLoader.Controls.Clear();
            frmViewElScores FrmViewScores_Vrb = new frmViewElScores(loggedInUser) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmViewScores_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FrmViewScores_Vrb);
            FrmViewScores_Vrb.Show();
        }

        // Sets navigation button back to original colour when a different tab is clicked.
        // -------------------------------------------------------------------------------
        private void btnDashboard_Leave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(116, 86, 174);
        }

        private void btnRegister_Leave_1(object sender, EventArgs e)
        {
            btnRegister.BackColor = Color.FromArgb(116, 86, 174);
        }

        private void btnConfirmIdentity_Leave(object sender, EventArgs e)
        {
            btnConfirmIdentity.BackColor = Color.FromArgb(116, 86, 174);
        }
        private void btnAddElection_Leave(object sender, EventArgs e)
        {
            btnAddElection.BackColor = Color.FromArgb(116, 86, 174);
        }
        private void btnAddCandidates_Leave(object sender, EventArgs e)
        {
            btnAddCandidates.BackColor = Color.FromArgb(116, 86, 174);
        }

        private void btnCastVote_Leave(object sender, EventArgs e)
        {
            btnCastVote.BackColor = Color.FromArgb(116, 86, 174);
        }

        private void btnViewElectionScores_Leave(object sender, EventArgs e)
        {
            btnViewElectionScores.BackColor = Color.FromArgb(116, 86, 174);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblLogOff_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }

        /// <summary>
        /// Allows main window to be movable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }


    }
}
