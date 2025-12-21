using AutoMapper;
using ControleFinanceiro.API.DTO;
using ControleFinanceiro.Domain.Models;
using ControleFinanceiro.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected readonly ICategoriaService _services;

        public CategoriaController(IMapper mapper, ICategoriaService services)
        {
            _mapper = mapper;
            _services = services;
        }

        // Endpoint para listagem de categorias com mapeamento para DTO de visualização.
        [HttpGet("BuscarTodasAsCategorias")]
        public async Task<IActionResult> getAllCategorias()
        {
            try
            {
                var listaCategorias = await _services.getAllAsync();
                return Ok(_mapper.Map<List<CategoriaDTO.CategoriaDTOView>>(listaCategorias));
            }
            catch (Exception ex)
            {
                // Tratamento de erro padronizado para retornar mensagens limpas ao frontend.
                return BadRequest(new
                {
                    Messages = ex.Message.Split(",")
                    .Where(x => x.ToString().Length > 0)
                    .Select(x => new { message = x.ToString() })
                });
            }
        }

        // Endpoint para criação de categoria, utilizando DTO para entrada e saída de dados.
        [HttpPost("CriarCategoria")]
        public async Task<IActionResult> createCategoria([FromBody] CategoriaDTO.CategoriaDTOCreate model)
        {
            try
            {
                // Mapeia o DTO de entrada para a Entidade de Domínio e executa a persistência via Service.
                Categoria resultado = await _services.createAsync(_mapper.Map<Categoria>(model));

                return Ok(_mapper.Map<CategoriaDTO.CategoriaDTOView>(resultado));
            }
            catch (Exception ex)
            {
                // Captura exceções de validação ou de banco e transforma a string de erros em um objeto JSON estruturado.
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