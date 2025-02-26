﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using GumAdvisor.EntityFrameworkCore;

namespace GumAdvisor.HealthChecks
{
    public class GumAdvisorDbContextHealthCheck : IHealthCheck
    {
        private readonly DatabaseCheckHelper _checkHelper;

        public GumAdvisorDbContextHealthCheck(DatabaseCheckHelper checkHelper)
        {
            _checkHelper = checkHelper;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            if (_checkHelper.Exist("db"))
            {
                return Task.FromResult(HealthCheckResult.Healthy("GumAdvisorDbContext connected to database."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("GumAdvisorDbContext could not connect to database"));
        }
    }
}
