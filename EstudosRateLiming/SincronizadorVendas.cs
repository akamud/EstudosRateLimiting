using System.Threading.RateLimiting;

namespace EstudosRateLiming;

public class SincronizadorVendas : Sincronizador
{
    public SincronizadorVendas(RateLimiter rateLimiter) : base(rateLimiter)
    {
    }

    protected override async Task SincronizarDados()
    {
        Console.WriteLine($"{DateTime.Now.ToString()}: Rodando sincronizador de vendas");

        // Simulando delay na rede
        await Task.Delay(1_500);
    }
}
