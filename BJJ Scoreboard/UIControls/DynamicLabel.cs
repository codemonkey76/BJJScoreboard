using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using BJJA.Scoreboard.Classes;

namespace BJJA.Scoreboard.UIControls
{
    public partial class DynamicLabel : Control
    {
        string _text;
        List<TextSize> sizes;
        Font textFont;

        public DynamicLabel()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.BackColor = Color.Transparent;
            GenerateSizes();
            OnResize(new EventArgs());
        }
        
        public override string Text
        {
            get
            {
                return _text;
            }
            set
            {
                if (_text != value)
                {
                    _text = value;
                    GenerateSizes();
                    OnResize(new EventArgs());
                }
            }
        }
        void GenerateSizes()
        {
            sizes = new List<TextSize>();
            
            for (float i = 450; i >= 2; i -= 0.5f)
            {
                using (Graphics g = this.CreateGraphics())
                {
                    if (_text !=null)
                        sizes.Add(new TextSize(i, g.MeasureString(_text, new Font(this.Font.FontFamily, i))));
                }               
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            using (Graphics g = this.CreateGraphics())
            {
                if (this.Text == null)
                    return;
                if ((this.Bounds.Width == 0) || (this.Bounds.Height == 0))
                    return;
                Rectangle rect = this.Bounds; //this is the size of the space we have to work with.
                //int minWidth = rect.Width - this.Margin.Horizontal * 2;
                int maxWidth = rect.Width - this.Margin.Horizontal;
                int maxHeight = rect.Height - this.Margin.Vertical;
                
                //Start from biggest size
                for (int i =0;i<sizes.Count; i++)
                {
                    if (sizes[i].Rectangle.Width <= maxWidth && sizes[i].Rectangle.Height <= maxHeight)
                    {
                        textFont = new Font(this.Font.FontFamily, sizes[i].FontSize);
                        this.Invalidate();
                        break;
                    }
                }
            }
        }        

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (textFont == null)
                OnResize(new EventArgs());
            if (textFont == null)
                return;
            using (Brush b = new SolidBrush(this.ForeColor))
            {
                using (Pen p = new Pen(b, 1f))
                {                    
                    SizeF size = e.Graphics.MeasureString(_text, textFont);
                    RectangleF bounds = e.Graphics.ClipBounds;
                    PointF pos = new PointF((bounds.Width / 2f) - (size.Width / 2f), (bounds.Height / 2f) - (size.Height / 2f));
                    e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    e.Graphics.DrawString(_text, textFont, b, pos);
                }
            }
        }
        float GetFontSize(Graphics g, Font f, string t)
        {
            const float minSize = 2f;
            const float maxSize = 450f;
            const float increment = 4f;
            const float buffer = 5f;
            RectangleF bounds = g.ClipBounds;

            //Measure the existing size first.
            while (true)
            {
                SizeF size = g.MeasureString(t, f);

                if ((size.Width < bounds.Width - buffer*4) && (size.Height < bounds.Height - buffer*4)) //font too small
                {
                    if (f.Size >= maxSize)
                        return maxSize;
                    else
                        f = new Font(f.FontFamily, f.Size + increment);
                }
                else if ((size.Width > bounds.Width - buffer * 2) || (size.Height > bounds.Height - buffer * 2)) //font too large
                {
                    if (f.Size <= minSize)
                        return minSize;
                    else
                        f = new Font(f.FontFamily, f.Size - increment);
                }
                else
                {
                    //Just Right
                    return f.Size;
                }
            }
        }
    }
}
