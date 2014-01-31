using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BJJA.Scoreboard.UIControls
{
    public partial class ScoreTimerPanel : UserControl
    {
        public override string Text
        {
            get { return dynamicLabel1.Text; }
            set { dynamicLabel1.Text = value; }
        }

        public ScoreTimerPanel()
        {
            InitializeComponent();
            dynamicLabel1.MouseDoubleClick += new MouseEventHandler(dynamicLabel1_MouseDoubleClick);
        }

        void dynamicLabel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.OnMouseDoubleClick(e);
        }        
    }
}
