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
using System.Net.Http;

namespace wpf_threading
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void click_start(object sender, RoutedEventArgs e)
        {

            WebCrawler crawler = new WebCrawler("https://www.htlwy.at");
            crawler.Run();
        }

        private void click_stop(object sender, RoutedEventArgs e)
        {
        }
    }
}
