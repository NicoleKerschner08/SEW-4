using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeadlockGenerator
{
    internal class Program
    {
        public static Object objektDrucker = new Object();
        public static Object objektDateisystem = new Object();

        static void Main(string[] args)
        {
            Thread threadA = new Thread(ActionA);
            Thread threadB = new Thread(ActionB);
            threadA.Start();
            threadB.Start();

            threadA.Join();
            threadB.Join();
            Console.ReadKey();
        }

        static void ActionA()
        {
            Stopwatch w = new Stopwatch();
            Random random = new Random();
            w.Start();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("A: Waiting...");
                Thread.Sleep(random.Next(500, 1000));
                lock (objektDrucker)
                {
                    Console.WriteLine("A got lock on printer");
                    Thread.Sleep(random.Next(500, 1000));
                    lock (objektDateisystem)
                    {
                        Console.WriteLine("A got lock on system");
                        Thread.Sleep(random.Next(500, 1000));
                        Console.WriteLine("A Holding lock on both");
                    }
                    Console.WriteLine("A released system");
                }
                Console.WriteLine("A released printer");
            }
            w.Stop();
            Console.WriteLine("Zeit für AktionA = " + w.Elapsed);
        }

        static void ActionB()
        {
            Stopwatch w = new Stopwatch();
            Random random = new Random();
            w.Start();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("B: Waiting...");
                Thread.Sleep(random.Next(500, 1000));
                lock (objektDrucker)
                {
                    Console.WriteLine("B got lock on system");
                    Thread.Sleep(random.Next(500, 1000));
                    lock (objektDateisystem)
                    {
                        Console.WriteLine("B got lock on printer");
                        Thread.Sleep(random.Next(500, 1000));
                        Console.WriteLine("B Holding lock on both");
                    }
                    Console.WriteLine("B released printer");
                }
                Console.WriteLine("B released system");
            }
            w.Stop();
            Console.WriteLine("Zeit für AktionB = " + w.Elapsed);
        }
    }
}
