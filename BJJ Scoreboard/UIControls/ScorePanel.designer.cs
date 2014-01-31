namespace BJJA.Scoreboard.UIControls
{
    partial class ScorePanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dynamicLabel4 = new UIControls.DynamicLabel();
            this.dynamicLabel3 = new UIControls.DynamicLabel();
            this.dynamicLabel2 = new UIControls.DynamicLabel();
            this.dlScore = new UIControls.DynamicLabel();
            this.dlAdv = new UIControls.DynamicLabel();
            this.dlPenalty = new UIControls.DynamicLabel();
            this.dlMedical = new UIControls.DynamicLabel();
            this.dynamicLabel1 = new UIControls.DynamicLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.dynamicLabel4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.dynamicLabel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dynamicLabel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dlScore, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dlAdv, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dlPenalty, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dlMedical, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.dynamicLabel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(466, 203);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dynamicLabel4
            // 
            this.dynamicLabel4.BackColor = System.Drawing.Color.Transparent;
            this.dynamicLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dynamicLabel4.ForeColor = System.Drawing.Color.DarkRed;
            this.dynamicLabel4.Location = new System.Drawing.Point(395, 1);
            this.dynamicLabel4.Margin = new System.Windows.Forms.Padding(1);
            this.dynamicLabel4.Name = "dynamicLabel4";
            this.dynamicLabel4.Size = new System.Drawing.Size(70, 48);
            this.dynamicLabel4.TabIndex = 7;
            this.dynamicLabel4.Text = "Med";
            // 
            // dynamicLabel3
            // 
            this.dynamicLabel3.BackColor = System.Drawing.Color.Transparent;
            this.dynamicLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dynamicLabel3.ForeColor = System.Drawing.Color.DarkRed;
            this.dynamicLabel3.Location = new System.Drawing.Point(291, 1);
            this.dynamicLabel3.Margin = new System.Windows.Forms.Padding(1);
            this.dynamicLabel3.Name = "dynamicLabel3";
            this.dynamicLabel3.Size = new System.Drawing.Size(102, 48);
            this.dynamicLabel3.TabIndex = 6;
            this.dynamicLabel3.Text = "Pen";
            // 
            // dynamicLabel2
            // 
            this.dynamicLabel2.BackColor = System.Drawing.Color.Transparent;
            this.dynamicLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dynamicLabel2.ForeColor = System.Drawing.Color.DarkGreen;
            this.dynamicLabel2.Location = new System.Drawing.Point(187, 1);
            this.dynamicLabel2.Margin = new System.Windows.Forms.Padding(1);
            this.dynamicLabel2.Name = "dynamicLabel2";
            this.dynamicLabel2.Size = new System.Drawing.Size(102, 48);
            this.dynamicLabel2.TabIndex = 5;
            this.dynamicLabel2.Text = "Adv";
            // 
            // dlScore
            // 
            this.dlScore.BackColor = System.Drawing.Color.Transparent;
            this.dlScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlScore.Location = new System.Drawing.Point(1, 51);
            this.dlScore.Margin = new System.Windows.Forms.Padding(1);
            this.dlScore.Name = "dlScore";
            this.dlScore.Size = new System.Drawing.Size(184, 151);
            this.dlScore.TabIndex = 0;
            this.dlScore.Text = "00";
            // 
            // dlAdv
            // 
            this.dlAdv.BackColor = System.Drawing.Color.Transparent;
            this.dlAdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlAdv.ForeColor = System.Drawing.Color.DarkGreen;
            this.dlAdv.Location = new System.Drawing.Point(187, 51);
            this.dlAdv.Margin = new System.Windows.Forms.Padding(1);
            this.dlAdv.Name = "dlAdv";
            this.dlAdv.Size = new System.Drawing.Size(102, 151);
            this.dlAdv.TabIndex = 1;
            this.dlAdv.Text = "00";
            // 
            // dlPenalty
            // 
            this.dlPenalty.BackColor = System.Drawing.Color.Transparent;
            this.dlPenalty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlPenalty.ForeColor = System.Drawing.Color.DarkRed;
            this.dlPenalty.Location = new System.Drawing.Point(291, 51);
            this.dlPenalty.Margin = new System.Windows.Forms.Padding(1);
            this.dlPenalty.Name = "dlPenalty";
            this.dlPenalty.Size = new System.Drawing.Size(102, 151);
            this.dlPenalty.TabIndex = 2;
            this.dlPenalty.Text = "00";
            // 
            // dlMedical
            // 
            this.dlMedical.BackColor = System.Drawing.Color.Transparent;
            this.dlMedical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlMedical.ForeColor = System.Drawing.Color.DarkRed;
            this.dlMedical.Location = new System.Drawing.Point(395, 51);
            this.dlMedical.Margin = new System.Windows.Forms.Padding(1);
            this.dlMedical.Name = "dlMedical";
            this.dlMedical.Size = new System.Drawing.Size(70, 151);
            this.dlMedical.TabIndex = 3;
            this.dlMedical.Text = "++";
            // 
            // dynamicLabel1
            // 
            this.dynamicLabel1.BackColor = System.Drawing.Color.Transparent;
            this.dynamicLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dynamicLabel1.Location = new System.Drawing.Point(1, 1);
            this.dynamicLabel1.Margin = new System.Windows.Forms.Padding(1);
            this.dynamicLabel1.Name = "dynamicLabel1";
            this.dynamicLabel1.Size = new System.Drawing.Size(184, 48);
            this.dynamicLabel1.TabIndex = 4;
            this.dynamicLabel1.Text = "Score";
            // 
            // ScorePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ScorePanel";
            this.Size = new System.Drawing.Size(466, 203);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DynamicLabel dlScore;
        private DynamicLabel dlAdv;
        private DynamicLabel dlPenalty;
        private DynamicLabel dlMedical;
        private DynamicLabel dynamicLabel4;
        private DynamicLabel dynamicLabel3;
        private DynamicLabel dynamicLabel2;
        private DynamicLabel dynamicLabel1;
    }
}
