using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BJJA.Scoreboard.UIControls.Classes
{
    public class LCDParts : List<LCDPart>
    {
        int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                if (value >= -1)
                {
                    if (value > 9)
                        _value = 9;
                    else
                        _value = value;
                    SetValue();
                }
                else
                    throw new ArgumentException("Invalid value", "value");
            }
        }
        void setall(bool on)
        {
            foreach (LCDPart p in this)
                p.On = on;
        }
        void set(int num, bool on)
        {
            if (num < this.Count)
                this[num].On = on;
        }
        void SetValue()
        {
            switch (_value)
            {
                case -1:
                    setall(false);
                    break;
                case 0:
                    setall(true);
                    set(3, false);
                    break;
                case 1:
                    setall(false);
                    set(2,true);
                    set(5,true);
                    break;
                case 2:
                    setall(true);
                    set(1, false);
                    set(5, false);
                    break;
                case 3:
                    setall(true);
                    set(1, false);
                    set(4, false);
                    break;
                case 4:
                    setall(true);
                    set(0, false);
                    set(4, false);
                    set(6, false);
                    break;
                case 5:
                    setall(true);
                    set(2, false);
                    set(4, false);
                    break;
                case 6:
                    setall(true);
                    set(2, false);
                    break;
                case 7:
                    setall(true);
                    set(3, false);
                    set(4, false);
                    set(6, false);
                    break;
                case 8:
                    setall(true);
                    break;
                case 9:
                    setall(true);
                    set(4, false);
                    break;
            }
        }
    }
    public class LCDColon : List<LCDPart>
    {
        int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                if (value >= -1)
                {
                    if (value > 1)
                        _value = 1;
                    else
                        _value = value;
                    SetValue();
                }
                else
                    throw new ArgumentException("Invalid value", "value");
            }
        }
        void setall(bool on)
        {
            foreach (LCDPart p in this)
                p.On = on;
        }
        void set(int num, bool on)
        {
            if (num < this.Count)
                this[num].On = on;
        }
        void SetValue()
        {
            switch (_value)
            {
                case -1:
                    setall(false);
                    break;
                case 0:
                    setall(true);
                    set(1, false);
                    break;
                case 1:
                    setall(false);
                    set(1, true);
                    break;
            }
        }
    }
}
