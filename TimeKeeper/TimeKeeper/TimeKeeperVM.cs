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
        ObservableCollection<TimeSpanRecordVM> _TimeSpans;
        double _TotalTime = 0.0;

        public TimeKeeperVM()
        {
            _TimeSpans = new ObservableCollection<TimeSpanRecordVM>();
        }

        public ObservableCollection<TimeSpanRecordVM> TimeSpans
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
            _TimeSpans.Add(new TimeSpanRecordVM(UpdateTotalTime));
            UpdateTotalTime();
        }

        internal void OnRemoveTime(TimeSpanRecordVM VMToDelete)
        {
            _TimeSpans.Remove(VMToDelete);
        }

        void UpdateTotalTime()
        {
            _TotalTime = 0;
            foreach (TimeSpanRecordVM TimePiece in _TimeSpans)
            {
                TotalTime += TimePiece.DoubleTime;
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
