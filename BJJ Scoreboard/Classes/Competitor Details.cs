using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace BJJA.Scoreboard.Classes
{
    public class Competitor_Details : INotifyPropertyChanged
    {
        string colorName;
        string whiteName;
        string age;
        string weight;
        string skill;
        string style;
        string sex;
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        public void Switch()
        {
            string tmp = colorName;
            ColorName = whiteName;
            WhiteName = tmp;
        }
        public string Division
        {
            get
            {
                return sex + " " + age + " " + weight + "-weight " + skill + " " + style;
            }
        }
        public string ColorName
        {
            get { return colorName; }
            set { colorName = value; OnPropertyChanged("ColorName"); }
        }
        public string WhiteName
        {
            get { return whiteName; }
            set { whiteName = value; OnPropertyChanged("WhiteName"); }
        }
        public string Age
        {
            get { return age; }
            set { age = value; OnPropertyChanged("Division"); }
        }
        public string Weight
        {
            get { return weight; }
            set { weight = value; OnPropertyChanged("Division"); }
        }
        public string Skill
        {
            get { return skill; }
            set { skill = value; OnPropertyChanged("Division"); }
        }
        public string Style
        {
            get { return style; }
            set { style = value; OnPropertyChanged("Division"); }
        }
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
