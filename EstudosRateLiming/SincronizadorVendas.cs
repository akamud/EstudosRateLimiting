namespace EstudosRateLiming;

public class SincronizadorVendas
{
    public async Task Sincronizar()
    {
        Console.WriteLine("Rodando sincronizador de vendas");

        // Simulando delay na rede
        await Task.Delay(3_000);
    }
}
