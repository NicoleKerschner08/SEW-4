using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{

    public class Player
    {
        public TcpClient Client { get; set; }
        public string Choice { get; set; } // "stein", "papier" oder "schere"
        public string Name { get; set; }
    }

    internal class AsyncChatServer
    {
        Player p1 = new Player { Name = "Player 1" };
        Player p2 = new Player { Name = "Player 2" };
        bool done = false;
        public async Task ProcessRequest(Player player)
        {
            NetworkStream stream = player.Client.GetStream();
            byte[] buffer = new byte[1024];

            while (true)
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead == 0) break;

                string msg = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                player.Choice = msg;
                Console.WriteLine($"{player.Name} wählt {msg}");

                // Prüfen, ob beide gewählt haben
                if (p1.Choice != null && p2.Choice != null)
                {
                    string result = Evaluate(p1, p2);
                    Console.WriteLine(result);

                    // Ergebnis an beide senden
                    byte[] data = Encoding.UTF8.GetBytes(result);
                    await p1.Client.GetStream().WriteAsync(data, 0, data.Length);
                    await p2.Client.GetStream().WriteAsync(data, 0, data.Length);

                    // Reset für nächste Runde
                    p1.Choice = null;
                    p2.Choice = null;
                }
            }
        }

        public string Evaluate(Player p1, Player p2)
        {
            if (p1.Choice == p2.Choice)
                return "Unentschieden!";
            if ((p1.Choice == "stein" && p2.Choice == "schere") ||
                (p1.Choice == "papier" && p2.Choice == "stein") ||
                (p1.Choice == "schere" && p2.Choice == "papier"))
            {
                done = true;
                return $"{p1.Name} gewinnt!";
                
            }
            else
            {
                done = true;
                return $"{p2.Name} gewinnt!";
            }
        }


        public async Task Run()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 5000);
            server.Start();
            Console.WriteLine("Server gestartet...");

            while (!done)
            {
                TcpClient client = await server.AcceptTcpClientAsync();

                if (p1.Client == null)
                {
                    p1.Client = client;
                    Console.WriteLine("Player 1 connected.");
                    _ = Task.Run(() => ProcessRequest(p1));
                }
                else if (p2.Client == null)
                {
                    p2.Client = client;
                    Console.WriteLine("Player 2 connected.");
                    _ = Task.Run(() => ProcessRequest(p2));
                }
            }
        }


    }
}