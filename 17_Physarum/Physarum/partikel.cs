using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physarum
{
    internal class partikel
    {
        public int direction { get; set; } //Richtung in Grad
        public int x { get; set; }
        public int y { get; set; }

        public void changeDirection(double[,] pheromonWerte)
        {
            double radiansFront = direction * Math.PI / 180.0;          //Umrechnung Grad zu Radiant
            double radiansLeft = (direction - 45) * Math.PI / 180.0;
            double radiansRight = (direction + 45) * Math.PI / 180.0;

            int frontX = validatePosition(x + (int)Math.Round(Math.Cos(radiansFront)), 0, pheromonWerte.GetLength(0) - 1); //Math.Cos() -> berechnet die x-Ausrichtung
            int frontY = validatePosition(y + (int)Math.Round(Math.Sin(radiansFront)), 0, pheromonWerte.GetLength(1) - 1); //Math.Sin() -> berechnet die y-Ausrichtung

            int leftX = validatePosition(x + (int)Math.Round(Math.Cos((direction - 45) * Math.PI / 180.0)), 0, pheromonWerte.GetLength(0) - 1);
            int leftY = validatePosition(y + (int)Math.Round(Math.Sin((direction - 45) * Math.PI / 180.0)), 0, pheromonWerte.GetLength(1) - 1);

            int rightX = validatePosition(x + (int)Math.Round(Math.Cos((direction + 45) * Math.PI / 180.0)), 0, pheromonWerte.GetLength(0) - 1);
            int rightY = validatePosition(y + (int)Math.Round(Math.Sin((direction + 45) * Math.PI / 180.0)), 0, pheromonWerte.GetLength(1) - 1);

            if (frontX == x || frontY == y)
                pheromonWerte[frontX, frontY] = double.MinValue; //setzt Wert auf minimum, damit der Partikel nicht auf der Stelle bleibt

            if (leftX == x || leftY == y)
                pheromonWerte[leftX, leftY] = double.MinValue;

            if (rightX == x || rightY == y)
                pheromonWerte[rightX, rightY] = double.MinValue;


            if (pheromonWerte[frontX, frontY] > pheromonWerte[leftX, leftY] && pheromonWerte[frontX, frontY] > pheromonWerte[rightX, rightY])
            {
                // Weiter geradeaus
            }
            else if (pheromonWerte[leftX, leftY] > pheromonWerte[rightX, rightY])
            {
                direction -= 20; // Nach links drehen
            }
            else if (pheromonWerte[rightX, rightY] > pheromonWerte[leftX, leftY])
            {
                direction += 20; // Nach rechts drehen
            }
            else
            {
                // Zufällige Drehung
                Random rand = new Random();
                direction += rand.Next(-15, 16); // Zufällige Drehung zwischen -15 und +15 Grad
            }
            x = frontX;
            y = frontY;
            pheromonWerte[x, y] = 0.9999;
        }

        public int validatePosition(int val, int min, int max)
        {
            if (val < min) return min;
            if (val > max) return max;
            return val;
        }
    }
}
