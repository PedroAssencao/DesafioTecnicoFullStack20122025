using AutoMapper; // Adicione este using
using ControleFinanceiro.API.DTO;
using ControleFinanceiro.Domain.Models;
using ControleFinanceiro.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControleFinanceiro.API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        protected readonly IPessoaServices _services;
        protected readonly IMapper _mapper;

        public PessoaController(IPessoaServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpGet("BuscarTodasAsPessoas")]
        public async Task<IActionResult> getAllPessoas()
        {
            try
            {
                List<PessoaDTO.PessoaDTOView> listaDto = _mapper.Map<List<PessoaDTO.PessoaDTOView>>(await _services.getAllAsync());
                return Ok(listaDto);
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

        [HttpPost("CadastrarNovaPessoa")]
        public async Task<IActionResult> createPessoa([FromBody] PessoaDTO.PessoaDTOCreate model)
        {
            try
            {
                Pessoa resultado = await _services.createAsync(_mapper.Map<Pessoa>(model));
                return Ok(_mapper.Map<PessoaDTO.PessoaDTOView>(resultado));
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

        [HttpPut("AtualizarPessoa")]
        public async Task<IActionResult> atualizarPessoa([FromBody] PessoaDTO.PessoaDTOUpdate model)
        {
            try
            {
                bool resultado = await _services.updateAsync(_mapper.Map<Pessoa>(model));
                return Ok(resultado);
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

        [HttpDelete("DeletarPessoa")]
        public async Task<IActionResult> deletePessoa(int id)
        {
            try
            {
                return Ok(await _services.deleteAsync(id));
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