using System.Threading.RateLimiting;

namespace EstudosRateLiming;

public class SincronizadorProdutos : Sincronizador
{
    public SincronizadorProdutos(PartitionedRateLimiter<string> rateLimiter, ConcurrencyLimiter concurrencyRateLimiter) : base(rateLimiter, concurrencyRateLimiter)
    {
    }

    protected override string Recurso => "Produtos";

    protected override async Task SincronizarDados()
    {
        Console.WriteLine($"{DateTime.Now.ToString()}: Rodando sincronizador de produtos");

        // Simulando delay na rede
        await Task.Delay(1_500);
    }
}
