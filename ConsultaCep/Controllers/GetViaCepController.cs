using ConsultaCep.Integracao.Response;
using ConsultaCep.Integration.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsultaCep.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GetViaCepController : ControllerBase
    {
        private readonly IViaCep _viaCep;
        public GetViaCepController(IViaCep viaCep)
        {
            _viaCep = viaCep;
        }
        // GET: api/<ConsultaController>
        [HttpGet]
        public async Task<ActionResult<ViaCepResponse>> GetDataViaCep(string codePostal)
        {
            var response = await _viaCep.GetDataViaCep(codePostal);

            if(response is null)
            {
                return BadRequest("CEP não Localizado");
            }

            return Ok(response);
        }

    }
}
