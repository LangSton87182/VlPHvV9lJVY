// 代码生成时间: 2025-09-05 05:16:54
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace XamarinDatabaseMigration
{
    /// <summary>
    /// Database migration tool for Xamarin applications.
    /// </summary>
    public class DatabaseMigrator
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<DatabaseMigrator> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseMigrator"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="logger">The logger.</param>
        public DatabaseMigrator(IServiceProvider serviceProvider, ILogger<DatabaseMigrator> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        /// <summary>
        /// Migrates the database to the latest version.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task MigrateAsync()
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<MyDbContext>(); // Replace MyDbContext with your actual DbContext
                    await context.Database.MigrateAsync();
                    _logger.LogInformation("Database migration completed successfully.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during database migration.");
                throw; // Re-throw the exception to handle it further up the call stack
            }
        }
    }

    /// <summary>
    /// Extensions for IServiceCollection to add database migration services.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds database migration services to the service collection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddDatabaseMigration(this IServiceCollection services)
        {
            services.AddScoped<DatabaseMigrator>();
            return services;
        }
    }
}
