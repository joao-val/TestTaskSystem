using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas_api_basica_.Integration.Interface;
using SistemaDeTarefas_api_basica_.Integration.Response;

namespace SistemaDeTarefas_api_basica_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegration _viaCepIntegration;
        public CepController(IViaCepIntegration viaCepIntegration)
        {
            _viaCepIntegration = viaCepIntegration;
        }
        [HttpGet("{cep}")]
        public async Task<ActionResult<ViaCepResponse>> AddressDataList(string cep)
        {
            var responseData = await _viaCepIntegration.GetDataViaCep(cep);

            if(responseData == null)
            {
                return BadRequest("CEP not found!");
            }
            return Ok(responseData);
        }
    }
}
