using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Diagnostics;

namespace BJJA.Scoreboard.Classes
{
    public class MatchScore : INotifyPropertyChanged
    {
        #region Fields
        CompetitorScore _White;
        CompetitorScore _Blue;
        #endregion
        #region Public Properties
        public CompetitorScore White
        {
            get { return _White; }
            set { _White = value; OnPropertyChanged("White"); }
        }
        public CompetitorScore Blue
        {
            get { return _Blue; }
            set { _Blue = value; OnPropertyChanged("Blue"); }
        }
        #endregion
        #region Constructors
        public MatchScore() : this(0, 0, 0, 0, 0, 0, 0, 0) { }
        public MatchScore(int ws, int wa, int wp, int wm, int bs, int ba, int bp, int bm)
        {
            _White = new CompetitorScore(ws, wa, wp, wm);
            _Blue = new CompetitorScore(bs, ba, bp, bm);            

            White.PropertyChanged += new PropertyChangedEventHandler(_White_PropertyChanged);
            Blue.PropertyChanged += new PropertyChangedEventHandler(_Blue_PropertyChanged);           
        }
        #endregion
        #region Public Methods
        public bool Add(MatchScore ms)
        {
            return (White.Add(ms.White) && Blue.Add(ms.Blue));
        }
        public bool Subtract(MatchScore ms)
        {
            return (White.Subtract(ms.White)&&Blue.Subtract(ms.Blue));
        }
        public void Reset()
        {
            White.Reset();
            Blue.Reset();
        }
        #endregion
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string Property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
        }
        void _Blue_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("Blue");
        }
        void _White_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("White");
        }
        #endregion
    }
}
