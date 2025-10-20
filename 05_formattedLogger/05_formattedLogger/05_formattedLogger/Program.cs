using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _05_formattedLogger
{

    public class Logging
    {
        public List<string> messages = new List<string>();
        public void AddLogMessage(string msg)
        {
            messages.Add(msg);
        }

        public void PrintMessages(Func<string, string> formattingFunc = null)
        {
            foreach (string m in messages)
            {
                if(formattingFunc != null)
                    Console.WriteLine(formattingFunc(m));
                else
                    Console.WriteLine(m);
            }
        }

        public static string FormatAddDateTime(string msg)
        {
            string result = DateTime.Now.ToString() + " " + msg;
            return result;
        }

        public Func<string, string> funcAddDateTime = FormatAddDateTime;

        public static string FormatUpperCase(string msg)
        {
            string result = msg.ToUpper();
            return result;  
        }

        public Func<string, string> funcFormatUpperCase = FormatUpperCase;

        public static string formatLengthLimit(string msg)
        {
            string result = "";
            if (msg.Length > 30)
            {
                result = msg.Substring(0, 30);
            }
            return result;
        }

        public Func<string, string> funcFormatLengthLimit = formatLengthLimit;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string m1 = "Hallo! Sie haben eine neue Nachricht!";
            string m2 = "Das ist eine sehr lange Nachricht, die länger als 30 Zeichen ist, also sollte sie gekürzt werden!";
            Logging l1 = new Logging();
            l1.AddLogMessage(m1);
            l1.AddLogMessage(m2);
            char choice;
            do
            {
                bool rightInput = false;
                do
                {
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Wollen Sie die Nachricht mit Datum (d) oder mit Großbuchstaben (g) oder mit Längenkürzung (l) oder normal (n) anzeigen oder das Programm beenden (e)");
                    rightInput = char.TryParse(Console.ReadLine(), out choice);
                } while (!rightInput);
                switch (choice)
                {
                    case 'd':
                        l1.PrintMessages(l1.funcAddDateTime);
                        break;
                    case 'g':
                        l1.PrintMessages(l1.funcFormatUpperCase);
                        break;
                    case 'l':
                        l1.PrintMessages(l1.funcFormatLengthLimit);
                        break;
                    case 'n':
                        l1.PrintMessages();
                        break;
                }
            } while (choice != 'e');
            Console.ReadKey();
        }
    }
}
