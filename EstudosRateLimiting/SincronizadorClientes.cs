using System.Threading.RateLimiting;

namespace EstudosRateLimiting;

public class SincronizadorClientes : Sincronizador
{
    public SincronizadorClientes(PartitionedRateLimiter<string> rateLimiter, ConcurrencyLimiter concurrencyRateLimiter) : base(rateLimiter, concurrencyRateLimiter)
    {
    }

    protected override string Recurso => "Clientes";

    protected override async Task SincronizarDados()
    {
        Console.WriteLine($"{DateTime.Now.ToString()}: Rodando sincronizador de clientes");

        // Simulando delay na rede
        await Task.Delay(1_500);
    }
}
