namespace _25_cryptoPriceAPI
{
    public class PriceGenerator
    {
        private IServiceScopeFactory _scopeFactory;
        private Timer _timer;
        private Random _random = new Random();
        private bool _isRunning = false;

        public PriceGenerator(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public void Start()
        {
            if (_isRunning) return; // verhindert doppelte Timer

            _isRunning = true;
            _timer = new Timer(GeneratePrice, null, 0, 1000);
        }

        public void Stop()
        {
            _isRunning = false;

            if (_timer != null)
            {
                _timer.Dispose();
                _timer = null;
            }
        }

        private void GeneratePrice(object state)
        {
            if (!_isRunning) return;

            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                double lastPrice = 100;

                var last = context.CryptoPrices
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefault();

                if (last != null)
                    lastPrice = last.Price;

                double change = lastPrice * 0.05;
                double newPrice = lastPrice + (_random.NextDouble() * 2 - 1) * change;

                context.CryptoPrices.Add(new CryptoPrice
                {
                    Timestamp = DateTime.Now,
                    Price = newPrice
                });

                context.SaveChanges();
            }
        }
    }
    
}
