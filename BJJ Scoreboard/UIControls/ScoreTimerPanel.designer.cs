namespace BJJA.Scoreboard.UIControls
{
    partial class ScoreTimerPanel
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
            this.dynamicLabel1 = new UIControls.DynamicLabel();
            this.SuspendLayout();
            // 
            // dynamicLabel1
            // 
            this.dynamicLabel1.BackColor = System.Drawing.Color.Transparent;
            this.dynamicLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dynamicLabel1.Location = new System.Drawing.Point(0, 0);
            this.dynamicLabel1.Name = "dynamicLabel1";
            this.dynamicLabel1.Size = new System.Drawing.Size(174, 97);
            this.dynamicLabel1.TabIndex = 0;
            this.dynamicLabel1.Text = "5:00";
            // 
            // ScoreTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dynamicLabel1);
            this.Name = "ScoreTimer";
            this.Size = new System.Drawing.Size(174, 97);
            this.ResumeLayout(false);

        }

        #endregion

        private DynamicLabel dynamicLabel1;
    }
}
