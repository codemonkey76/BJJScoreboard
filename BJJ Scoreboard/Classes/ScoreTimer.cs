using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Timers;

namespace BJJA.Scoreboard.Classes
{
    public class ScoreTimer : INotifyPropertyChanged
    {
        #region Public Events
        public delegate void TimerTick();
        public delegate void MatchComplete();
        public delegate void LuteTimeout();
        public delegate void Flash(bool visible);

        public event TimerTick OnTimerTick;
        public event MatchComplete OnMatchComplete;
        public event LuteTimeout OnLuteTimeout;
        public event Flash OnFlash;
        #endregion
        #region Public properties
        public bool IsRunning
        {
            get { return _isRunning; }
        }
        public TimeSpan Duration
        {
            get { return _duration; }
            set {
                _duration = value;
                OnPropertyChanged("Remaining");
                OnPropertyChanged("RemainingStr");
                OnPropertyChanged("Time1");
                OnPropertyChanged("Time2");
                OnPropertyChanged("Time3");
                OnPropertyChanged("Time4");
            }
        }
        public string RemainingStr
        {
            get
            {
                TimeSpan r = Duration.Subtract(_Total_Elapsed);
                return r.ToString(@"m\:ss");
            }
        }
        public string Remaining
        {
            get
            {
                TimeSpan r = Duration.Subtract(_Total_Elapsed);
                return r.Minutes.ToString("00") + ":" + r.Seconds.ToString("00") + "." + (r.Milliseconds / 100).ToString("0");
            }
        }
        public string LuteTime
        {
            get
            {
                if (!_luteTimer.Enabled)
                    return "N/A";
                else
                {
                    TimeSpan ts = DateTime.Now.Subtract(_luteStartTime) + _tsLuteElapsed;
                    return ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00") + "." + (ts.Milliseconds / 100).ToString("0");
                }
            }
        }
        public int Lute1
        {
            get
            {
                if (!_luteTimer.Enabled)
                    return -1;
                else
                {
                    TimeSpan ts = DateTime.Now.Subtract(_luteStartTime) + _tsLuteElapsed;
                    return int.Parse(ts.Minutes.ToString("00")[0].ToString());
                }
            }
        }
        public int Lute2
        {
            get
            {
                if (!_luteTimer.Enabled)
                    return -1;
                else
                {
                    TimeSpan ts = DateTime.Now.Subtract(_luteStartTime) + _tsLuteElapsed;
                    return int.Parse(ts.Minutes.ToString("00")[1].ToString());
                }
            }
        }
        public int Lute3
        {
            get
            {
                if (!_luteTimer.Enabled)
                    return -1;
                else
                {
                    TimeSpan ts = DateTime.Now.Subtract(_luteStartTime) + _tsLuteElapsed;
                    return int.Parse(ts.Seconds.ToString("00")[0].ToString());
                }
            }
        }
        public int Lute4
        {
            get
            {
                if (!_luteTimer.Enabled)
                    return -1;
                else
                {
                    TimeSpan ts = DateTime.Now.Subtract(_luteStartTime) + _tsLuteElapsed;
                    return int.Parse(ts.Seconds.ToString("00")[1].ToString());
                }
            }
        }
        public int Time1
        {
            get
            {
                TimeSpan r = Duration.Subtract(_Total_Elapsed);
                return int.Parse(r.Minutes.ToString("00")[0].ToString());
            }
        }
        public int Time2
        {
            get
            {
                TimeSpan r = Duration.Subtract(_Total_Elapsed);
                return int.Parse(r.Minutes.ToString("00")[1].ToString());
            }
        }
        public int Time3
        {
            get
            {
                TimeSpan r = Duration.Subtract(_Total_Elapsed);
                return int.Parse(r.Seconds.ToString("00")[0].ToString());
            }
        }
        public int Time4
        {
            get
            {
                TimeSpan r = Duration.Subtract(_Total_Elapsed);
                return int.Parse(r.Seconds.ToString("00")[1].ToString());
            }
        }
        #endregion
        #region Public Methods
        public void Reset()
        {
            _tsElapsed = new TimeSpan();
            if (OnFlash != null) OnFlash(true);
            _flashTimer.Enabled = false;
            OnPropertyChanged("Remaining");
            OnPropertyChanged("RemainingStr");
            OnPropertyChanged("Time1");
            OnPropertyChanged("Time2");
            OnPropertyChanged("Time3");
            OnPropertyChanged("Time4");
        }
        public void Pause()
        {
            if (IsRunning)
            { //Pause
                _mainTimer.Enabled = false;
                _luteTimer.Enabled = false;
                _flashTimer.Enabled = false;
                _isRunning = false;
                _tsLuteElapsed = _tsLuteElapsed.Add(DateTime.Now.Subtract(_luteStartTime));
                _tsElapsed = _tsElapsed.Add(DateTime.Now.Subtract(_startTime));
            }
            else
            { //Start
                _mainTimer.Enabled = true;
                _flashTimer.Enabled = true;
                if (OnFlash != null) OnFlash(true);
                _isRunning = true;
                _startTime = DateTime.Now;
            }
        }
        public void Lute()
        {
            if (_luteTimer.Enabled)
                _luteTimer.Stop();
            _tsLuteElapsed = new TimeSpan();
            _luteStartTime = DateTime.Now;
            _luteTimer.Start();
        }
        #endregion
        #region Internal Fields
        Timer _mainTimer;
        Timer _luteTimer;
        Timer _flashTimer;

        TimeSpan _tsElapsed;
        TimeSpan _tsLuteElapsed;
        TimeSpan _duration;
        
        DateTime _startTime;
        DateTime _luteStartTime;
        
        bool _isRunning;
        bool _flashVisible;
        double _interval;
        #endregion
        #region Internal Methods
        TimeSpan _Total_Elapsed
        {
            get
            {
                if (IsRunning)
                    return _tsElapsed.Add(DateTime.Now.Subtract(_startTime));
                else
                    return _tsElapsed;
            }
        }
        #endregion
        #region Constructor
        public ScoreTimer(System.Windows.Forms.Form UIThread, TimeSpan Duration, double Interval)
        {
            this._interval = Interval;
            this._isRunning = false;
            this.Duration = Duration;
            
            _mainTimer = new Timer(Interval);
            _mainTimer.SynchronizingObject = UIThread;
            _mainTimer.AutoReset = true;
            _mainTimer.Elapsed += new ElapsedEventHandler(_t_Elapsed);

            _flashTimer = new Timer(500); //1/2 Second flasher
            _flashTimer.AutoReset = true;
            _flashTimer.SynchronizingObject = UIThread;
            _flashTimer.Elapsed += new ElapsedEventHandler(_flash_Elapsed);

            _luteTimer = new Timer(10000); //20 seconds lute
            _luteTimer.AutoReset = false;
            _luteTimer.Elapsed += new ElapsedEventHandler(_lute_Elapsed);
            _luteTimer.SynchronizingObject = UIThread;

            _tsLuteElapsed = new TimeSpan();
            _tsElapsed = new TimeSpan();

        }
        #endregion
        #region Timer Event Procedures
        void _flash_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (OnFlash != null)
            {
                OnFlash(_flashVisible);
                _flashVisible = !_flashVisible;
            }
        }
        void  _lute_Elapsed(object sender, ElapsedEventArgs e)
        {
 	        if (OnLuteTimeout!=null)
                OnLuteTimeout();
        }
        void _t_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_Total_Elapsed>=Duration)
            {
                Pause();
                _tsElapsed = _duration;
                if (OnMatchComplete!=null)
                    OnMatchComplete();
            }
            if (OnTimerTick!=null)
                OnTimerTick();
            OnPropertyChanged("Remaining");
            OnPropertyChanged("RemainingStr");
            OnPropertyChanged("Time1");
            OnPropertyChanged("Time2");
            OnPropertyChanged("Time3");
            OnPropertyChanged("Time4");
        }
        
        #endregion
        #region INotifyPrompertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
}
