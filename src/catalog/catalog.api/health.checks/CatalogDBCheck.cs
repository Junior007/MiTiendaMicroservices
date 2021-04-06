using catalog.data.interfaces;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace catalog.api.health.checks
{
    public class CatalogDBCheck : IHealthCheck
    {

        ICatalogContext _catalogContext;
        public CatalogDBCheck(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            bool isHealthy = _catalogContext.Check();

            return Task.FromResult(HealthCheckResult.Healthy(nameof(CatalogDBCheck)));
        }
    }
}
