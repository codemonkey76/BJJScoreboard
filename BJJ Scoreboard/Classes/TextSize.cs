using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace BJJA.Scoreboard.Classes
{
    public class TextSize
    {
        float fontSize;
        SizeF rectangle;

        public float FontSize
        {
            get { return fontSize; }
            set { fontSize = value; }
        }
        public SizeF Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }
        public TextSize(float fontSize, SizeF rectangle)
        {
            this.fontSize = fontSize;
            this.rectangle = rectangle;
        }
    }
}
