﻿using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;
using System.Threading.Tasks;

namespace catalog.api.health.checks
{

    public class general : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = new CancellationToken())
        {

            return Task.FromResult(HealthCheckResult.Healthy(nameof(general)));
        }
    }
}
