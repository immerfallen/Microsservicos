namespace WrokerTest
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine($"Worker running at: {DateTimeOffset.Now}");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
