using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteDownloader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> urls = new List<string>(); 
            urls.Add("https://www.htlwy.at");
            urls.Add("https://www.orf.com");
            urls.Add("https://www.bbc.com");


            /*HttpClient client = new HttpClient();
            client.GetAsync(urls[0]);*/

            Task<string> longestWebsite = calculateLongest(urls);
            Console.WriteLine(longestWebsite.Result);
            Console.ReadKey();
        }

        public static async Task<string> calculateLongest(List<string> urls)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            HttpClient client = new HttpClient();
            Task<string> task1 = client.GetStringAsync(urls[0]);
            Task<string> task2 = client.GetStringAsync(urls[1]);
            Task<string> task3 = client.GetStringAsync(urls[2]);
            string website1 = await task1;
            string website2 = await task2;
            string website3 = await task3;

            if(website1.Length >= website2.Length && website1.Length >= website3.Length)
            {
                return urls[0];
            }
            else if(website2.Length >= website1.Length && website2.Length >= website3.Length)
            {
                return urls[1];
            }
            else
            {
                return urls[2];
            }
            watch.Stop();
            Console.WriteLine("Dauer: " + watch.ElapsedMilliseconds);
        }
    }
}
