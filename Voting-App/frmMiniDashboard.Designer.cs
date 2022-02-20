namespace Voting_App
{
    partial class frmMiniDashboard
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
            this.lblMiniTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMiniTitle
            // 
            this.lblMiniTitle.AutoSize = true;
            this.lblMiniTitle.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiniTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.lblMiniTitle.Location = new System.Drawing.Point(440, 195);
            this.lblMiniTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMiniTitle.Name = "lblMiniTitle";
            this.lblMiniTitle.Size = new System.Drawing.Size(181, 44);
            this.lblMiniTitle.TabIndex = 51;
            this.lblMiniTitle.Text = "Welcome";
            // 
            // frmMiniDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1100, 734);
            this.Controls.Add(this.lblMiniTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMiniDashboard";
            this.Text = "frmMiniDashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMiniTitle;
    }
}