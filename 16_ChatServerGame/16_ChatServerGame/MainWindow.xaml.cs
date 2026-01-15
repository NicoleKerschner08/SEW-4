using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
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

namespace _16_ChatServerGame
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string msg = "";
        NetworkStream networkStream;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await Start();
        }

        public async Task Start()
        {
            TcpClient tcpClient = new TcpClient();
            try
            {
                await tcpClient.ConnectAsync("127.0.0.1", 5000);
                networkStream = tcpClient.GetStream();               
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Socket Exception: {ex.Message}");
            }
        }

        public async Task SendMessage(NetworkStream stream)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            await stream.WriteAsync(buffer, 0, buffer.Length);
        }

        private async void btn_stein_Click(object sender, RoutedEventArgs e)
        {
            img_your_choice.Source = new BitmapImage(
                new Uri("pack://application:,,,/Images/einstein.png", UriKind.Absolute)
            );
            msg = "stein";
            await SendMessage(networkStream);
        }

        private async void btn_papier_Click(object sender, RoutedEventArgs e)
        {
            img_your_choice.Source = new BitmapImage(
                new Uri("pack://application:,,,/Images/papier.png", UriKind.Absolute)
            );
            msg = "papier";
            await SendMessage(networkStream);
        }

        private async void btn_schere_Click(object sender, RoutedEventArgs e)
        {
            img_your_choice.Source = new BitmapImage(
                new Uri("pack://application:,,,/Images/schere.png", UriKind.Absolute)
            );
            msg = "schere";
            await SendMessage(networkStream);
        }
    }
}
