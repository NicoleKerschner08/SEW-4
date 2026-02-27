using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp_Event
{
    class Display
    {
        static Random random = new Random();
        private int x;
        private int y;
        public string Text { get; set; }
        public Display(string txt, int x, int y)
        {
            Text = txt;
            this.x = x;
            this.y = y;
        }

        public void ChangeColor()
        {
            Console.SetCursorPosition(x, y);

            if (random.NextDouble() < 0.25) Console.ForegroundColor = ConsoleColor.Red;
            else if (random.NextDouble() < 0.5) Console.ForegroundColor = ConsoleColor.Green;
            else if (random.NextDouble() < 0.75) Console.ForegroundColor = ConsoleColor.Blue;
            else Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write(Text);
        }
    }

    internal class Program
    {

        // TODO: Insert Delegate and Event
        delegate void displayText();
        static event displayText displayTextEvent;

        static void Main(string[] args)
        {
            List<Display> displays = new List<Display>();
            displays.Add(new Display("Hallo", 4, 10));
            displays.Add(new Display("Hallo", 10, 4));
            displays.Add(new Display("Hallo", 14, 20));
            displays.Add(new Display("Hallo", 6, 18));

            // TODO: Event -> Attach
            foreach(Display dp in displays)
            {
                displayTextEvent += dp.ChangeColor;
            }

            for (int i = 0; i < 100; i++)
            {
                // TODO: Event -> Notify
                displayTextEvent.Invoke();
                Thread.Sleep(1000);
            }
        }
    }
}
