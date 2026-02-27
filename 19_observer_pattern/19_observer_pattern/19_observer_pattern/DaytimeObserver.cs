using System;

namespace _19_observer_pattern
{
    internal class DaytimeObserver: Observer
    {
        public override void Update(Subject subject)
        {
            if(subject is TimeSubject timeSubject)
            {
                DateTime time = timeSubject.Time;
                if (time.Hour > 6 && time.Hour < 18)
                    Console.WriteLine("Daytime Observer: Tag");
                else 
                    Console.WriteLine("Daytime Observer: Nacht");
            }
        }
    }
}