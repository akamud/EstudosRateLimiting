using EstudosRateLimiting;
using System.Threading.RateLimiting;

Console.WriteLine("Sincronizador");

var sincronizadorClientes = new SincronizadorClientes();
var sincronizadorProdutos = new SincronizadorProdutos();
var sincronizadorVendas = new SincronizadorVendas();

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
