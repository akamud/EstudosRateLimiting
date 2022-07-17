using System.Threading.RateLimiting;

namespace EstudosRateLiming;

public abstract class Sincronizador
{
    protected readonly RateLimiter RateLimiter;

    protected Sincronizador(RateLimiter rateLimiter) => RateLimiter = rateLimiter;

    public virtual async Task Sincronizar()
    {
        using var lease = await RateLimiter.WaitAsync();
        if (lease.IsAcquired)
        {
            await SincronizarDados();
        }
    }

    protected abstract Task SincronizarDados();
}
