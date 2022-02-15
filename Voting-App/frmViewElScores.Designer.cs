namespace Voting_App
{
    partial class frmViewElScores
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblViewElectionScores = new System.Windows.Forms.Label();
            this.chartElectionScore = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dropdownElectionList = new System.Windows.Forms.ComboBox();
            this.lblElectionName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartElectionScore)).BeginInit();
            this.SuspendLayout();
            // 
            // lblViewElectionScores
            // 
            this.lblViewElectionScores.AutoSize = true;
            this.lblViewElectionScores.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViewElectionScores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.lblViewElectionScores.Location = new System.Drawing.Point(26, 21);
            this.lblViewElectionScores.Name = "lblViewElectionScores";
            this.lblViewElectionScores.Size = new System.Drawing.Size(145, 24);
            this.lblViewElectionScores.TabIndex = 48;
            this.lblViewElectionScores.Text = "View Scores";
            // 
            // chartElectionScore
            // 
            chartArea2.Name = "ChartArea1";
            this.chartElectionScore.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartElectionScore.Legends.Add(legend2);
            this.chartElectionScore.Location = new System.Drawing.Point(88, 141);
            this.chartElectionScore.Name = "chartElectionScore";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Candidates";
            this.chartElectionScore.Series.Add(series2);
            this.chartElectionScore.Size = new System.Drawing.Size(618, 300);
            this.chartElectionScore.TabIndex = 49;
            this.chartElectionScore.Text = "chart1";
            // 
            // dropdownElectionList
            // 
            this.dropdownElectionList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.dropdownElectionList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropdownElectionList.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdownElectionList.FormattingEnabled = true;
            this.dropdownElectionList.Location = new System.Drawing.Point(30, 74);
            this.dropdownElectionList.MaxDropDownItems = 16;
            this.dropdownElectionList.Name = "dropdownElectionList";
            this.dropdownElectionList.Size = new System.Drawing.Size(216, 23);
            this.dropdownElectionList.TabIndex = 54;
            this.dropdownElectionList.SelectedIndexChanged += new System.EventHandler(this.dropdownElectionList_SelectedIndexChanged_1);
            // 
            // lblElectionName
            // 
            this.lblElectionName.AutoSize = true;
            this.lblElectionName.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElectionName.Location = new System.Drawing.Point(27, 54);
            this.lblElectionName.Name = "lblElectionName";
            this.lblElectionName.Size = new System.Drawing.Size(106, 17);
            this.lblElectionName.TabIndex = 53;
            this.lblElectionName.Text = "Choose Election";
            // 
            // frmViewElScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(733, 477);
            this.Controls.Add(this.dropdownElectionList);
            this.Controls.Add(this.lblElectionName);
            this.Controls.Add(this.chartElectionScore);
            this.Controls.Add(this.lblViewElectionScores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmViewElScores";
            this.Text = "frmViewElScores";
            ((System.ComponentModel.ISupportInitialize)(this.chartElectionScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblViewElectionScores;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartElectionScore;
        private System.Windows.Forms.ComboBox dropdownElectionList;
        private System.Windows.Forms.Label lblElectionName;
    }
}