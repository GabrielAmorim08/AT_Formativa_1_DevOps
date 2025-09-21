using ATV_Formativa.Web.API.Interfaces.Calculadora;
using ATV_Formativa.Web.API.Interfaces.NovaPasta;
using ATV_Formativa.Web.API.Models;
using ATV_Formativa.Web.API.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ATV_Formativa.Web.API.Controllers.Calculadora
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {
        private readonly ICalculadoraService _calcService;
        public CalculadoraController(ICalculadoraService service) { _calcService = service; }

        [HttpGet("Somar")]
        public async Task<IActionResult> GetAll([FromQuery] int a, [FromQuery]int b)
        {
            Response response = await _calcService.Somar(a,b);
            return StatusCode(response.Code,response);
        }
        [HttpPost($"Dividir")]
        public async Task<IActionResult> Create([FromQuery] int a, [FromQuery]int b)
        {
            Response response = await _calcService.Dividir(a,b);
            return StatusCode(response.Code,response);
        }
    }
}
