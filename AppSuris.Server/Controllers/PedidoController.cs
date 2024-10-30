using Microsoft.AspNetCore.Mvc;
using AppSuris.Server.Helpers;
using AppSuris.Server.Brokers;

namespace AppSuris.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly string filePath = "Helpers/Data/pedidos.json"; 
        private readonly ILogger _logger;

        public PedidoController(ILogger<PedidoController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult GuardarCompra([FromBody] List<Pedido> pedidos)
        {
            if (pedidos == null || pedidos.Count == 0)
            {
                return BadRequest("Debes seleccionar al menos un articulos para realizar la compra.");
            }

            var comprasData = JsonFileHelper.LeerArchivo<TypePedido>(filePath) ?? new TypePedido();

            foreach (var pedido in pedidos)
            {
                if (!ValidarCompra(pedido))
                {
                    return BadRequest($"El PEDIDO contiene articulos no validos.");
                }

                pedido.Id = comprasData.Pedidos.Count + 1; // agrego ids unicosss
                pedido.Fecha = DateTime.UtcNow;
                comprasData.Pedidos.Add(pedido);
            }

            JsonFileHelper.EscribirArchivo(filePath, comprasData);

            return Ok(new { mensaje = "Pedidos guardados exitosamente", pedidosGuardados = pedidos });
        }

        private bool ValidarCompra(Pedido pedido)
        {
            if (pedido == null || pedido.ArticulosIds == null || pedido.ArticulosIds.Count == 0)
            {
                return false;
            }

            var regex = new System.Text.RegularExpressions.Regex(@"[^a-zA-Z0-9\s]");
            var articulosPedidos = Broker.GetArticulosList(filePath)
                                                    .Where(x => pedido.ArticulosIds.Contains(x.Codigo)
                                                                && x.Deposito == 1) 
                                                    .ToList();

            foreach (var articulo in articulosPedidos)
            {
                if (articulo.Precio <= 0 || regex.IsMatch(articulo.Descripcion))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
