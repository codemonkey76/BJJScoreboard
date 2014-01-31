namespace BJJA.Scoreboard
{
    partial class ScorePanelForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.whiteScorePanel = new BJJA.Scoreboard.UIControls.ScorePanel();
            this.colorScorePanel = new BJJA.Scoreboard.UIControls.ScorePanel();
            this.scoreTimer = new BJJA.Scoreboard.UIControls.ScoreTimerPanel();
            this.dlWhiteCompetitor = new BJJA.Scoreboard.UIControls.DynamicLabel();
            this.dynamicLabel2 = new BJJA.Scoreboard.UIControls.DynamicLabel();
            this.dlColorCompetitor = new BJJA.Scoreboard.UIControls.DynamicLabel();
            this.dlDivision = new BJJA.Scoreboard.UIControls.DynamicLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.whiteScorePanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.colorScorePanel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.scoreTimer, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dlWhiteCompetitor, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dynamicLabel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dlColorCompetitor, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.dlDivision, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(781, 354);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // whiteScorePanel
            // 
            this.whiteScorePanel.Advantage = 0;
            this.whiteScorePanel.BackColor = System.Drawing.Color.White;
            this.whiteScorePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.whiteScorePanel, 3);
            this.whiteScorePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.whiteScorePanel.Location = new System.Drawing.Point(0, 70);
            this.whiteScorePanel.Margin = new System.Windows.Forms.Padding(0);
            this.whiteScorePanel.Medical = "";
            this.whiteScorePanel.Name = "whiteScorePanel";
            this.whiteScorePanel.Penalty = 0;
            this.whiteScorePanel.Score = 0;
            this.whiteScorePanel.Size = new System.Drawing.Size(390, 212);
            this.whiteScorePanel.TabIndex = 0;
            // 
            // colorScorePanel
            // 
            this.colorScorePanel.Advantage = 0;
            this.colorScorePanel.BackColor = System.Drawing.Color.Yellow;
            this.colorScorePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.colorScorePanel, 2);
            this.colorScorePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorScorePanel.Location = new System.Drawing.Point(390, 70);
            this.colorScorePanel.Margin = new System.Windows.Forms.Padding(0);
            this.colorScorePanel.Medical = "";
            this.colorScorePanel.Name = "colorScorePanel";
            this.colorScorePanel.Penalty = 0;
            this.colorScorePanel.Score = 0;
            this.colorScorePanel.Size = new System.Drawing.Size(391, 212);
            this.colorScorePanel.TabIndex = 1;
            // 
            // scoreTimer
            // 
            this.scoreTimer.BackColor = System.Drawing.SystemColors.Control;
            this.scoreTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scoreTimer.Location = new System.Drawing.Point(3, 285);
            this.scoreTimer.Name = "scoreTimer";
            this.scoreTimer.Size = new System.Drawing.Size(189, 66);
            this.scoreTimer.TabIndex = 2;
            // 
            // dlWhiteCompetitor
            // 
            this.dlWhiteCompetitor.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.dlWhiteCompetitor, 2);
            this.dlWhiteCompetitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlWhiteCompetitor.Location = new System.Drawing.Point(3, 3);
            this.dlWhiteCompetitor.Name = "dlWhiteCompetitor";
            this.dlWhiteCompetitor.Size = new System.Drawing.Size(306, 64);
            this.dlWhiteCompetitor.TabIndex = 3;
            // 
            // dynamicLabel2
            // 
            this.dynamicLabel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.dynamicLabel2, 2);
            this.dynamicLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dynamicLabel2.Location = new System.Drawing.Point(315, 3);
            this.dynamicLabel2.Name = "dynamicLabel2";
            this.dynamicLabel2.Size = new System.Drawing.Size(150, 64);
            this.dynamicLabel2.TabIndex = 4;
            this.dynamicLabel2.Text = "vs";
            // 
            // dlColorCompetitor
            // 
            this.dlColorCompetitor.BackColor = System.Drawing.Color.Transparent;
            this.dlColorCompetitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlColorCompetitor.Location = new System.Drawing.Point(471, 3);
            this.dlColorCompetitor.Name = "dlColorCompetitor";
            this.dlColorCompetitor.Size = new System.Drawing.Size(307, 64);
            this.dlColorCompetitor.TabIndex = 5;
            // 
            // dlDivision
            // 
            this.dlDivision.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.dlDivision, 4);
            this.dlDivision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlDivision.Location = new System.Drawing.Point(198, 285);
            this.dlDivision.Name = "dlDivision";
            this.dlDivision.Size = new System.Drawing.Size(580, 66);
            this.dlDivision.TabIndex = 6;
            // 
            // ScorePanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(781, 354);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ScorePanelForm";
            this.Text = "Score Panel";
            this.DoubleClick += new System.EventHandler(this.ScorePanelForm_DoubleClick);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private UIControls.ScorePanel whiteScorePanel;
        private UIControls.ScorePanel colorScorePanel;
        private UIControls.ScoreTimerPanel scoreTimer;
        private UIControls.DynamicLabel dlWhiteCompetitor;
        private UIControls.DynamicLabel dynamicLabel2;
        private UIControls.DynamicLabel dlColorCompetitor;
        private UIControls.DynamicLabel dlDivision;















    }
}

