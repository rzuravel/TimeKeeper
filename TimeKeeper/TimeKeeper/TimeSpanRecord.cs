using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeeper
{
   public enum TimeDesignator
   { 
      AM,
      PM
   }

   public class TimeSpanRecord
   {
      int AMPMOffset = 12;

      DateTime _Start;
      DateTime _End;

      TimeSpan _Span;

      public TimeSpanRecord()
      { 
      
      }

      DateTime ConvertStringToDateTime(string Time, TimeDesignator Designator)
      {
         DateTime RetVal = DateTime.MinValue;
         string[] Split = Time.Split(':');
         if (Split.Length >= 2)
         {
            int Hours = int.Parse(Split[0]);
            int Minutes = int.Parse(Split[1]);

            if (Designator == TimeDesignator.AM)
            {
               RetVal = new DateTime(0, 0, 0, Hours, Minutes, 0);
            }
            else
            {
               RetVal = new DateTime(0, 0, 0, Hours + AMPMOffset, Minutes, 0);
            }
         }

         return RetVal;
      }

      public string StartString
      {
         get { return _Start.ToString("h:mm"); }
         set
         {
            _Start = ConvertStringToDateTime(
         }
      }

      public TimeDesignator StartDesignator
      {
         get { return _Start.}   
      }

      public string EndString
      {
         get { return _End.ToString("h:mm"); }
      }

   }
}
