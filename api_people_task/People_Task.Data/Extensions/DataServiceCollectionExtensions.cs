using Microsoft.Extensions.DependencyInjection;

namespace People_Task.Data.Extensions
{
    public static class DataServiceCollectionExtensions
    {
        public static void AddPostgresqlRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPostgresqlRepository), typeof(PostgresqlRepository));
        }
    }
}