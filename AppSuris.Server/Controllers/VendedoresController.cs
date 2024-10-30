using AppSuris.Server.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppSuris.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendedoresController : Controller
    {
        private readonly string _filePath = "Helpers/Data/vendedores_challenge.json";
        ILogger _logger;


        public VendedoresController(ILogger<VendedoresController> logger)
        {
            _logger = logger;
        }


        public List<Vendedor> GetVendedoresList()
        {
            var vendedores = JsonFileHelper.LeerArchivo<TypeVendedor>(_filePath);
            return vendedores?.Vendedores ?? new List<Vendedor>();
        }

        [HttpGet]
        public IActionResult GetVendedores()
        {
            try
            {
                return Ok(GetVendedoresList());
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);        
            }
        }
    }
}
