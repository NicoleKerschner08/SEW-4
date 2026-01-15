using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _14_AsyncAwait
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //CountTwiceSync();
            CountTwiceAsync().Wait();
            Console.ReadKey();
        }

        public static int Count(int start)
        {
            int number = start;
            for(; number < start + 10; number++)
            {
                Console.WriteLine("Counting: " +number);
                Thread.Sleep(500); 
            }
            return number;
        }

        public static void CountTwiceSync()
        {
            int countedNr1 = Count(1);
            int countedNr2 = Count(37);
            Console.WriteLine("Ergebnis 1: " + countedNr1);
            Console.WriteLine("Ergebnis 2: " + countedNr2);
        }

        public static async Task CountTwiceAsync()
        {
            int countedNr1 = await CountAsync(1);
            int countedNr2 = await CountAsync(37);
            Console.WriteLine("Ergebnis 1: " + countedNr1);
            Console.WriteLine("Ergebnis 2: " + countedNr2);
        }


        public static async Task<int> CountAsync(int start)
        {
            int number = start;
            for (; number < start + 10; number++)
            {
                Console.WriteLine("Counting: " + number);
                Task t = Task.Delay(500);
                await t;
            }
            return number;
        }
    }
}
