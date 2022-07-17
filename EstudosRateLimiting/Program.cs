using EstudosRateLimiting;
using System.Threading.RateLimiting;

Console.WriteLine("Sincronizador");

var concurrencyRateLimiter =
    new ConcurrencyLimiter(new ConcurrencyLimiterOptions(1, QueueProcessingOrder.OldestFirst, int.MaxValue));

var partitionedRateLimiter = PartitionedRateLimiter.Create<string, string>(resource =>
{
    return RateLimitPartition.Create(resource,
        _ => new ConcurrencyLimiter(new ConcurrencyLimiterOptions(1, QueueProcessingOrder.OldestFirst, 0)));
});

var sincronizadorClientes = new SincronizadorClientes(partitionedRateLimiter, concurrencyRateLimiter);
var sincronizadorProdutos = new SincronizadorProdutos(partitionedRateLimiter, concurrencyRateLimiter);
var sincronizadorVendas = new SincronizadorVendas(partitionedRateLimiter, concurrencyRateLimiter);

var tasks = new List<Task>();

for (var i = 0; i < 10; i++)
{
    tasks.Add(sincronizadorClientes.Sincronizar());
    tasks.Add(sincronizadorClientes.Sincronizar());

    tasks.Add(sincronizadorProdutos.Sincronizar());
    tasks.Add(sincronizadorProdutos.Sincronizar());

    tasks.Add(sincronizadorVendas.Sincronizar());
    tasks.Add(sincronizadorVendas.Sincronizar());
}

await Task.Delay(4_000);
tasks.Add(sincronizadorProdutos.Sincronizar());

await Task.WhenAll(tasks);
Console.WriteLine("Sincronizador finalizado");
Console.ReadLine();
