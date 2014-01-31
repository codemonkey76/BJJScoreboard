using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BJJA.Scoreboard.UIControls

{
    public partial class ScorePanel : UserControl
    {
        int _score;
        int _adv;
        int _penalty;
        string _medical;

        public int Score
        {
            get { return _score; }
            set {
                    _score = value;
                    dlScore.Text = value.ToString("00");             
            }
        }

        public int Advantage
        {
            get { return _adv; }
            set {
                    _adv = value;
                    dlAdv.Text = value.ToString();
            }
        }
        public int Penalty
        {
            get { return _penalty; }
            set {
                    _penalty = value;
                    dlPenalty.Text = value.ToString();
            }
        }
        public string Medical
        {
            get { return _medical; }
            set
            {
                _medical = value;
                dlMedical.Text = value;
            }
        }
        
        public ScorePanel()
        {
            InitializeComponent();
            Score = 0;
            Advantage = 0;
            Penalty = 0;
            Medical = "";
            dlScore.MouseDoubleClick += new MouseEventHandler(label_MouseDoubleClick);
            dlAdv.MouseDoubleClick += new MouseEventHandler(label_MouseDoubleClick);
            dlPenalty.MouseDoubleClick += new MouseEventHandler(label_MouseDoubleClick);
            dlMedical.MouseDoubleClick += new MouseEventHandler(label_MouseDoubleClick);
            dynamicLabel1.MouseDoubleClick += new MouseEventHandler(label_MouseDoubleClick);
            dynamicLabel2.MouseDoubleClick += new MouseEventHandler(label_MouseDoubleClick);
            dynamicLabel3.MouseDoubleClick += new MouseEventHandler(label_MouseDoubleClick);
            dynamicLabel4.MouseDoubleClick += new MouseEventHandler(label_MouseDoubleClick);
        }

        void label_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.OnMouseDoubleClick(e);
        }
    }
}
