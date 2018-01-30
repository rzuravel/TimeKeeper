using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeeper
{
    public class TimeSpanRecordVM : ViewModelBase
    {
        DateTime _Start;
        DateTime _End;

        double _DoubleTime;

        Action _UpdateMasterTime;

        public TimeSpanRecordVM(Action UpdateMasterTime)
        {
            _UpdateMasterTime = UpdateMasterTime;
            _Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
            _End = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0);
            UpdateDoubleTime();
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

        public void UpdateDoubleTime()
        {
            TimeSpan TS = _End - _Start;
            DoubleTime = TS.Hours + (TS.Minutes / 60.0);
            _UpdateMasterTime();
        }

        public string StartString
        {
            get { return _Start.ToString("h:mm tt"); }
            set
            {
                _Start = ConvertStringToDateTime(value);
                UpdateDoubleTime();
                OnPropertyChanged("StartString");
            }
        }

        public string EndString
        {
            get { return _End.ToString("h:mm tt"); }
            set
            {
                _End = ConvertStringToDateTime(value);
                UpdateDoubleTime();
                OnPropertyChanged("EndString");
            }
        }

        public double DoubleTime
        {
            get { return _DoubleTime; }
            set
            {
                _DoubleTime = value;
                OnPropertyChanged("DoubleTime");
            }
        }
    }
}
