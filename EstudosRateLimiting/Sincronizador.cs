using System.Threading.RateLimiting;

namespace EstudosRateLimiting;

public abstract class Sincronizador
{
    private readonly ConcurrencyLimiter _rateLimiter;

    protected Sincronizador(ConcurrencyLimiter rateLimiter)
    {
        _rateLimiter = rateLimiter;
    }

    protected abstract string Recurso { get; }

    public virtual async Task Sincronizar()
    {
        using var lease = await _rateLimiter.WaitAsync();
        if (lease.IsAcquired)
        {
            await SincronizarDados();
        }
    }

    protected abstract Task SincronizarDados();
}
