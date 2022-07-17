// See https://aka.ms/new-console-template for more information

using EstudosRateLiming;

Console.WriteLine("Sincronizador");

var sincronizadorClientes = new SincronizadorClientes();
var sincronizadorProdutos = new SincronizadorProdutos();
var sincronizadorVendas = new SincronizadorVendas();

for (var i = 0; i < 3; i++)
{
    _ = sincronizadorClientes.Sincronizar();
    _ = sincronizadorProdutos.Sincronizar();
    _ = sincronizadorVendas.Sincronizar();
}


Console.ReadLine();
