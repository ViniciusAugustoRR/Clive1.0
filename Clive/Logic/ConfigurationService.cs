using Clive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clive.Logic
{
    public class ConfigurationService : IConfigurationService
    {
        private const string IntervalKey = "IntervalMinutes";

        public Task<int> GetIntervalMinutesAsync()
        {
            int minutes = Preferences.Get(IntervalKey, 60); // default 60
            return Task.FromResult(minutes);
        }

        public Task SetIntervalMinutesAsync(int minutes)
        {
            Preferences.Set(IntervalKey, minutes);
            return Task.CompletedTask;
        }
    }


}
