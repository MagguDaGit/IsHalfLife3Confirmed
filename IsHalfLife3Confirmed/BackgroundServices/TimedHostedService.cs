namespace IsHalfLife3Confirmed.BackgroundServices
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<TimedHostedService> _logger;
        private Timer? _timer = null;

        public TimedHostedService(ILogger<TimedHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromDays(1));

            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            var count = Interlocked.Increment(ref executionCount);
            Fetcher fetcher = new Fetcher();
            if(DateTime.Today == fetcher.data.lastFetch )
            {
                Console.WriteLine("Skriver ikke til fil, har alt sjekket idag"); 
            }
            else
            {
                fetcher.GetNewData("https://www.ign.com/news");
                fetcher.WriteNewJSONFile();                   
            }
            _logger.LogInformation("Timed Hosted Service is working. Count: {Count}", count);

            if(!fetcher.data.confirmed)
            {
                fetcher.GetNewData("https://www.ign.com/news");
                fetcher.WriteNewJSONFile(); 
                _logger.LogInformation("Timed Hosted Service is working. Count: {Count}", count);
            }      
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Console.WriteLine("Utfører frigjøring av ressurser");
            _timer?.Dispose();
        }
    }
}
