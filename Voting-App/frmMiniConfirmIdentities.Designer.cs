namespace Voting_App
{
    partial class frmMiniConfirmIdentities
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
            this.lblUsersAwaitingReg = new System.Windows.Forms.Label();
            this.listElectionListBox = new System.Windows.Forms.ListBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtboxLastName = new System.Windows.Forms.TextBox();
            this.lblDOB = new System.Windows.Forms.Label();
            this.txtBoxDob = new System.Windows.Forms.TextBox();
            this.bllNi = new System.Windows.Forms.Label();
            this.txtNatIns = new System.Windows.Forms.TextBox();
            this.lblAddressLine1 = new System.Windows.Forms.Label();
            this.txtAddLine1 = new System.Windows.Forms.TextBox();
            this.btnDeny = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.lblConfirmation = new System.Windows.Forms.Label();
            this.txtElection = new System.Windows.Forms.TextBox();
            this.lblElection = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUsersAwaitingReg
            // 
            this.lblUsersAwaitingReg.AutoSize = true;
            this.lblUsersAwaitingReg.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsersAwaitingReg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.lblUsersAwaitingReg.Location = new System.Drawing.Point(26, 21);
            this.lblUsersAwaitingReg.Name = "lblUsersAwaitingReg";
            this.lblUsersAwaitingReg.Size = new System.Drawing.Size(309, 24);
            this.lblUsersAwaitingReg.TabIndex = 47;
            this.lblUsersAwaitingReg.Text = "Users Awaiting Registration";
            // 
            // listElectionListBox
            // 
            this.listElectionListBox.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listElectionListBox.FormattingEnabled = true;
            this.listElectionListBox.ItemHeight = 17;
            this.listElectionListBox.Location = new System.Drawing.Point(30, 70);
            this.listElectionListBox.Name = "listElectionListBox";
            this.listElectionListBox.Size = new System.Drawing.Size(199, 378);
            this.listElectionListBox.TabIndex = 46;
            this.listElectionListBox.SelectedIndexChanged += new System.EventHandler(this.listElectionListBox_SelectedIndexChanged);
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(242, 76);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(75, 17);
            this.lblFirstName.TabIndex = 51;
            this.lblFirstName.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFirstName.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtFirstName.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtFirstName.Location = new System.Drawing.Point(245, 96);
            this.txtFirstName.Multiline = true;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.ReadOnly = true;
            this.txtFirstName.Size = new System.Drawing.Size(216, 28);
            this.txtFirstName.TabIndex = 52;
            this.txtFirstName.TabStop = false;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblLastName.Location = new System.Drawing.Point(242, 134);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(73, 17);
            this.lblLastName.TabIndex = 53;
            this.lblLastName.Text = "Last Name";
            // 
            // txtboxLastName
            // 
            this.txtboxLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtboxLastName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtboxLastName.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtboxLastName.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtboxLastName.Location = new System.Drawing.Point(245, 154);
            this.txtboxLastName.Multiline = true;
            this.txtboxLastName.Name = "txtboxLastName";
            this.txtboxLastName.ReadOnly = true;
            this.txtboxLastName.Size = new System.Drawing.Size(216, 28);
            this.txtboxLastName.TabIndex = 54;
            this.txtboxLastName.TabStop = false;
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblDOB.Location = new System.Drawing.Point(242, 194);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(88, 17);
            this.lblDOB.TabIndex = 55;
            this.lblDOB.Text = "Date of Birth";
            // 
            // txtBoxDob
            // 
            this.txtBoxDob.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtBoxDob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxDob.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtBoxDob.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtBoxDob.Location = new System.Drawing.Point(245, 214);
            this.txtBoxDob.Multiline = true;
            this.txtBoxDob.Name = "txtBoxDob";
            this.txtBoxDob.ReadOnly = true;
            this.txtBoxDob.Size = new System.Drawing.Size(216, 28);
            this.txtBoxDob.TabIndex = 56;
            this.txtBoxDob.TabStop = false;
            // 
            // bllNi
            // 
            this.bllNi.AutoSize = true;
            this.bllNi.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.bllNi.Location = new System.Drawing.Point(242, 251);
            this.bllNi.Name = "bllNi";
            this.bllNi.Size = new System.Drawing.Size(124, 17);
            this.bllNi.TabIndex = 58;
            this.bllNi.Text = "National Insurance";
            // 
            // txtNatIns
            // 
            this.txtNatIns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtNatIns.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNatIns.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtNatIns.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtNatIns.Location = new System.Drawing.Point(245, 271);
            this.txtNatIns.Multiline = true;
            this.txtNatIns.Name = "txtNatIns";
            this.txtNatIns.ReadOnly = true;
            this.txtNatIns.Size = new System.Drawing.Size(216, 28);
            this.txtNatIns.TabIndex = 59;
            this.txtNatIns.TabStop = false;
            // 
            // lblAddressLine1
            // 
            this.lblAddressLine1.AutoSize = true;
            this.lblAddressLine1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressLine1.Location = new System.Drawing.Point(478, 76);
            this.lblAddressLine1.Name = "lblAddressLine1";
            this.lblAddressLine1.Size = new System.Drawing.Size(61, 17);
            this.lblAddressLine1.TabIndex = 43;
            this.lblAddressLine1.Text = "Address ";
            // 
            // txtAddLine1
            // 
            this.txtAddLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtAddLine1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddLine1.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtAddLine1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtAddLine1.Location = new System.Drawing.Point(481, 96);
            this.txtAddLine1.Multiline = true;
            this.txtAddLine1.Name = "txtAddLine1";
            this.txtAddLine1.ReadOnly = true;
            this.txtAddLine1.Size = new System.Drawing.Size(216, 86);
            this.txtAddLine1.TabIndex = 44;
            this.txtAddLine1.TabStop = false;
            // 
            // btnDeny
            // 
            this.btnDeny.BackColor = System.Drawing.Color.White;
            this.btnDeny.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeny.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeny.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeny.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btnDeny.Location = new System.Drawing.Point(360, 392);
            this.btnDeny.Name = "btnDeny";
            this.btnDeny.Size = new System.Drawing.Size(216, 35);
            this.btnDeny.TabIndex = 61;
            this.btnDeny.Text = "Deny";
            this.btnDeny.UseVisualStyleBackColor = false;
            this.btnDeny.Click += new System.EventHandler(this.btnDeny_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btnApprove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApprove.FlatAppearance.BorderSize = 0;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(360, 351);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(216, 35);
            this.btnApprove.TabIndex = 60;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // lblConfirmation
            // 
            this.lblConfirmation.AutoSize = true;
            this.lblConfirmation.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmation.Location = new System.Drawing.Point(243, 314);
            this.lblConfirmation.Name = "lblConfirmation";
            this.lblConfirmation.Size = new System.Drawing.Size(74, 17);
            this.lblConfirmation.TabIndex = 62;
            this.lblConfirmation.Text = "lblConfirm";
            this.lblConfirmation.Visible = false;
            // 
            // txtElection
            // 
            this.txtElection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtElection.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtElection.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtElection.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtElection.Location = new System.Drawing.Point(481, 214);
            this.txtElection.Multiline = true;
            this.txtElection.Name = "txtElection";
            this.txtElection.ReadOnly = true;
            this.txtElection.Size = new System.Drawing.Size(216, 28);
            this.txtElection.TabIndex = 64;
            this.txtElection.TabStop = false;
            // 
            // lblElection
            // 
            this.lblElection.AutoSize = true;
            this.lblElection.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblElection.Location = new System.Drawing.Point(478, 194);
            this.lblElection.Name = "lblElection";
            this.lblElection.Size = new System.Drawing.Size(125, 17);
            this.lblElection.TabIndex = 63;
            this.lblElection.Text = "Requested Election";
            // 
            // frmMiniConfirmIdentities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(733, 477);
            this.Controls.Add(this.txtElection);
            this.Controls.Add(this.lblElection);
            this.Controls.Add(this.lblConfirmation);
            this.Controls.Add(this.btnDeny);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.txtNatIns);
            this.Controls.Add(this.bllNi);
            this.Controls.Add(this.txtBoxDob);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.txtAddLine1);
            this.Controls.Add(this.lblAddressLine1);
            this.Controls.Add(this.txtboxLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblUsersAwaitingReg);
            this.Controls.Add(this.listElectionListBox);
            this.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "frmMiniConfirmIdentities";
            this.Text = "frmMiniConfirmIdentities";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsersAwaitingReg;
        private System.Windows.Forms.ListBox listElectionListBox;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtboxLastName;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.TextBox txtBoxDob;
        private System.Windows.Forms.Label bllNi;
        private System.Windows.Forms.TextBox txtNatIns;
        private System.Windows.Forms.Label lblAddressLine1;
        private System.Windows.Forms.TextBox txtAddLine1;
        private System.Windows.Forms.Button btnDeny;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Label lblConfirmation;
        private System.Windows.Forms.TextBox txtElection;
        private System.Windows.Forms.Label lblElection;
    }
}