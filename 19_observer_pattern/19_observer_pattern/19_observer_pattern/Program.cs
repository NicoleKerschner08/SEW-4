using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_observer_pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimeSubject timeSubject = new TimeSubject();
            DaytimeObserver timeObserver = new DaytimeObserver();
            timeSubject.Attach(timeObserver);
            IntervalObserver intervalObserver = new IntervalObserver();
            timeSubject.Attach(intervalObserver);
            timeSubject.Run();

        }
    }
}
