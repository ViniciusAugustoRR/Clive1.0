using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Clive.Models
{
    public class AppSettings
    {
        public int IntervalMinutes { get; set; } = 60;
    }

    public static class SettingsManager
    {
        private static readonly string settingsFilePath = Path.Combine(FileSystem.AppDataDirectory, "settings.json");

        public static async Task SaveSettingsAsync(AppSettings settings)
        {
            string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(settingsFilePath, json);
        }

        public static async Task<AppSettings> LoadSettingsAsync()
        {
            if (!File.Exists(settingsFilePath))
                return new AppSettings(); // Return default settings if file doesn't exist

            string json = await File.ReadAllTextAsync(settingsFilePath);
            return JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();
        }
    }

}
