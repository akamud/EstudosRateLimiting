namespace EstudosRateLimiting;

public abstract class Sincronizador
{
    protected abstract string Recurso { get; }

    public virtual async Task Sincronizar()
    {
        await SincronizarDados();
    }

    protected abstract Task SincronizarDados();
}
