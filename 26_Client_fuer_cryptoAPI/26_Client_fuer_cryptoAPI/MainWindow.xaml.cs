using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Net.Http;
using System.Net.Http.Json;
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

namespace _26_Client_fuer_cryptoAPI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ChartValues<decimal> PriceValues { get; set; } = new ChartValues<decimal>();
        public List<string> TimeLabels { get; set; } = new List<string>();
        private readonly HttpClient _httpClient;
        public MainWindow()
        {
            InitializeComponent();


            DataContext = this;
            _httpClient = new HttpClient { BaseAddress = new Uri(UrlTextBox.Text) };
            
        }

        private async Task LoadData()
        {
            var prices = await _httpClient.GetFromJsonAsync<List<CryptoPrice>>("api/CryptoPrices");
            foreach (var price in prices)
            {
                PriceValues.Add(price.Price);
                TimeLabels.Add(price.Timestamp.ToString("HH:mm:ss"));
            }

            PriceChart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Kursverlauf",
                    Values = PriceValues,
                    PointGeometrySize = 5
                }
            };

            PriceChart.AxisX[0].Labels = TimeLabels;
            var count = await _httpClient.GetFromJsonAsync<int>("api/CryptoPrices/count");
            tbx_countValues.Text = count.ToString();
        }

        private async void loadData_click(object sender, RoutedEventArgs e)
        {
            PriceValues.Clear();
            await LoadData();
        }
    }

    // Fügen Sie die Definition für den Typ CryptoPrice hinzu, da dieser im aktuellen Kontext fehlt.
    // Platzieren Sie diese Klasse im selben Namespace wie MainWindow, um CS0246 zu beheben.
    public class CryptoPrice
    {
        public decimal Price { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
