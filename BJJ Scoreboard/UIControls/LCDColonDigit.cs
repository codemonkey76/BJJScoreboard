using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using BJJA.Scoreboard.UIControls.Classes;

namespace BJJA.Scoreboard.UIControls
{
        public class LCDColonDigit : Control
        {
            Color On;
            Color Off;
            Color Bg;
            LCDColon parts;
            public Color OffColour
            {
                get { return Off; }
                set { Off = value; this.Invalidate(); }
            }
            public LCDColonDigit()
            {
                this.SetStyle(
               ControlStyles.ResizeRedraw |
               ControlStyles.UserPaint |
               ControlStyles.AllPaintingInWmPaint |
               ControlStyles.DoubleBuffer,
               true);

                this.Size = new System.Drawing.Size(100, 200);
                this.Off = Color.FromArgb(152, 196, 124);
                this.Bg = Color.FromArgb(159, 207, 130);
                this.On = Color.FromArgb(57, 74, 47);
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
                parts = new LCDColon();

                LCDPart p1 = new LCDPart();
                p1.AddPoint((this.Width - this.Padding.Right - this.Padding.Left) / 2 + Padding.Left - ((this.Width / 5) / 2), ((this.Height/2)-(this.Width/5)));
                p1.AddPoint((this.Width - this.Padding.Right - this.Padding.Left) / 2 + Padding.Left + ((this.Width / 5) / 2), ((this.Height / 2) - (this.Width / 5)));
                p1.AddPoint((this.Width - this.Padding.Right - this.Padding.Left) / 2 + Padding.Left + ((this.Width / 5) / 2), ((this.Height / 2) - (this.Width / 5)) + this.Width / 5);
                p1.AddPoint((this.Width - this.Padding.Right - this.Padding.Left) / 2 + Padding.Left - ((this.Width / 5) / 2), ((this.Height / 2) - (this.Width / 5)) + this.Width / 5);
                parts.Add(p1);

                LCDPart p2 = new LCDPart();
                //Cross
                p2.AddPoint(this.Width / 2 - ((this.Width / 5) / 2), this.Padding.Top); //0
                p2.AddPoint(this.Width / 2 + ((this.Width / 5) / 2), this.Padding.Top); //1
                p2.AddPoint(this.Width / 2 + ((this.Width / 5) / 2), this.Height / 2 - ((this.Width / 5) / 2)); //2
                p2.AddPoint(this.Width - this.Padding.Right, this.Height / 2 - ((this.Width / 5) / 2)); //3
                p2.AddPoint(this.Width - this.Padding.Right, this.Height / 2 + ((this.Width / 5) / 2)); //4
                p2.AddPoint(this.Width / 2 + ((this.Width / 5) / 2), this.Height / 2 + ((this.Width / 5) / 2)); //5
                p2.AddPoint(this.Width / 2 + ((this.Width / 5) / 2), this.Height - this.Padding.Bottom); //6
                p2.AddPoint(this.Width / 2 - ((this.Width / 5) / 2), this.Height - this.Padding.Bottom); //7
                p2.AddPoint(this.Width / 2 - ((this.Width / 5) / 2), this.Height / 2 + ((this.Width / 5) / 2)); //8
                p2.AddPoint(this.Padding.Left, this.Height / 2 + ((this.Width / 5) / 2)); //9
                p2.AddPoint(this.Padding.Left, this.Height / 2 - ((this.Width / 5) / 2)); //10
                p2.AddPoint(this.Width / 2 - ((this.Width / 5) / 2), this.Height / 2 - ((this.Width / 5) / 2)); //11
                parts.Add(p2);

                LCDPart p3 = new LCDPart();
                p3.AddPoint((this.Width - this.Padding.Right - this.Padding.Left) / 2 + Padding.Left - ((this.Width / 5) / 2), ((this.Height / 2) + (this.Width / 5)));
                p3.AddPoint((this.Width - this.Padding.Right - this.Padding.Left) / 2 + Padding.Left + ((this.Width / 5) / 2), ((this.Height / 2) + (this.Width / 5)));
                p3.AddPoint((this.Width - this.Padding.Right - this.Padding.Left) / 2 + Padding.Left + ((this.Width / 5) / 2), ((this.Height / 2) + (this.Width / 5)) + this.Width / 5);
                p3.AddPoint((this.Width - this.Padding.Right - this.Padding.Left) / 2 + Padding.Left - ((this.Width / 5) / 2), ((this.Height / 2) + (this.Width / 5)) + this.Width / 5);
                parts.Add(p3);

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
