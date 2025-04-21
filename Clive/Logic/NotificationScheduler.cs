using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clive.Logic
{
    public class NotificationScheduler : BackgroundService
    {
        private readonly IConfigurationService _configService;

        public NotificationScheduler(IConfigurationService configService)
        {
            _configService = configService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                int intervalMinutes = await _configService.GetIntervalMinutesAsync();

                // Do your popup/notification
                ShowNotification("Reminder", "It's time to check something!");

                await Task.Delay(TimeSpan.FromMinutes(intervalMinutes), stoppingToken);
            }
        }

        private void ShowNotification(string title, string message)
        {
            //var toast = new Windows.UI.Notifications.ToastNotificationManagerCompat();
            // Or use your custom tray/WinUI3 code to show native Windows notification
        }
    }

}
