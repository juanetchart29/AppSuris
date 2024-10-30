using Microsoft.AspNetCore.Mvc;
using AppSuris.Server.Models;

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



        public List<Articulos> GetArticulosList()
        {
                var articulosData = JsonFileHelper.LeerArchivo<TypeArticulos>(filePath);
                return articulosData?.Articulos ?? new List<Articulos>();

        }


        [HttpGet]
        public IActionResult GetArticulos()
        {
            try
            {
                return Ok(GetArticulosList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
