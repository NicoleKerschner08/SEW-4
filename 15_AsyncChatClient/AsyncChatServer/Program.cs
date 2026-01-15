using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsyncChatServer;

namespace AsyncChatServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AsyncChatServer server = new AsyncChatServer();
            server.Run().Wait();
        }
    }
}
