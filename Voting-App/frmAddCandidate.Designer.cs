namespace Voting_App
{
    partial class frmAddCandidate
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
            this.lblElectionName = new System.Windows.Forms.Label();
            this.txtCandidateName = new System.Windows.Forms.TextBox();
            this.lblCandidateName = new System.Windows.Forms.Label();
            this.lblAddCandidate = new System.Windows.Forms.Label();
            this.btnAddCandidate = new System.Windows.Forms.Button();
            this.dropdownElectionList = new System.Windows.Forms.ComboBox();
            this.lblCanSuccessMsg = new System.Windows.Forms.Label();
            this.lblCandidateList = new System.Windows.Forms.Label();
            this.listCandidateListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblElectionName
            // 
            this.lblElectionName.AutoSize = true;
            this.lblElectionName.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElectionName.Location = new System.Drawing.Point(54, 177);
            this.lblElectionName.Name = "lblElectionName";
            this.lblElectionName.Size = new System.Drawing.Size(57, 17);
            this.lblElectionName.TabIndex = 51;
            this.lblElectionName.Text = "Election";
            // 
            // txtCandidateName
            // 
            this.txtCandidateName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtCandidateName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCandidateName.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtCandidateName.Location = new System.Drawing.Point(57, 139);
            this.txtCandidateName.Multiline = true;
            this.txtCandidateName.Name = "txtCandidateName";
            this.txtCandidateName.Size = new System.Drawing.Size(216, 28);
            this.txtCandidateName.TabIndex = 49;
            // 
            // lblCandidateName
            // 
            this.lblCandidateName.AutoSize = true;
            this.lblCandidateName.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCandidateName.Location = new System.Drawing.Point(54, 119);
            this.lblCandidateName.Name = "lblCandidateName";
            this.lblCandidateName.Size = new System.Drawing.Size(110, 17);
            this.lblCandidateName.TabIndex = 48;
            this.lblCandidateName.Text = "Candidate Name";
            // 
            // lblAddCandidate
            // 
            this.lblAddCandidate.AutoSize = true;
            this.lblAddCandidate.BackColor = System.Drawing.Color.White;
            this.lblAddCandidate.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddCandidate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.lblAddCandidate.Location = new System.Drawing.Point(52, 67);
            this.lblAddCandidate.Name = "lblAddCandidate";
            this.lblAddCandidate.Size = new System.Drawing.Size(339, 27);
            this.lblAddCandidate.TabIndex = 47;
            this.lblAddCandidate.Text = "Add Candidate To Election";
            // 
            // btnAddCandidate
            // 
            this.btnAddCandidate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btnAddCandidate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCandidate.FlatAppearance.BorderSize = 0;
            this.btnAddCandidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCandidate.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCandidate.ForeColor = System.Drawing.Color.White;
            this.btnAddCandidate.Location = new System.Drawing.Point(57, 271);
            this.btnAddCandidate.Name = "btnAddCandidate";
            this.btnAddCandidate.Size = new System.Drawing.Size(216, 35);
            this.btnAddCandidate.TabIndex = 45;
            this.btnAddCandidate.Text = "Add Candidate";
            this.btnAddCandidate.UseVisualStyleBackColor = false;
            this.btnAddCandidate.Click += new System.EventHandler(this.btnAddCandidate_Click);
            // 
            // dropdownElectionList
            // 
            this.dropdownElectionList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.dropdownElectionList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropdownElectionList.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdownElectionList.FormattingEnabled = true;
            this.dropdownElectionList.Location = new System.Drawing.Point(57, 197);
            this.dropdownElectionList.MaxDropDownItems = 16;
            this.dropdownElectionList.Name = "dropdownElectionList";
            this.dropdownElectionList.Size = new System.Drawing.Size(216, 23);
            this.dropdownElectionList.TabIndex = 52;
            this.dropdownElectionList.SelectedIndexChanged += new System.EventHandler(this.dropdownElectionList_SelectedIndexChanged);
            // 
            // lblCanSuccessMsg
            // 
            this.lblCanSuccessMsg.AutoSize = true;
            this.lblCanSuccessMsg.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCanSuccessMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.lblCanSuccessMsg.Location = new System.Drawing.Point(215, 389);
            this.lblCanSuccessMsg.Name = "lblCanSuccessMsg";
            this.lblCanSuccessMsg.Size = new System.Drawing.Size(83, 20);
            this.lblCanSuccessMsg.TabIndex = 53;
            this.lblCanSuccessMsg.Text = "Candidate ";
            this.lblCanSuccessMsg.Visible = false;
            // 
            // lblCandidateList
            // 
            this.lblCandidateList.AutoSize = true;
            this.lblCandidateList.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCandidateList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.lblCandidateList.Location = new System.Drawing.Point(372, 139);
            this.lblCandidateList.Name = "lblCandidateList";
            this.lblCandidateList.Size = new System.Drawing.Size(130, 24);
            this.lblCandidateList.TabIndex = 55;
            this.lblCandidateList.Text = "Candidates";
            // 
            // listCandidateListBox
            // 
            this.listCandidateListBox.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listCandidateListBox.FormattingEnabled = true;
            this.listCandidateListBox.ItemHeight = 17;
            this.listCandidateListBox.Location = new System.Drawing.Point(376, 173);
            this.listCandidateListBox.Name = "listCandidateListBox";
            this.listCandidateListBox.Size = new System.Drawing.Size(332, 208);
            this.listCandidateListBox.TabIndex = 54;
            // 
            // frmAddCandidate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(733, 477);
            this.Controls.Add(this.lblCandidateList);
            this.Controls.Add(this.listCandidateListBox);
            this.Controls.Add(this.lblCanSuccessMsg);
            this.Controls.Add(this.dropdownElectionList);
            this.Controls.Add(this.lblElectionName);
            this.Controls.Add(this.txtCandidateName);
            this.Controls.Add(this.lblCandidateName);
            this.Controls.Add(this.lblAddCandidate);
            this.Controls.Add(this.btnAddCandidate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddCandidate";
            this.Text = "frmAddCandidate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblElectionName;
        private System.Windows.Forms.TextBox txtCandidateName;
        private System.Windows.Forms.Label lblCandidateName;
        private System.Windows.Forms.Label lblAddCandidate;
        private System.Windows.Forms.Button btnAddCandidate;
        private System.Windows.Forms.ComboBox dropdownElectionList;
        private System.Windows.Forms.Label lblCanSuccessMsg;
        private System.Windows.Forms.Label lblCandidateList;
        private System.Windows.Forms.ListBox listCandidateListBox;
    }
}