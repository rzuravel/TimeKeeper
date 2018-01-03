using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeeper
{
    public class TimeSpanRecord : ViewModelBase
    {
        DateTime _Start;
        DateTime _End;

        public TimeSpanRecord()
        {

        }

        DateTime ConvertStringToDateTime(string Time)
        {
            DateTime RetVal = DateTime.MinValue;
            try
            {
                RetVal = DateTime.Parse(Time);
            }
            catch
            {
                RetVal = DateTime.MinValue;
            }

            return RetVal;
        }

        public double GetTimeDouble()
        {
            TimeSpan TS = _End - _Start;
            return TS.Hours + (TS.Minutes / 60.0);
        }

        public string StartString
        {
            get { return _Start.ToString("h:mm tt"); }
            set
            {
                _Start = ConvertStringToDateTime(value);
                OnPropertyChanged("StartString");
            }
        }

        public string EndString
        {
            get { return _End.ToString("h:mm tt"); }
            set
            {
                _End = ConvertStringToDateTime(value);
                OnPropertyChanged("EndString");
            }
        }
    }
}
