using System.Diagnostics.CodeAnalysis;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movements.Infrastructure.Data;

namespace Movements.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddData(configuration);
        }

        private static void AddData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovementsDbContext>(options =>
            {
                options.UseSqlServer(BuildConnectionString(configuration));
            });
        }

        private static string BuildConnectionString(IConfiguration configuration)
        {
            var connectionDbSection = configuration.GetSection("MovementsDb");

            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = connectionDbSection["Host"],
                InitialCatalog = connectionDbSection["InitialCatalog"],
                UserID = connectionDbSection["User"],
                Password = connectionDbSection["Password"]
            };
            return connectionStringBuilder.ConnectionString;
        }
    }
}