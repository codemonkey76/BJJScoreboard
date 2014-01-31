using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using BJJA.Scoreboard.Classes;

namespace BJJA.Scoreboard
{
    public partial class Form1 : Form, IScorePanel
    {
        SizeF a = SizeF.Empty;
        int iWidth = 600;
        int iHeight = 330;

        public Form1()
        {
            InitializeComponent();
            
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.AutoScaleMode = AutoScaleMode.None;
            
        }
        float ChooseFont(float s, bool small)
        {
            float f = (float)150;
            
            if (small)
            {
                f = (float)18;
                if (s < 0.43)
                    f = (float)4;
                else if (s < 0.5)
                    f = (float)6;
                else if (s < 0.95)
                    f = (float)7;
                else if (s < 1.2)
                    f = (float)8.25;
                else if (s < 1.4)
                    f = (float)12;
                else if (s < 1.6)
                    f = (float)16;
                else if (s < 2)
                    f = (float)22;                                
            }
            else
            {
                if (s < 0.43)
                    f = (float)14;
                else if (s < 0.5)
                    f = (float)18;
                else if (s < 1.0)
                    f = (float)22;
                else if (s < 2)
                    f = (float)48;
                else if (s < 2.3)
                    f = (float)72;
                else if (s < 3)
                    f = (float)120;
            }
            return f;
            
        }
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            this.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            
            a = new SizeF((float)this.Width / iWidth, (float)this.Height / iHeight);
            float w, h;
            
            w = (float)this.Width / iWidth;
            h = (float)this.Height / iHeight;
            float s = (w < h) ? w : h;

            float lSize = ChooseFont(s, false);
            float sSize = ChooseFont(s, true);
            Font f = new Font("Microsoft Sans Serif", lSize);
            Font f2 = new Font("Microsoft Sans Serif", sSize, FontStyle.Bold);
            Debug.WriteLine("s = " + s.ToString() + ", f = " + lSize + ", f2 = " + sSize);
            
            this.lScore.Font = f;
            this.lAdv.Font = f;
            this.lMedical.Font = f;
            this.lPen.Font = f;
            this.lute.Font = f;
            this.lTime.Font = f;
            this.colon.Font = f;
            this.rScore.Font = f;
            this.rAdv.Font = f;
            this.rMedical.Font = f;
            this.rPen.Font = f;
            this.rTime.Font = f;

            this.lblScoreL.Font = f2;
            this.lblADVL.Font = f2;
            this.lblMEDL.Font = f2;
            this.lblPENL.Font = f2;
            this.lblLUTE.Font = f2;
            this.lblTIME.Font = f2;
            this.lblScoreR.Font = f2;
            this.lblADVR.Font = f2;
            this.lblMEDR.Font = f2;
            this.lblPENR.Font = f2;
            
            this.tableLayoutPanel1.ResumeLayout();
            this.ResumeLayout();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
        }
    }
}
