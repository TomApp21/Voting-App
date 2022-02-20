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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblViewElectionScores = new System.Windows.Forms.Label();
            this.chartElectionScore = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dropdownElectionList = new System.Windows.Forms.ComboBox();
            this.lblElectionName = new System.Windows.Forms.Label();
            this.lblFinished = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartElectionScore)).BeginInit();
            this.SuspendLayout();
            // 
            // lblViewElectionScores
            // 
            this.lblViewElectionScores.AutoSize = true;
            this.lblViewElectionScores.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViewElectionScores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.lblViewElectionScores.Location = new System.Drawing.Point(39, 32);
            this.lblViewElectionScores.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblViewElectionScores.Name = "lblViewElectionScores";
            this.lblViewElectionScores.Size = new System.Drawing.Size(215, 36);
            this.lblViewElectionScores.TabIndex = 48;
            this.lblViewElectionScores.Text = "View Scores";
            // 
            // chartElectionScore
            // 
            chartArea1.Name = "ChartArea1";
            this.chartElectionScore.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartElectionScore.Legends.Add(legend1);
            this.chartElectionScore.Location = new System.Drawing.Point(132, 217);
            this.chartElectionScore.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartElectionScore.Name = "chartElectionScore";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Candidates";
            this.chartElectionScore.Series.Add(series1);
            this.chartElectionScore.Size = new System.Drawing.Size(927, 462);
            this.chartElectionScore.TabIndex = 49;
            this.chartElectionScore.Text = "chart1";
            // 
            // dropdownElectionList
            // 
            this.dropdownElectionList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.dropdownElectionList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropdownElectionList.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdownElectionList.FormattingEnabled = true;
            this.dropdownElectionList.Location = new System.Drawing.Point(45, 114);
            this.dropdownElectionList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dropdownElectionList.MaxDropDownItems = 16;
            this.dropdownElectionList.Name = "dropdownElectionList";
            this.dropdownElectionList.Size = new System.Drawing.Size(322, 33);
            this.dropdownElectionList.TabIndex = 54;
            this.dropdownElectionList.SelectedIndexChanged += new System.EventHandler(this.dropdownElectionList_SelectedIndexChanged_1);
            // 
            // lblElectionName
            // 
            this.lblElectionName.AutoSize = true;
            this.lblElectionName.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElectionName.Location = new System.Drawing.Point(40, 83);
            this.lblElectionName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblElectionName.Name = "lblElectionName";
            this.lblElectionName.Size = new System.Drawing.Size(162, 28);
            this.lblElectionName.TabIndex = 53;
            this.lblElectionName.Text = "Choose Election";
            // 
            // lblFinished
            // 
            this.lblFinished.AutoSize = true;
            this.lblFinished.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinished.Location = new System.Drawing.Point(405, 119);
            this.lblFinished.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFinished.Name = "lblFinished";
            this.lblFinished.Size = new System.Drawing.Size(0, 28);
            this.lblFinished.TabIndex = 55;
            // 
            // frmViewElScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 734);
            this.Controls.Add(this.lblFinished);
            this.Controls.Add(this.dropdownElectionList);
            this.Controls.Add(this.lblElectionName);
            this.Controls.Add(this.chartElectionScore);
            this.Controls.Add(this.lblViewElectionScores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
        private System.Windows.Forms.Label lblFinished;
    }
}