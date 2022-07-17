using System.Threading.RateLimiting;

namespace EstudosRateLimiting;

public abstract class Sincronizador
{
    private readonly PartitionedRateLimiter<string> _rateLimiter;
    private readonly ConcurrencyLimiter _concurrencyRateLimiter;

    protected Sincronizador(PartitionedRateLimiter<string> rateLimiter, ConcurrencyLimiter concurrencyRateLimiter)
    {
        _rateLimiter = rateLimiter;
        _concurrencyRateLimiter = concurrencyRateLimiter;
    }

    protected abstract string Recurso { get; }

    public virtual async Task Sincronizar()
    {
        using var lease = await _rateLimiter.WaitAsync(Recurso);
        if (lease.IsAcquired)
        {
            using var globalLease = await _concurrencyRateLimiter.WaitAsync();
            if (globalLease.IsAcquired)
                await SincronizarDados();
        }
    }

    protected abstract Task SincronizarDados();
}
