using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GanttToWord
{
    class Calendar
    {
        List<DateTime> freeDays;
        List<int> freeDaysOfWeek; /* For example 1=Sun and 7=Sat use to be free*/
        public Calendar()
        {
            freeDays = new List<DateTime>();
            freeDaysOfWeek = new List<int>();
        }
        public void addFreeDay(string year, string month, string date)
        {
            int y = Int32.Parse(year);
            int m = Int32.Parse(month);
            int d=  Int32.Parse(date);
            DateTime aDate = new DateTime(y, m, d);
            freeDays.Add(aDate);
        }
        public void addFreeDayOfWeek(int day)
        {
            freeDaysOfWeek.Add(day);
        }
        public bool isFree(DateTime date)
        {
            foreach (DateTime d in freeDays)
            {
                if ((d.Day==date.Day) && (d.Month==date.Month) && (d.Year==date.Year))
                    return true;
            }
            return false;
        }
    }
}
