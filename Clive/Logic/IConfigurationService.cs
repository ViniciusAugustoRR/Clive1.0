using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clive.Logic
{
    public interface IConfigurationService
    {
        Task<int> GetIntervalMinutesAsync();
        Task SetIntervalMinutesAsync(int minutes);

    }
}
