using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _14_SynchronizationContext
{
    internal class Program
    {
        static async Task<int> Add(int x, int y)
        {
            Console.WriteLine("Current thread before: " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(3000);
            Console.WriteLine("Current thread after: " + Thread.CurrentThread.ManagedThreadId);
            return x + y;
        }
        static void Main(string[] args)
        {
            Console.ReadKey();
            Console.WriteLine("Initial thread: " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Starting...");
            int result = Add(3, 4).Result;
            Console.WriteLine($"Result: {result}");
            Console.WriteLine("Current thread at End: " + Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }
    }
}
