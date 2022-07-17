namespace EstudosRateLiming;

public class SincronizadorProdutos
{
    public async Task Sincronizar()
    {
        Console.WriteLine("Rodando sincronizador de produtos");

        // Simulando delay na rede
        await Task.Delay(3_000);
    }}
