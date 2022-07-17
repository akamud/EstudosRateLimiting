using System.Threading.RateLimiting;

namespace EstudosRateLimiting;

public class SincronizadorProdutos : Sincronizador
{
    protected override string Recurso => "Produtos";

    protected override async Task SincronizarDados()
    {
        Console.WriteLine($"{DateTime.Now.ToString()}: Rodando sincronizador de produtos");

        // Simulando delay na rede
        await Task.Delay(1_500);
    }
}
