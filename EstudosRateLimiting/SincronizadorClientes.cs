using System.Threading.RateLimiting;

namespace EstudosRateLimiting;

public class SincronizadorClientes : Sincronizador
{
    public SincronizadorClientes(ConcurrencyLimiter rateLimiter) : base(rateLimiter)
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
