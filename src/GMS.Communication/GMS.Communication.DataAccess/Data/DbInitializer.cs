using GMS.Communication.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GMS.Communication.DataAccess.Data
{
    public class DbInitializer
    {
        private static GmsMessagesDb _db;
        private static ILogger<GmsMessagesDb> _logger;

        public static async Task InitializeAsync(GmsMessagesDb db, ILogger<GmsMessagesDb> logger,
            bool restoreDb = false)
        {
            _db = db;
            _logger = logger;
            _logger.LogInformation("Initializing Db ...");
            await RestoreDbAsync(restoreDb);
            await InitializeMessagesAsync();
            _logger.LogInformation("Initializing Db has successfully done!");
        }

        private static async Task RestoreDbAsync(bool restoreDb)
        {
            if (!restoreDb) return;
            _logger.LogInformation("Restoring Db ...");
            await _db.Database.EnsureDeletedAsync();
            await _db.Database.EnsureCreatedAsync();
            _logger.LogInformation("Success");
        }

        public static async Task InitializeMessagesAsync()
        {
            _logger.LogInformation("Initializing messages ...");
            if (await _db.Messages.AnyAsync())
            {
                _logger.LogInformation("Initializing don't need");
                return;
            }

            await _db.Messages.AddRangeAsync(TestData.Messages);
            await _db.SaveChangesAsync();
            _logger.LogInformation("Success");
        }
    }
}
