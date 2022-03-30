using System;
namespace Ioc.Web
{
    public class DateService : ISingletonDateService, IScopedDateService, ITransientDateService
    {
        private readonly ILogger<DateService> _logger;

        public DateService(ILogger<DateService> logger)
        {
            _logger = logger;
            _logger.LogWarning("DateService sign in constructor.");
            Console.WriteLine("Service is running");
        }

        public DateTime GetDateTime { get; } = DateTime.Now;
    }
}