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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Chat
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ChatClient chatClient;
        ChatServer chatServer;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            int port = int.Parse(TxtHostingPort.Text);
            chatServer = new ChatServer(port, this);
            chatServer.Start();
        }

        private void btn_connect(object sender, RoutedEventArgs e)
        {
            int port = int.Parse(TxtRemoteServerPort.Text);
            chatClient = new ChatClient(port, this);

        }

        private void TxtSendingMessage_enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)  // Prüft, ob Enter gedrückt wurde
            {
                chatClient.SendMessage(TxtSendingMessage.Text);
            }
        }
    }

    public class ChatClient
    {
        private int port;
        MainWindow win;
        private Socket socket;

        public ChatClient(int port, MainWindow win)
        {
            this.port = port;
            this.win = win;

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(endPoint); 
        }

        public void SendMessage(string message)
        {
            try
            {
                socket.Send(Encoding.UTF8.GetBytes(message));
            }
            catch 
            {
                MessageBox.Show("Fehler beim Senden der Nachricht. Stellen Sie sicher, dass der Server läuft und erreichbar ist.", "Verbindungsfehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }


    public class ChatServer
    {
        private int port;
        MainWindow win;

        public ChatServer(int port, MainWindow win)
        {
            this.port = port;
            this.win = win;
        }

        public void Start()
        {
            Thread thread = new Thread(Run);
            thread.Start();
        }

        private void Run()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(endPoint);
            server.Listen(10);
            Socket client = server.Accept(); // blockiert, bis ein Client verbindet

            byte[] buffer = new byte[1024];
            string msg = "";
            while (msg!="Ende" && msg!="ende"){
                int received = client.Receive(buffer);
                msg = Encoding.UTF8.GetString(buffer, 0, received);

                win.Dispatcher.Invoke(() =>
                {
                    win.LstMessages.Items.Add(msg);
                });
            }
            

            client.Shutdown(SocketShutdown.Both);
            client.Close();
            server.Close();
        }
    }

}
