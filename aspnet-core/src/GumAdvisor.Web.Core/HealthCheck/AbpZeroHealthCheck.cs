using Microsoft.Extensions.DependencyInjection;
using GumAdvisor.HealthChecks;

namespace GumAdvisor.Web.HealthCheck
{
    public static class AbpZeroHealthCheck
    {
        public static IHealthChecksBuilder AddAbpZeroHealthCheck(this IServiceCollection services)
        {
            var builder = services.AddHealthChecks();
            builder.AddCheck<GumAdvisorDbContextHealthCheck>("Database Connection");
            builder.AddCheck<GumAdvisorDbContextUsersHealthCheck>("Database Connection with user check");
            builder.AddCheck<CacheHealthCheck>("Cache");

            // add your custom health checks here
            // builder.AddCheck<MyCustomHealthCheck>("my health check");

            return builder;
        }
    }
}
