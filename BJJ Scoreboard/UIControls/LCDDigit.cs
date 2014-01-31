using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using BJJA.Scoreboard.UIControls.Classes;

namespace BJJA.Scoreboard.UIControls
{
    public class LCDDigit : Control
    {
        Color On;
        Color Off;
        Color Bg;
        LCDParts parts;
        public Color OffColour
        {
            get { return Off; }
            set { Off = value; this.Invalidate(); }
        }
        public LCDDigit()
        {
            this.SetStyle(
           ControlStyles.ResizeRedraw |
           ControlStyles.UserPaint |
           ControlStyles.AllPaintingInWmPaint |
           ControlStyles.DoubleBuffer,
           true);

            this.Size = new System.Drawing.Size(100, 200);
            this.Off = Color.FromArgb(152,196,124);
            this.Bg = Color.FromArgb(159, 207, 130);
            this.On = Color.FromArgb(57,74,47);
            this.BackColor = this.Bg;
            this.ForeColor = this.On;
            this.Padding = new Padding(4);
            SetupLCD();
            parts.Value = -1;
        }
        public int Value
        {
            get { return parts.Value; }
            set
            {
                parts.Value = value;
                this.Invalidate(this.ClientRectangle);
            }
        }
        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            if (parts != null)
            {
                int value = parts.Value;
                SetupLCD();
                parts.Value = value;
                this.Invalidate();
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (parts != null)
            {
                int value = parts.Value;
                SetupLCD();
                parts.Value = value;
                this.Invalidate();
            }
        }
        void SetupLCD()
        {
            parts = new LCDParts();

            LCDPart p1 = new LCDPart();
            p1.AddPoint(this.Padding.Left + this.Padding.Left / 2, this.Padding.Top);
            p1.AddPoint(this.Width - this.Padding.Right - this.Padding.Right / 2, this.Padding.Top);
            p1.AddPoint(this.Width - this.Padding.Right - this.Padding.Right / 2 - this.Width / 5, this.Padding.Top + this.Width / 5);
            p1.AddPoint(this.Padding.Left + this.Padding.Left / 2 + this.Width / 5, this.Padding.Top + this.Width / 5);
            parts.Add(p1);

            LCDPart p2 = new LCDPart();
            p2.AddPoint(this.Padding.Left, this.Padding.Top + this.Padding.Top / 2);
            p2.AddPoint(this.Padding.Left + this.Width / 5, this.Padding.Top + this.Padding.Top / 2 + this.Width / 5);
            p2.AddPoint(this.Padding.Left + this.Width / 5, this.Height / 2 - this.Width / 10 - this.Padding.Top / 2);
            p2.AddPoint(this.Padding.Left + this.Width / 10, this.Height / 2 - this.Padding.Top / 2);
            p2.AddPoint(this.Padding.Left, this.Height / 2 - this.Width / 10 - this.Padding.Top / 2);
            parts.Add(p2);

            LCDPart p3 = new LCDPart();
            p3.AddPoint(this.Width - this.Padding.Right, this.Padding.Top + this.Padding.Top / 2);
            p3.AddPoint(this.Width - this.Padding.Right - this.Width / 5, this.Padding.Top + this.Padding.Top / 2 + this.Width / 5);
            p3.AddPoint(this.Width - this.Padding.Right - this.Width / 5, this.Height / 2 - this.Width / 10 - this.Padding.Top / 2);
            p3.AddPoint(this.Width - this.Padding.Right - this.Width / 10, this.Height / 2 - this.Padding.Top / 2);
            p3.AddPoint(this.Width - this.Padding.Right, this.Height / 2 - this.Padding.Top / 2 - this.Width / 10);
            parts.Add(p3);

            LCDPart p4 = new LCDPart();
            p4.AddPoint(this.Padding.Left + this.Width / 10 + this.Padding.Left / 2, this.Height / 2);
            p4.AddPoint(this.Padding.Left + this.Width / 5 + this.Padding.Left / 2, this.Height / 2 - this.Width / 10);
            p4.AddPoint(this.Width - this.Padding.Right - this.Width / 5 - this.Padding.Right / 2, this.Height / 2 - this.Width / 10);
            p4.AddPoint(this.Width - this.Padding.Right - this.Width / 10 - this.Padding.Right / 2, this.Height / 2);
            p4.AddPoint(this.Width - this.Padding.Right - this.Width / 5 - this.Padding.Right / 2, this.Height / 2 + this.Width / 10);
            p4.AddPoint(this.Padding.Left + this.Width / 5 + this.Padding.Left / 2, this.Height / 2 + this.Width / 10);
            parts.Add(p4);

            LCDPart p5 = new LCDPart();
            p5.AddPoint(this.Padding.Left + this.Width / 10, this.Height / 2 + this.Padding.Top / 2);
            p5.AddPoint(this.Padding.Left + this.Width / 5, this.Height / 2 + this.Padding.Top / 2 + this.Width / 10);
            p5.AddPoint(this.Padding.Left + this.Width / 5, this.Height - this.Padding.Bottom - this.Width / 5 - this.Padding.Bottom / 2);
            p5.AddPoint(this.Padding.Left, this.Height - this.Padding.Bottom - this.Padding.Bottom / 2);
            p5.AddPoint(this.Padding.Left, this.Height / 2 + this.Padding.Top / 2 + this.Width / 10);
            parts.Add(p5);

            LCDPart p6 = new LCDPart();
            p6.AddPoint(this.Width - this.Padding.Right - this.Width / 10, this.Height / 2 + this.Padding.Top / 2);
            p6.AddPoint(this.Width - this.Padding.Right, this.Height / 2 + this.Padding.Top / 2 + this.Width / 10);
            p6.AddPoint(this.Width - this.Padding.Right, this.Height - this.Padding.Bottom - this.Padding.Bottom / 2);
            p6.AddPoint(this.Width - this.Padding.Right - this.Width / 5, this.Height - this.Padding.Bottom - this.Width / 5 - this.Padding.Bottom / 2);
            p6.AddPoint(this.Width - this.Padding.Right - this.Width / 5, this.Height / 2 + this.Padding.Top / 2 + this.Width / 10);
            parts.Add(p6);

            LCDPart p7 = new LCDPart();
            p7.AddPoint(this.Padding.Left + this.Width / 5 + this.Padding.Left / 2, this.Height - this.Padding.Bottom - this.Width / 5);
            p7.AddPoint(this.Width - this.Padding.Right - this.Width / 5 - this.Padding.Right / 2, this.Height - this.Padding.Bottom - this.Width / 5);
            p7.AddPoint(this.Width - this.Padding.Right - this.Padding.Right / 2, this.Height - this.Padding.Bottom);
            p7.AddPoint(this.Padding.Left + this.Padding.Left / 2, this.Height - this.Padding.Bottom);
            parts.Add(p7);            
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush onB = new SolidBrush(this.ForeColor);
            Brush offB = new SolidBrush(this.Off);

            foreach (LCDPart p in parts)
            {
                if (p.On)
                    g.FillPolygon(onB, p.Points);
                else
                    g.FillPolygon(offB, p.Points);
            }
            
            onB.Dispose();
            offB.Dispose();
            base.OnPaint(e);
            return;
        }
    }
}
