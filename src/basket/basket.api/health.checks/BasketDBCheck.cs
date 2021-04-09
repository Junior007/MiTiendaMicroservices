using basket.data.interfaces;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace catalog.api.health.checks
{
    public class BasketDBCheck : IHealthCheck
    {

        private readonly IBasketContext _context;
        public BasketDBCheck(IBasketContext context)
        {
            _context = context;
        }
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            bool isHealthy = _context.IsOpen();

            return Task.FromResult(HealthCheckResult.Healthy(nameof(BasketDBCheck)));
        }
    }
}
