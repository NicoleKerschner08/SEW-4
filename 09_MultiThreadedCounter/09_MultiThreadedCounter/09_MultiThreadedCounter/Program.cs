using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _09_MultiThreadedCounter
{
            
    internal class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter();
            Thread thread = new Thread(counter.Count);
            Thread thread1 = new Thread(counter.Count);
            thread.Start();
            thread1.Start();

            thread.Join();
            thread1.Join();
            Console.WriteLine(Counter.number);
            Console.ReadKey();
        }
    }
    public class Counter
    {
        public static int number = 0;
        private static readonly object _lock = new object();

        public void Count()
        {
            for (int i = 0; i < 1000000; i++)
            {
                lock (_lock)
                {
                    number++;
                }
            }
        }
    }
}
