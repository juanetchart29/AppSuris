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
        public IActionResult GuardarCompra([FromBody] Pedido pedido) // Cambiado a un solo pedido
        {
            if (pedido == null)
            {
                return BadRequest("El pedido no puede ser nulo.");
            }

            var comprasData = JsonFileHelper.LeerArchivo<TypePedido>(filePath) ?? new TypePedido();

            if (!ValidarPedido(pedido))
            {
                return BadRequest("El pedido contiene artículos no válidos.");
            }

            pedido.Id = comprasData.Pedidos.Count + 1; // Asignar un ID único
            pedido.Fecha = DateTime.UtcNow; // Asignar la fecha actual
            comprasData.Pedidos.Add(pedido); // Agregar el pedido a la lista

            JsonFileHelper.EscribirArchivo(filePath, comprasData); // Persistir los cambios

            return Ok(new { mensaje = "Pedido guardado exitosamente", pedidoGuardado = pedido });
        }
        // valido como llegan los datos (por las dudas)
        private bool ValidarPedido(Pedido pedido)
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
