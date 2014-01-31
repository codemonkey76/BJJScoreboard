using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BJJA.Scoreboard.Classes;

namespace BJJA.Scoreboard
{
    public partial class ScorePanelForm : Form
    {
        MatchScore _ms;
        ScoreTimer _st;
        Competitor_Details _details;
        public ScorePanelForm(MatchScore ms, ScoreTimer st, Competitor_Details details)
        {
            InitializeComponent();
            _ms = ms;
            _st = st;
            _details = details;
            whiteScorePanel.MouseDoubleClick+=new MouseEventHandler(ScorePanelForm_DoubleClick);
            colorScorePanel.MouseDoubleClick += new MouseEventHandler(ScorePanelForm_DoubleClick);
            scoreTimer.MouseDoubleClick += new MouseEventHandler(ScorePanelForm_DoubleClick);
            BindControls();
        }

        void BindControls()
        {
            whiteScorePanel.DataBindings.Add(new Binding("Score", _ms.White, "Score"));
            whiteScorePanel.DataBindings.Add(new Binding("Advantage", _ms.White, "Adv"));
            whiteScorePanel.DataBindings.Add(new Binding("Penalty", _ms.White, "Pen"));
            whiteScorePanel.DataBindings.Add(new Binding("Medical", _ms.White, "MedicalStr"));
            
            colorScorePanel.DataBindings.Add(new Binding("Score", _ms.Blue, "Score"));
            colorScorePanel.DataBindings.Add(new Binding("Advantage", _ms.Blue, "Adv"));
            colorScorePanel.DataBindings.Add(new Binding("Penalty", _ms.Blue, "Pen"));
            colorScorePanel.DataBindings.Add(new Binding("Medical", _ms.Blue, "MedicalStr"));
            
            scoreTimer.DataBindings.Add(new Binding("Text", _st, "RemainingStr"));
            dlColorCompetitor.DataBindings.Add(new Binding("Text", _details, "ColorName"));
            dlWhiteCompetitor.DataBindings.Add(new Binding("Text", _details, "WhiteName"));
            dlDivision.DataBindings.Add(new Binding("Text", _details, "Division"));
        }

        private void ScorePanelForm_DoubleClick(object sender, EventArgs e)
        {
            if (this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.Sizable)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
            }
        }
    }
}
