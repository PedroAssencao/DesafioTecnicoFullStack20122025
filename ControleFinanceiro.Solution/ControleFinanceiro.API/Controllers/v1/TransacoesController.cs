using AutoMapper;
using ControleFinanceiro.API.DTO;
using ControleFinanceiro.Domain.Models;
using ControleFinanceiro.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TransacoesController : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected readonly ITransacoesServices _services;

        public TransacoesController(IMapper mapper, ITransacoesServices services)
        {
            _mapper = mapper;
            _services = services;
        }

        // Lista todas as transações
        [HttpGet("BuscarTodasAsTransacoes")]
        public async Task<IActionResult> getAllTransacoes()
        {
            try
            {
                var transacoes = await _services.getAllAsync();
                return Ok(_mapper.Map<List<TransacoesDTO.TranscacoesDTOView>>(transacoes));
            }
            catch (Exception ex)
            {
                // Converte a string de erros em uma lista de objetos para o Frontend.
                return BadRequest(new
                {
                    Messages = ex.Message.Split(",")
                    .Where(x => x.ToString().Length > 0)
                    .Select(x => new { message = x.ToString() })
                });
            }
        }

        // Cria uma nova transação.
        [HttpPost("CriarTransacao")]
        public async Task<IActionResult> creatTransacao([FromBody] TransacoesDTO.transacoesDTOCreate model)
        {
            try
            {
                // Converte o DTO simples para a entidade de domínio.
                Transaco resultado = await _services.createAsync(_mapper.Map<Transaco>(model));

                return Ok(_mapper.Map<TransacoesDTO.TranscacoesDTOView>(resultado));
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Messages = ex.Message.Split(",")
                    .Where(x => x.ToString().Length > 0)
                    .Select(x => new { message = x.ToString() })
                });
            }
        }
    }
}