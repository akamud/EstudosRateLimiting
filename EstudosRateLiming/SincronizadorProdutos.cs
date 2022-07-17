using System.Threading.RateLimiting;

namespace EstudosRateLiming;

public class SincronizadorProdutos : Sincronizador
{
    public SincronizadorProdutos(RateLimiter rateLimiter) : base(rateLimiter)
    {
    }

    protected override async Task SincronizarDados()
    {
        Console.WriteLine($"{DateTime.Now.ToString()}: Rodando sincronizador de produtos");

        // Simulando delay na rede
        await Task.Delay(3_000);
    }
}
