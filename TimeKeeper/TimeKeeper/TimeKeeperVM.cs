using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeKeeper
{
   public class TimeKeeperVM : ViewModelBase
   {
        ObservableCollection<TimeSpanRecord> _TimeSpans;
        double _TotalTime = 0.0;

        public TimeKeeperVM()
        {
            _TimeSpans = new ObservableCollection<TimeSpanRecord>();
        }

        public ObservableCollection<TimeSpanRecord> TimeSpans
        {
            get { return _TimeSpans; }
            set
            {
                _TimeSpans = value;
                OnPropertyChanged("TimeSpans");
            } 
        }

        internal void OnAddTime()
        {
            _TimeSpans.Add(new TimeSpanRecord());
        }

        void UpdateTotalTime()
        {
            _TotalTime = 0;
            foreach (TimeSpanRecord TimePiece in _TimeSpans)
            {
                TotalTime += TimePiece.GetTimeDouble();
            }
        }

        public double TotalTime
        {
            get { return _TotalTime; }
            set
            {
                _TotalTime = value;
                OnPropertyChanged("TotalTime");
            }
        }
    }      
}
