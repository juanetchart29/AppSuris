using Microsoft.AspNetCore.Mvc;
using AppSuris.Server.Brokers;

namespace AppSuris.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly string filePath = "Helpers/Data/articulos_challenge.json";


        ILogger _logger;

        public ArticulosController()
        {

        }
        public ArticulosController(ILogger<ArticulosController> logger)
        {
            _logger = logger;
        }





        [HttpGet]
        public IActionResult GetArticulos()
        {
            try
            {
                return Ok(Broker.GetArticulosList(filePath));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
