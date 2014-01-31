using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;
using System.IO;
using BJJA.Scoreboard.Classes;
using System.Deployment.Application;

namespace BJJA.Scoreboard
{
    public partial class frmControlPanel : Form
    {
        #region Internal Fields
        MatchScore _Score;
        Competitor_Details _details;
        ScoreTimer st;

        int _duration;
        Stack<MatchScore> _history;
        List<ScorePanelForm> _scorePanels;
        #endregion
        #region Public Properties
        public int Duration
        {
            get { return _duration; }
            set
            {
                if (value < 1)
                    _duration = 1;
                else if (value > 10)
                    _duration = 10;
                else
                    _duration = value;
                st.Duration = new TimeSpan(0, _duration, 0);
            }
        }
        public MatchScore Score
        {
            get { return _Score; }           
        }
        #endregion
        #region Internal Functions
        void BindControls()
        {
            lblBlueScore.DataBindings.Add(new Binding("Text", Score.Blue, "Score"));
            lblBlueAdv.DataBindings.Add(new Binding("Text", Score.Blue, "Adv"));
            lblBluePenalty.DataBindings.Add(new Binding("Text", Score.Blue, "Pen"));
            lblBlueMedical.DataBindings.Add(new Binding("Text", Score.Blue, "MedicalStr"));
         
            lblWhiteScore.DataBindings.Add(new Binding("Text", Score.White, "Score"));
            lblWhiteAdv.DataBindings.Add(new Binding("Text", Score.White, "Adv"));
            lblWhitePenalty.DataBindings.Add(new Binding("Text", Score.White, "Pen"));
            lblWhiteMedical.DataBindings.Add(new Binding("Text", Score.White, "MedicalStr"));
            lblTime.DataBindings.Add(new Binding("Text", st, "Remaining"));
            lblLuteTime.DataBindings.Add(new Binding("Text", st, "LuteTime"));

            lblColorCompetitor.DataBindings.Add(new Binding("Text", _details, "ColorName"));
            lblWhiteCompetitor.DataBindings.Add(new Binding("Text", _details, "WhiteName"));
            lblDivision.DataBindings.Add(new Binding("Text", _details, "Division"));            
        }
        void AddButtonTags()
        {
            btnBlueAddOne.Tag = new MatchScore(0, 0, 0, 0, 1, 0, 0, 0);
            btnBlueAddTwo.Tag = new MatchScore(0, 0, 0, 0, 2, 0, 0, 0);
            btnBlueAddThree.Tag = new MatchScore(0, 0, 0, 0, 3, 0, 0, 0);
            btnBlueAddFour.Tag = new MatchScore(0, 0, 0, 0, 4, 0, 0, 0);
            btnBlueAdv.Tag = new MatchScore(0, 0, 0, 0, 0, 1, 0, 0);
            btnBluePenalty.Tag = new MatchScore(0, 0, 0, 0, 0, 0, 1, 0);
            btnBlueMedical.Tag = new MatchScore(0, 0, 0, 0, 0, 0, 0, 1);
            btnBlueMinusOne.Tag = new MatchScore(0, 0, 0, 0, -1, 0, 0, 0);
            btnBlueAdvMinus.Tag = new MatchScore(0, 0, 0, 0, 0, -1, 0, 0);
            btnBluePenaltyMinus.Tag = new MatchScore(0, 0, 0, 0, 0, 0, -1, 0);
            
            btnWhiteAddOne.Tag = new MatchScore(1, 0, 0, 0, 0, 0, 0, 0);
            btnWhiteAddTwo.Tag = new MatchScore(2, 0, 0, 0, 0, 0, 0, 0);
            btnWhiteAddThree.Tag = new MatchScore(3, 0, 0, 0, 0, 0, 0, 0);
            btnWhiteAddFour.Tag = new MatchScore(4, 0, 0, 0, 0, 0, 0, 0);
            btnWhiteAdv.Tag = new MatchScore(0, 1, 0, 0, 0, 0, 0, 0);
            btnWhitePenalty.Tag = new MatchScore(0, 0, 1, 0, 0, 0, 0, 0);
            btnWhiteMedical.Tag = new MatchScore(0, 0, 0, 1, 0, 0, 0, 0);
            btnWhiteMinusOne.Tag = new MatchScore(-1, 0, 0, 0, 0, 0, 0, 0);
            btnWhiteAdvMinus.Tag = new MatchScore(0, -1, 0, 0, 0, 0, 0, 0);
            btnWhitePenaltyMinus.Tag = new MatchScore(0, 0, -1, 0, 0, 0, 0, 0);
        }
        void WarningBeep()
        {
            SystemSounds.Beep.Play();
        }
        void AddScorePanel()
        {
            ScorePanelForm f = new ScorePanelForm(Score, st, _details);
            f.Show();
            _scorePanels.Add(f);           
        }
        #endregion
        #region Constructor
        public frmControlPanel()
        {
            InitializeComponent();
            _Score = new MatchScore();
            _scorePanels = new List<ScorePanelForm>();
            _duration = 5;
            st = new ScoreTimer(this, new TimeSpan(0, Duration, 0), 100);
            st.OnMatchComplete += new ScoreTimer.MatchComplete(st_OnMatchComplete);
            st.OnLuteTimeout += new ScoreTimer.LuteTimeout(st_OnLuteTimeout);
            st.OnFlash +=new ScoreTimer.Flash(st_OnFlash);
            _history = new Stack<MatchScore>();

            _details = new Competitor_Details();
            _details.Age = "Adult";
            _details.Sex = "Male";
            _details.Skill = "Brown Belt";
            _details.Weight = "Middle";
            _details.Style = "Gi";

            AddButtonTags();
            BindControls();
            AddScorePanel();
        }
        #endregion
        #region Timer Functions
        void st_OnFlash(bool visible)
        {

        }
        void st_OnLuteTimeout()
        {
            SystemSounds.Exclamation.Play();
        }
        void st_OnMatchComplete()
        {
            string buzzer = "buzzer_01.wav";
            if (File.Exists(buzzer))
            {
                SoundPlayer sp = new SoundPlayer(buzzer);
                sp.Play();
            }
            else
                SystemSounds.Exclamation.Play();
            MessageBox.Show("Match Over");
        }
        #endregion
        #region Button Click Events
        private void btnScore_Click(object sender, EventArgs e)
        {
            MatchScore ms = (MatchScore)((Button)sender).Tag;
            if (Score.Add(ms))
                _history.Push(ms);
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            if (st.IsRunning)
            {
                WarningBeep();
                MessageBox.Show("Cannot close, while contest is in progress!");
            }
            else
            {
                Properties.Settings.Default.Save();
                Application.Exit();
            }
        }
        private void btnPause_Click(object sender, EventArgs e)
        {
            st.Pause();
        }
        private void btnReduceTime_Click(object sender, EventArgs e)
        {
            //If contest is in progress, beep at user and do nothing
            if (st.IsRunning)
                WarningBeep();
            else
            {
                Duration--;
            }
            
        }
        private void btnIncreaseTime_Click(object sender, EventArgs e)
        {
            //If contest is in progress, beep at user and do nothing
            if (st.IsRunning)
                WarningBeep();
            else
            {
                Duration++;
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (_history.Count > 0)
            {
                MatchScore ms = _history.Pop();
                Score.Subtract(ms);
            }
            else
                WarningBeep();
        }
        private void btnNewContest_Click(object sender, EventArgs e)
        {
            //If contest is in progress, beep at user and do nothing
            if (st.IsRunning)
                WarningBeep();
            else
            {
                DialogResult rslt = MessageBox.Show("Are you sure you want to end the current contest?", "End Contest", MessageBoxButtons.YesNo);
                if (rslt == DialogResult.Yes)
                {
                    _Score.Reset();
                    st.Reset();                    
                    _history.Clear();
                }
            }
        }
        private void btnLute_Click(object sender, EventArgs e)
        {
            if (st.IsRunning)
                st.Lute();
            else
                WarningBeep();
        }
        private void btnMedical_Click(object sender, EventArgs e)
        {            
            MatchScore ms = (MatchScore)((Button)sender).Tag;
            if (Score.Add(ms))
                _history.Push(ms);
            if (st.IsRunning)
                st.Pause();
        }
        #endregion
        #region Menu Click Events
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void newContestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNewContest_Click(sender, e);
        }
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Image i;
          //  if (File.Exists(Properties.Settings.Default.Background))
                //i = Image.FromFile(Properties.Settings.Default.Background);
            //else
              //  i = Properties.Resources.default_800x600;

            frmSettings f = new frmSettings();
            f.ShowDialog();
        }
        private void iBJJFRulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string file = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "RegrasEnglish2006.pdf";
            if (File.Exists(file))
                Process.Start(file);
            else
                MessageBox.Show("Cannot find rules file: " + file);
        }
        private void addScorePanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScorePanel();
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {            
            CompetitorDetailsForm f = new CompetitorDetailsForm(_details);
            DialogResult rslt = f.ShowDialog();

            if (rslt == DialogResult.OK)
            {
                _details.Age = f.Details.Age;
                _details.ColorName = f.Details.ColorName;
                _details.WhiteName = f.Details.WhiteName;
                _details.Skill = f.Details.Skill;
                _details.Style = f.Details.Style;
                _details.Weight = f.Details.Weight;
                _details.Sex = f.Details.Sex;
            }
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            _details.Switch();           
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstallUpdateSyncWithInfo();
        }
        private void InstallUpdateSyncWithInfo()
        {
            UpdateCheckInfo info = null;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    info = ad.CheckForDetailedUpdate();

                }
                catch (DeploymentDownloadException dde)
                {
                    MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message);
                    return;
                }

                if (info.UpdateAvailable)
                {
                    Boolean doUpdate = true;

                    if (!info.IsUpdateRequired)
                    {
                        DialogResult dr = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel);
                        if (!(DialogResult.OK == dr))
                        {
                            doUpdate = false;
                        }
                    }
                    else
                    {
                        // Display a message that the app MUST reboot. Display the minimum required version.
                        MessageBox.Show("This application has detected a mandatory update from your current " +
                            "version to version " + info.MinimumRequiredVersion.ToString() +
                            ". The application will now install the update and restart.",
                            "Update Available", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    if (doUpdate)
                    {
                        try
                        {
                            ad.Update();
                            MessageBox.Show("The application has been upgraded, and will now restart.");
                            Application.Restart();
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            MessageBox.Show("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " + dde);
                            return;
                        }
                    }
                }
            }
        }
    }
}
