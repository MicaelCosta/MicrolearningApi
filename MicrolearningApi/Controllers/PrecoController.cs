using MicrolearningApi.Model.Business;
using Microsoft.AspNetCore.Mvc;

namespace MicrolearningApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrecoController : ControllerBase
    {
        private readonly IPrecoBusiness _precoBusiness;

        public PrecoController(IPrecoBusiness precoBusiness)
        {
            _precoBusiness = precoBusiness;
        }

        [HttpGet("{codigoProduto}")]
        public IActionResult ObterPreco(int codigoProduto, [FromQuery] int cepEntrega)
        {
            var retorno = _precoBusiness.ObterPreco(codigoProduto, cepEntrega);
            
            if(retorno is null)
            {
                return NotFound(new { erro = $"Produto {codigoProduto} não encontrada" });
            }

            return Ok(_precoBusiness);
        }
    }
}
