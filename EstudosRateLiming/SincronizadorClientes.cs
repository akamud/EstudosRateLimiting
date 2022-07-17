namespace EstudosRateLiming;

public class SincronizadorClientes
{
    public async Task Sincronizar()
    {
        Console.WriteLine("Rodando sincronizador de clientes");

        // Simulando delay na rede
        await Task.Delay(3_000);
    }
}
