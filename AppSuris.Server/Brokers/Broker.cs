using AppSuris.Server.Helpers;
using AppSuris.Server.Models;
using System.Text.RegularExpressions;

namespace AppSuris.Server.Brokers
{
    public static class Broker
    {

        public static List<Articulos> GetArticulosList(string filePath)
        {
            var articulosData = JsonFileHelper.LeerArchivo<TypeArticulos>(filePath);
            var articulosBruto = articulosData?.Articulos ?? new List<Articulos>();

            var articulosLimpios = articulosBruto.Select(articulo => LimpiarArticulo(articulo)).Where(articulo => articulo != null).ToList();
            return articulosLimpios;


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


        private static Articulos LimpiarArticulo(Articulos articulo)
        {
            if (articulo.Precio <= 0)
            {
                return null; 
            }

            var regex = new Regex(@"[^a-zA-Z0-9\s\-\.]");
            if (regex.IsMatch(articulo.Descripcion))
            {
                return null; 
            }

            //  Deposito 1
            if (articulo.Deposito != 1)
            {
                return null; 
            }

            string codigoLimpio = Regex.Replace(articulo.Codigo, @"[^a-zA-Z0-9]", "");
            string descripcionLimpia = articulo.Descripcion; 
            // SI LLEGA hasta aca ya esta validado
            return new Articulos
            {
                Codigo = codigoLimpio,
                Descripcion = descripcionLimpia,
                Precio = articulo.Precio, 
                Deposito = articulo.Deposito 
            };
        }



    }
}
