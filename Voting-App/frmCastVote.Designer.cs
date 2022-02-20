namespace Voting_App
{
    partial class frmCastVote
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCastVote = new System.Windows.Forms.Label();
            this.lblElectionName = new System.Windows.Forms.Label();
            this.listCandidateListBox = new System.Windows.Forms.ListBox();
            this.lblCandidates = new System.Windows.Forms.Label();
            this.btnCastVote = new System.Windows.Forms.Button();
            this.lblVotingCloses = new System.Windows.Forms.Label();
            this.txtEligibleElection = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCastVote
            // 
            this.lblCastVote.AutoSize = true;
            this.lblCastVote.BackColor = System.Drawing.Color.White;
            this.lblCastVote.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCastVote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.lblCastVote.Location = new System.Drawing.Point(52, 49);
            this.lblCastVote.Name = "lblCastVote";
            this.lblCastVote.Size = new System.Drawing.Size(241, 41);
            this.lblCastVote.TabIndex = 48;
            this.lblCastVote.Text = "Cast A Vote";
            // 
            // lblElectionName
            // 
            this.lblElectionName.AutoSize = true;
            this.lblElectionName.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElectionName.Location = new System.Drawing.Point(54, 87);
            this.lblElectionName.Name = "lblElectionName";
            this.lblElectionName.Size = new System.Drawing.Size(88, 28);
            this.lblElectionName.TabIndex = 53;
            this.lblElectionName.Text = "Election";
            // 
            // listCandidateListBox
            // 
            this.listCandidateListBox.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listCandidateListBox.FormattingEnabled = true;
            this.listCandidateListBox.ItemHeight = 28;
            this.listCandidateListBox.Location = new System.Drawing.Point(57, 170);
            this.listCandidateListBox.Name = "listCandidateListBox";
            this.listCandidateListBox.Size = new System.Drawing.Size(332, 200);
            this.listCandidateListBox.TabIndex = 56;
            this.listCandidateListBox.Visible = false;
            // 
            // lblCandidates
            // 
            this.lblCandidates.AutoSize = true;
            this.lblCandidates.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCandidates.Location = new System.Drawing.Point(54, 150);
            this.lblCandidates.Name = "lblCandidates";
            this.lblCandidates.Size = new System.Drawing.Size(116, 28);
            this.lblCandidates.TabIndex = 58;
            this.lblCandidates.Text = "Candidates";
            this.lblCandidates.Visible = false;
            // 
            // btnCastVote
            // 
            this.btnCastVote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btnCastVote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCastVote.FlatAppearance.BorderSize = 0;
            this.btnCastVote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCastVote.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCastVote.ForeColor = System.Drawing.Color.White;
            this.btnCastVote.Location = new System.Drawing.Point(444, 343);
            this.btnCastVote.Name = "btnCastVote";
            this.btnCastVote.Size = new System.Drawing.Size(216, 35);
            this.btnCastVote.TabIndex = 59;
            this.btnCastVote.Text = "Cast Vote";
            this.btnCastVote.UseVisualStyleBackColor = false;
            this.btnCastVote.Visible = false;
            this.btnCastVote.Click += new System.EventHandler(this.btnCastVote_Click);
            // 
            // lblVotingCloses
            // 
            this.lblVotingCloses.AutoSize = true;
            this.lblVotingCloses.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVotingCloses.Location = new System.Drawing.Point(279, 111);
            this.lblVotingCloses.Name = "lblVotingCloses";
            this.lblVotingCloses.Size = new System.Drawing.Size(0, 28);
            this.lblVotingCloses.TabIndex = 60;
            // 
            // txtEligibleElection
            // 
            this.txtEligibleElection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtEligibleElection.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEligibleElection.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtEligibleElection.Enabled = false;
            this.txtEligibleElection.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtEligibleElection.Location = new System.Drawing.Point(57, 110);
            this.txtEligibleElection.Multiline = true;
            this.txtEligibleElection.Name = "txtEligibleElection";
            this.txtEligibleElection.ReadOnly = true;
            this.txtEligibleElection.Size = new System.Drawing.Size(216, 21);
            this.txtEligibleElection.TabIndex = 61;
            this.txtEligibleElection.TabStop = false;
            // 
            // frmCastVote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(717, 438);
            this.Controls.Add(this.txtEligibleElection);
            this.Controls.Add(this.lblVotingCloses);
            this.Controls.Add(this.btnCastVote);
            this.Controls.Add(this.lblCandidates);
            this.Controls.Add(this.listCandidateListBox);
            this.Controls.Add(this.lblElectionName);
            this.Controls.Add(this.lblCastVote);
            this.Font = new System.Drawing.Font("MS UI Gothic", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCastVote";
            this.Text = "frmCastVote";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCastVote;
        private System.Windows.Forms.Label lblElectionName;
        private System.Windows.Forms.ListBox listCandidateListBox;
        private System.Windows.Forms.Label lblCandidates;
        private System.Windows.Forms.Button btnCastVote;
        private System.Windows.Forms.Label lblVotingCloses;
        private System.Windows.Forms.TextBox txtEligibleElection;
    }
}