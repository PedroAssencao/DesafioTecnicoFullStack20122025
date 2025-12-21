using ControleFinanceiro.API.DTO;
using ControleFinanceiro.API.Mapper.PessoaEntity;
using ControleFinanceiro.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        protected readonly IPessoaServices _services;
        protected readonly IPessoaMapper _mapper;

        public PessoaController(IPessoaServices services, IPessoaMapper pessoaMapper)
        {
            _services = services;
            _mapper = pessoaMapper;
        }

        [HttpGet("BuscarTodasAsPessoas")]
        public async Task<IActionResult> getAllPessoas()
        {
            try
            {
                return Ok(_mapper.MapListPessoaParaListPessoaDTO(await _services.getAllAsync()));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
        [HttpPost("CadastrarNovaPessoa")]
        public async Task<IActionResult> createPessoa([FromBody] PessoaDTO.PessoaDTOCreate model)
        {
            try
            {
                return Ok(await _services.createAsync(_mapper.MapPessoaDtoCreateParaPessoa(model)));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
        [HttpPut("AtualizarPessoa")]
        public async Task<IActionResult> atualizarPessoa([FromBody] PessoaDTO.PessoaDTOUpdate model)
        {
            try
            {
                return Ok(await _services.updateAsync(_mapper.MapPessoaDtoUpdateParaPessoa(model)));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
        [HttpDelete("DeletarPessoa")]
        public async Task<IActionResult> deletePessoa(int id)
        {
            try
            {
                return Ok(await _services.deleteAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}
