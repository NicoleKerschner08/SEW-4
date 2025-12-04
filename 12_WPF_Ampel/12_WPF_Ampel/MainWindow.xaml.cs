using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _12_WPF_Ampel
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            startTrafficLight();
        }

        void startTrafficLight()
        {
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    // Red light
                    Dispatcher.Invoke(() =>
                    {
                        red_light.Fill = Brushes.Red;
                        yellow_light.Fill = Brushes.LightGray;
                        green_light.Fill = Brushes.LightGray;
                    });
                    Thread.Sleep(2000);
                    // Yellow light
                    Dispatcher.Invoke(() =>
                    {
                        red_light.Fill = Brushes.LightGray;
                        yellow_light.Fill = Brushes.Yellow;
                        green_light.Fill = Brushes.LightGray;
                    });
                    Thread.Sleep(500);
                    // Green light
                    Dispatcher.Invoke(() =>
                    {
                        red_light.Fill = Brushes.LightGray;
                        yellow_light.Fill = Brushes.LightGray;
                        green_light.Fill = Brushes.Green;
                    });
                    Thread.Sleep(2000);
                    
                    for(int counter = 0; counter < 5; counter++)
                    {
                        // Blinking green light
                        Dispatcher.Invoke(() =>
                        {
                            green_light.Fill = Brushes.Green;
                        });
                        Thread.Sleep(100);
                        Dispatcher.Invoke(() =>
                        {
                            green_light.Fill = Brushes.LightGray;
                        });
                        Thread.Sleep(100);
                    }
                }
            });
            thread.Start();
        }
    }
}
