using System.Threading.RateLimiting;

namespace EstudosRateLimiting;

public class SincronizadorVendas : Sincronizador
{
    protected override string Recurso => "Vendas";

    protected override async Task SincronizarDados()
    {
        Console.WriteLine($"{DateTime.Now.ToString()}: Rodando sincronizador de vendas");

        // Simulando delay na rede
        await Task.Delay(1_500);
    }
}
