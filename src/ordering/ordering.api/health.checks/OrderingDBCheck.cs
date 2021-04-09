
using Microsoft.Extensions.Diagnostics.HealthChecks;
using ordering.data.context;
using System.Threading;
using System.Threading.Tasks;

namespace catalog.api.health.checks
{
    public class OrderingDBCheck : IHealthCheck
    {

        private readonly OrderContext _context;
        public OrderingDBCheck(OrderContext context)
        {
            _context = context;
        }
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {

            bool isHealthy = _context.IsOpen();

            return Task.FromResult(HealthCheckResult.Healthy(nameof(OrderingDBCheck)));
        }
    }
}
