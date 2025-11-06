using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace wordCount
{
    internal class Program
    {
        public static string[] urls = new string[]
        {
            "https://www.gutenberg.org/files/1342/1342-0.txt", // Pride and Prejudice
            "https://www.gutenberg.org/files/11/11-0.txt", // Alice's Adventures in Wonderland
            "https://www.gutenberg.org/files/84/84-0.txt", // Frankenstein
            "https://www.gutenberg.org/files/2600/2600-h/2600-h.htm", // War and Peace by Leo Tolstoy
            "https://www.gutenberg.org/files/1342/1342-h/1342-h.htm", // Pride and Prejudice by Jane Austen
            "https://www.gutenberg.org/files/28054/28054-h/28054-h.htm", // The Brothers Karamazov by Fyodor Dostoyevsky
            "https://www.gutenberg.org/files/1399/1399-h/1399-h.htm", // Anna Karenina by Leo Tolstoy
            "https://www.gutenberg.org/files/2554/2554-h/2554-h.htm", // Crime and Punishment by Fyodor Dostoyevsky
            "https://www.gutenberg.org/files/1184/1184-h/1184-h.htm", // The Count of Monte Cristo by Alexandre Dumas
            "https://www.gutenberg.org/files/996/996-h/996-h.htm", // Don Quixote by Miguel de Cervantes
            "https://www.gutenberg.org/files/135/135-h/135-h.htm", // Les Misérables by Victor Hugo
            "https://www.gutenberg.org/files/145/145-h/145-h.htm" // Middlemarch by George Eliot
        };

        public static int counterMulti = 0;
        public static object lockCounter = new object();
        static void Main(string[] args)
        {
            Console.WriteLine("Single startet:");
            Thread single = new Thread(singleThreaded);
            single.Start();
            single.Join();

            Console.WriteLine("Multi startet:");
            Thread[] threads = new Thread[urls.Length];
            Stopwatch w = new Stopwatch();
            w.Start();
            for (int i = 0; i < urls.Length; i++)
            {
                int index = i; 
                threads[i] = new Thread(() => multiThreaded(urls[index]));
                threads[i].Start();
            }
            foreach (var t in threads)
                t.Join();

            w.Stop();
            Console.WriteLine($"Gesamtanzahl 'the' (Multi): {counterMulti}, Dauer: {w.Elapsed}");
            Console.ReadKey();
        }      

        static void singleThreaded()
        {
            int counter = 0;
            Stopwatch w = Stopwatch.StartNew();
            try
            {
                HttpClient client = new HttpClient();
                foreach (string url in urls)
                {
                    string pageContent = client.GetStringAsync(url).Result;
                    string[] words = pageContent.Split(' ', '\n', '\r', '\t', '.', ',', ';', ':', '-', '_', '!', '?', '"');
                    foreach (string word in words)
                    {
                        if (word.ToLower() == "the")
                            counter++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Laden: {ex.Message}");
            }
            w.Stop();
            Console.WriteLine("Zeit: " + w.Elapsed + ", Anzahl von the: " + counter);
        }

        static void multiThreaded(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                string pageContent = client.GetStringAsync(url).Result;

                string[] words = pageContent.Split(' ', '\n', '\r', '\t', '.', ',', ';', ':', '-', '_', '!', '?', '"');
                foreach (string word in words)
                {
                    if (word.ToLower() == "the")
                    {
                        lock (lockCounter)
                        {
                            counterMulti++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Laden von {url}: {ex.Message}");
            }
        }

    }
}
