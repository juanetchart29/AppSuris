using AppSuris.Server.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AppSuris.Server.Brokers;
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

        [HttpGet]
        public IActionResult GetVendedores()
        {
            try
            {
                return Ok(Broker.GetVendedoresList(_filePath));
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);        
            }
        }
    }
}
