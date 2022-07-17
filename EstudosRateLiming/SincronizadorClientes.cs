using System.Threading.RateLimiting;

namespace EstudosRateLiming;

public class SincronizadorClientes : Sincronizador
{
    public SincronizadorClientes(RateLimiter rateLimiter) : base(rateLimiter)
    {
    }

    protected override async Task SincronizarDados()
    {
        Console.WriteLine($"{DateTime.Now.ToString()}: Rodando sincronizador de clientes");

        // Simulando delay na rede
        await Task.Delay(3_000);
    }
}
