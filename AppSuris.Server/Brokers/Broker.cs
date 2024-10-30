using AppSuris.Server.Helpers;
using AppSuris.Server.Models;

namespace AppSuris.Server.Brokers
{
    public static class Broker
    {

        public static List<Articulos> GetArticulosList(string filePath)
        {
            var articulosData = JsonFileHelper.LeerArchivo<TypeArticulos>(filePath);
            return articulosData?.Articulos ?? new List<Articulos>();

        } 
        public static List<Vendedor> GetVendedoresList(string filePath)
        {
            var vendedorData = JsonFileHelper.LeerArchivo<TypeVendedor>(filePath);
            return vendedorData?.Vendedores?? new List<Vendedor>();

        }
        //static List<Pedido> GetPedidosList(string filePath)
        //{
        //    var pedidosData = JsonFileHelper.LeerArchivo<TypePedido>(filePath);
        //    return pedidosData?.Pedidos ?? new List<Pedido>();

        //}



    }
}
