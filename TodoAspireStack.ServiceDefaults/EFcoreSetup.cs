using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Hosting
{
    public static class EfcoreSetup
    {
        public static async Task MigrateEFCoreDatabaseAsync<T>(this WebApplication application) where T : DbContext
        {
            using var scope = application.Services.CreateScope();

            using DbContext context = scope.ServiceProvider.GetRequiredService<T>();

            application.Logger.LogInformation("Checking Migrations of Context \'" + typeof(T) + "\'");
            var PendingMigrations = await context.Database.GetPendingMigrationsAsync();

            if (PendingMigrations.Any())
            {
                application.Logger.LogInformation($"Applying {PendingMigrations.Count()} migration(s) to Database");
                await context.Database.MigrateAsync();
            }
            else
            {
                application.Logger.LogInformation($"No migrations to be added. Skipping migration......");
            }
        }
    }
}