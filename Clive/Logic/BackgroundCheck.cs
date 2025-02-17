using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clive.Logic
{
    public class BackGroundCheck : BackgroundService
    {
        private readonly ILogger<BackGroundCheck> _logger;

        public BackGroundCheck(ILogger<BackGroundCheck> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Background Task Running at {DateTime.Now}");

                await DeleteCheck();

                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }

        private Task DeleteCheck()
        {

            Console.WriteLine("Executing background task...");
            return Task.CompletedTask;
        }
    }

}
