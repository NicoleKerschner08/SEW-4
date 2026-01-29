using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Physarum
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WriteableBitmap bitmap;
        double[,] pheromonAnzahl;
        List<partikel> partikelListe = new List<partikel>();
        int width = 500;
        int height = 500;
        Random rand = new Random();
        public MainWindow()
        {
            InitializeComponent();
            Setup();

        }


        public void Setup()
        {
            // Bitmap erstellen
            bitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Rgb24, null);
            img_physarum.Source = bitmap;

            // Pheromone initialisieren
            pheromonAnzahl = new double[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    pheromonAnzahl[x, y] = 0;
                }
            }

            // Partikel erzeugen
            for (int i = 0; i < 1000; i++)
            {
                partikel p = new partikel();
                p.x = rand.Next(0, width);
                p.y = rand.Next(0, height);
                p.direction = rand.Next(0, 360);
                partikelListe.Add(p);
            }

            // Event-Handler für Rendering hinzufügen
            CompositionTarget.Rendering += UpdateBitmap;
        }

        private void UpdateBitmap(object sender, EventArgs e)
        {
            byte[] pixels = new byte[width * height * 3];

            // Hintergrund aus Pheromonwerten
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int index = (y * width + x) * 3;
                    byte value = (byte)(pheromonAnzahl[x, y] * 255); // Graustufen
                    pixels[index + 0] = value; // rot
                    pixels[index + 1] = value; // grün
                    pixels[index + 2] = value; // blau
                }
            }

            // Partikel über den Hintergrund zeichnen
            foreach (var p in partikelListe)
            {
                // Partikel bewegen & Pheromon hinterlassen
                p.changeDirection(pheromonAnzahl);

            }
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    pheromonAnzahl[x, y] *= 0.98; // 5% Abbau pro Frame
                }
            }
            bitmap.WritePixels(new Int32Rect(0, 0, width, height), pixels, width * 3, 0);
            img_physarum.Source = bitmap;
        }

    }
}
