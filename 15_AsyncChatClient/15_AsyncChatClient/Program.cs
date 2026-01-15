using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _15_AsyncChatClient
{
    internal class Program
    {
        //AsyncChatClient "Hallo Welt!"
        static async Task Main(string[] args)
        {
            
            //Socket = IP-Adresse & Port-Nummer
            TcpClient tcpClient = new TcpClient();
            try
            {
                string message = "";
                await tcpClient.ConnectAsync("127.0.0.1", 5000);
                do
                {
                    NetworkStream networkStream = tcpClient.GetStream();

                    message = Console.ReadLine();
                    byte[] buffer = Encoding.UTF8.GetBytes(message);
                    await networkStream.WriteAsync(buffer, 0, buffer.Length);
                } while (message != "quit");
            }catch(SocketException ex)
            {
                Console.WriteLine($"Socket Exception: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}
