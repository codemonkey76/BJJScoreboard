using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BJJA.Scoreboard.UIControls.Classes
{
    public class LCDPart
    {
        bool _on;
        List<Point> _points;
        public bool On
        {
            get { return _on; }
            set { _on = value; }
        }
        public Point[] Points
        {
            get { return _points.ToArray(); }
        }
        public LCDPart()
        {
            _points = new List<Point>();
        }
        public void AddPoint(int x, int y)
        {
            _points.Add(new Point(x, y));
        }
    }
}
