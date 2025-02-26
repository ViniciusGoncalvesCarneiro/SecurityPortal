using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace GumAdvisor.EntityFrameworkCore
{
    public static class GumAdvisorDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<GumAdvisorDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<GumAdvisorDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}