using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Clive.Models
{
    public class UserSettingsService
    {
        private readonly string _dbPath;


        public UserSettingsService()
        {
            _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "user_settings.db");
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var connection = new SqliteConnection($"Data Source={_dbPath}");
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Settings (
                    Key TEXT PRIMARY KEY, 
                    Value TEXT
                )";
            command.ExecuteNonQuery();
        }

        public async Task SaveSettingAsync(string key, string value)
        {
            using var connection = new SqliteConnection($"Data Source={_dbPath}");
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "INSERT OR REPLACE INTO Settings (Key, Value) VALUES (@key, @value)";
            command.Parameters.AddWithValue("@key", key);
            command.Parameters.AddWithValue("@value", value);
            await command.ExecuteNonQueryAsync();
        }


        public async Task<string> GetSettingAsync(string key, string defaultValue = "")
        {
            using var connection = new SqliteConnection($"Data Source={_dbPath}");
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT Value FROM Settings WHERE Key = @key";
            command.Parameters.AddWithValue("@key", key);

            var result = await command.ExecuteScalarAsync();
            return result?.ToString() ?? defaultValue;
        }

    }
}
