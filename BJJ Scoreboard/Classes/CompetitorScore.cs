using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Diagnostics;

namespace BJJA.Scoreboard.Classes
{
        public class CompetitorScore : INotifyPropertyChanged
        {
            #region Fields
            public int _Score;
            public int _Adv;
            public int _Pen;
            public int _Medical;
            #endregion
            #region Properties
            public int Score
            {
                get
                {
                    return _Score;
                }
                set
                {
                    if (value > 99)
                    {
                        _Score = 99;
                        throw new ArgumentException();
                    }
                    else if (value < 0)
                    {
                        _Score = 0;
                        throw new ArgumentException();
                    }
                    else
                        _Score = value;
                    OnPropertyChanged("Score");
                    OnPropertyChanged("ScoreS1");
                    OnPropertyChanged("ScoreS2");
                    
                }
            }
            public int ScoreS1
            {
                get
                {
                    return int.Parse(_Score.ToString("00")[0].ToString());
                }
            }
            public int ScoreS2
            {
                get
                {
                    return int.Parse(_Score.ToString("00")[1].ToString());
                }
            }
            public int ScoreA1
            {
                get
                {
                    return int.Parse(_Adv.ToString("00")[0].ToString());
                }
            }
            public int ScoreA2
            {
                get
                {
                    return int.Parse(_Adv.ToString("00")[1].ToString());
                }
            }
            public int ScoreP1
            {
                get
                {
                    return int.Parse(_Pen.ToString("00")[0].ToString());
                }
            }
            public int ScoreP2
            {
                get
                {
                    return int.Parse(_Pen.ToString("00")[1].ToString());
                }
            }
            public int Med1
            {
                get
                {
                    return int.Parse(_Medical.ToString("00")[0].ToString());
                }
            }
            public int Med2
            {
                get
                {
                    return int.Parse(_Medical.ToString("00")[1].ToString());
                }
            }
            public int Adv
            {
                get
                {
                    return _Adv;
                }
                set
                {
                    if (value > 99)
                    {
                        _Adv = 99;
                        throw new ArgumentException();
                    }
                    else if (value < 0)
                    {
                        _Adv = 0;
                        throw new ArgumentException();
                    }
                    else
                        _Adv = value;
                    OnPropertyChanged("ScoreA1");
                    OnPropertyChanged("ScoreA2");
                    OnPropertyChanged("Adv");
                }
            }
            public int Pen
            {
                get
                {
                    return _Pen;
                }
                set
                {
                    if (value > 3)
                    {
                        _Pen = 3;
                        throw new ArgumentException();
                    }
                    else if (value < 0)
                    {
                        _Pen = 0;
                        throw new ArgumentException();
                    }
                    else
                        _Pen = value;
                    OnPropertyChanged("Pen");
                    OnPropertyChanged("ScoreP1");
                    OnPropertyChanged("ScoreP2");
                }
            }
            public int Medical
            {
                get
                {
                    return _Medical;
                }
                set
                {

                    if (value > 2)
                    {
                        _Medical = 0;
                        OnPropertyChanged("MedicalStr");
                        OnPropertyChanged("Med1");
                        OnPropertyChanged("Med2");
                        throw new ArgumentException();
                    }
                    else if (value < 0)
                    {
                        _Medical = 0;
                        OnPropertyChanged("MedicalStr");
                        OnPropertyChanged("Med1");
                        OnPropertyChanged("Med2");
                        throw new ArgumentException();
                    }
                    else
                        _Medical = value;
                    OnPropertyChanged("MedicalStr");
                    OnPropertyChanged("Med1");
                    OnPropertyChanged("Med2");
                    
                }
            }
            public string MedicalStr
            {
                get
                {
                    switch (Medical)
                    {
                        case 1:
                            return "+";
                        case 2:
                            return "++";
                        default:
                            return "";
                    }

                }
            }
            #endregion
            #region Constructor
            public CompetitorScore(int Score, int Adv, int Pen, int Medical)
            {
                _Score = Score;
                _Adv = Adv;
                _Pen = Pen;
                _Medical = Medical;
            }
            #endregion
            #region Public Methods
            public bool Add(CompetitorScore c)
            {
                try
                {
                    this.Score += c.Score;
                    this.Adv += c.Adv;
                    this.Pen += c.Pen;
                    this.Medical += c.Medical;
                    return true;
                }
                catch (ArgumentException)
                {
                    return false;
                }
            }
            public bool Subtract(CompetitorScore c)
            {
                try
                {
                    this.Score -= c.Score;
                    this.Adv -= c.Adv;
                    this.Pen -= c.Pen;
                    this.Medical -= c.Medical;
                    return true;
                }
                catch (ArgumentException)
                {
                    return false;
                }

            }
            public void Reset()
            {
                this.Score = 0;
                this.Adv = 0;
                this.Pen = 0;
                this.Medical = 0;
            }
            #endregion
            #region INotifyPropertyChanged Members
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string Property)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(Property));
            }
            #endregion
        }
}
