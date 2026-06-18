using ConsultaCepApi.Services;
using ConsultaCepApi.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaCepApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CepController : ControllerBase
    {
        private readonly ViaCepService _service;

        public CepController()
        {
            _service = new ViaCepService();
        }

        [HttpGet("{cep}")]
        public async Task<IActionResult> BuscarCep(string cep)
        {
            try
            {
                var endereco = await _service.BuscarCepAsync(cep);

                ArquivoHelper.Salvar(cep);

                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return BadRequest(new {erro = ex.Message});
            }
        }

        [HttpGet("historico")]
        public IActionResult Historico()
        {
            var historico = ArquivoHelper.LerHistorico();

            return Ok(historico);
        }
    }
}
