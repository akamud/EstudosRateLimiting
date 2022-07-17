// See https://aka.ms/new-console-template for more information

using EstudosRateLiming;
using System.Threading.RateLimiting;

Console.WriteLine("Sincronizador");

var concurrencyRateLimiter =
    new ConcurrencyLimiter(new ConcurrencyLimiterOptions(2, QueueProcessingOrder.OldestFirst, int.MaxValue));

var sincronizadorClientes = new SincronizadorClientes(concurrencyRateLimiter);
var sincronizadorProdutos = new SincronizadorProdutos(concurrencyRateLimiter);
var sincronizadorVendas = new SincronizadorVendas(concurrencyRateLimiter);

var tasks = new List<Task>();

for (var i = 0; i < 3; i++)
{
    tasks.Add(sincronizadorClientes.Sincronizar());
    tasks.Add(sincronizadorProdutos.Sincronizar());
    tasks.Add(sincronizadorVendas.Sincronizar());
}

await Task.WhenAll(tasks);
Console.WriteLine("Sincronizador finalizado");
Console.ReadLine();
