using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_SamplesDelegates
{
    internal class Program
    {
        public delegate void TemperatureAlert(double temp);
        public static void HighTempAlert(double t)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{t} °C - Achtung! Temperatur im Serverraum über 30 °C!");
        }

        public static void NormalTempAlert(double t)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{t} °C - Temperatur im Normalbereich.");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Temperaturüberwachung im Serverraum - 30 Zufallswerte.");
            Console.WriteLine("------------------------------------------------");
            Random random = new Random();
            TemperatureAlert alert;
            for (int i = 0; i < 30; i++)
            {
                double temp = Math.Round(20 + random.NextDouble() * 20, 1);
                if (temp >= 30.0)
                    alert = HighTempAlert;
                else
                    alert = NormalTempAlert;

                alert(temp);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Überwachung abgeschlossen.");
            Console.ReadKey();
        }
    }
}
