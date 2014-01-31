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
    public partial class BJJScorePanel : Form
    {
        MatchScore _ms;
        ScoreTimer _st;
        public BJJScorePanel(MatchScore ms, ScoreTimer st)
        {
            InitializeComponent();
            _ms = ms;
            _st = st;
            BindControls();
        }
        void BindControls()
        {
            whiteA1.DataBindings.Add(new Binding("Value", _ms.White, "ScoreA1"));
            whiteA2.DataBindings.Add(new Binding("Value", _ms.White, "ScoreA2"));
            whiteS1.DataBindings.Add(new Binding("Value", _ms.White, "ScoreS1"));
            whiteS2.DataBindings.Add(new Binding("Value", _ms.White, "ScoreS2"));
            whiteP1.DataBindings.Add(new Binding("Value", _ms.White, "ScoreP1"));
            whiteP2.DataBindings.Add(new Binding("Value", _ms.White, "ScoreP2"));
            whiteMed1.DataBindings.Add(new Binding("Value", _ms.White, "Med1"));
            whiteMed2.DataBindings.Add(new Binding("Value", _ms.White, "Med2"));

            blueA1.DataBindings.Add(new Binding("Value", _ms.Blue, "ScoreA1"));
            blueA2.DataBindings.Add(new Binding("Value", _ms.Blue, "ScoreA2"));
            blueS1.DataBindings.Add(new Binding("Value", _ms.Blue, "ScoreS1"));
            blueS2.DataBindings.Add(new Binding("Value", _ms.Blue, "ScoreS2"));
            blueP1.DataBindings.Add(new Binding("Value", _ms.Blue, "ScoreP1"));
            blueP2.DataBindings.Add(new Binding("Value", _ms.Blue, "ScoreP2"));
            blueMed1.DataBindings.Add(new Binding("Value", _ms.Blue, "Med1"));
            blueMed2.DataBindings.Add(new Binding("Value", _ms.Blue, "Med2"));

            time1.DataBindings.Add(new Binding("Value", _st, "Time1"));
            time2.DataBindings.Add(new Binding("Value", _st, "Time2"));
            time3.DataBindings.Add(new Binding("Value", _st, "Time3"));
            time4.DataBindings.Add(new Binding("Value", _st, "Time4"));
            
            lute1.DataBindings.Add(new Binding("Value", _st, "Lute1"));
            lute2.DataBindings.Add(new Binding("Value", _st, "Lute2"));
            lute3.DataBindings.Add(new Binding("Value", _st, "Lute3"));
            lute4.DataBindings.Add(new Binding("Value", _st, "Lute4"));

            whiteA1.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "whiteAdvOn"));
            whiteA1.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "whiteAdvOff"));
            whiteA1.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "whiteAdvBg"));

            whiteA2.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "whiteAdvOn"));
            whiteA2.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "whiteAdvOff"));
            whiteA2.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "whiteAdvBg"));

            whiteS1.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "whiteScoreOn"));
            whiteS1.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "whiteScoreOff"));
            whiteS1.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "whiteScoreBg"));

            whiteS2.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "whiteScoreOn"));
            whiteS2.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "whiteScoreOff"));
            whiteS2.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "whiteScoreBg"));

            whiteP1.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "whitePenOn"));
            whiteP1.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "whitePenOff"));
            whiteP1.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "whitePenBg"));

            whiteP2.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "whitePenOn"));
            whiteP2.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "whitePenOff"));
            whiteP2.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "whitePenBg"));

            blueA1.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "blueAdvOn"));
            blueA1.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "blueAdvOff"));
            blueA1.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "blueAdvBg"));

            blueA2.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "blueAdvOn"));
            blueA2.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "blueAdvOff"));
            blueA2.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "blueAdvBg"));

            blueS1.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "blueScoreOn"));
            blueS1.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "blueScoreOff"));
            blueS1.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "blueScoreBg"));

            blueS2.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "blueScoreOn"));
            blueS2.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "blueScoreOff"));
            blueS2.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "blueScoreBg"));

            blueP1.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "bluePenOn"));
            blueP1.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "bluePenOff"));
            blueP1.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "bluePenBg"));

            blueP2.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "bluePenOn"));
            blueP2.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "bluePenOff"));
            blueP2.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "bluePenBg"));            

            lute1.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "luteOn"));
            lute1.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "luteOff"));
            lute1.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "luteBg"));

            lute2.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "luteOn"));
            lute2.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "luteOff"));
            lute2.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "luteBg"));

            lute3.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "luteOn"));
            lute3.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "luteOff"));
            lute3.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "luteBg"));

            lute4.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "luteOn"));
            lute4.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "luteOff"));
            lute4.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "luteBg"));

            luteColon.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "luteOn"));
            luteColon.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "luteBg"));
            luteColon.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "luteBg"));
            
            time1.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "timeOn"));
            time1.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "timeOff"));
            time1.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "timeBg"));

            time2.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "timeOn"));
            time2.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "timeOff"));
            time2.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "timeBg"));

            time3.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "timeOn"));
            time3.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "timeOff"));
            time3.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "timeBg"));

            time4.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "timeOn"));
            time4.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "timeOff"));
            time4.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "timeBg"));

            timeColon.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "timeOn"));
            timeColon.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "timeBg"));
            timeColon.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "timeBg"));

            whiteMed1.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "whiteMedicalOn"));
            whiteMed1.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "whiteMedicalOff"));
            whiteMed1.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "whiteMedicalBg"));

            whiteMed2.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "whiteMedicalOn"));
            whiteMed2.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "whiteMedicalOff"));
            whiteMed2.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "whiteMedicalBg"));

            blueMed1.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "blueMedicalOn"));
            blueMed1.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "blueMedicalOff"));
            blueMed1.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "blueMedicalBg"));

            blueMed2.DataBindings.Add(new Binding("ForeColor", Properties.Settings.Default, "blueMedicalOn"));
            blueMed2.DataBindings.Add(new Binding("OffColour", Properties.Settings.Default, "blueMedicalOff"));
            blueMed2.DataBindings.Add(new Binding("BackColor", Properties.Settings.Default, "blueMedicalBg"));
        }
    }
}
