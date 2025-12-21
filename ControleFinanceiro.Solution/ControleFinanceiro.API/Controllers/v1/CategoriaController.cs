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

        [HttpGet("BuscarTodasAsCategorias")]
        public async Task<IActionResult> getAllCategorias()
        {
            try
            {
                return Ok(_mapper.Map<List<CategoriaDTO.CategoriaDTOView>>(await _services.getAllAsync()));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
        [HttpPost("CriarCategoria")]
        public async Task<IActionResult> createCategoria([FromBody] CategoriaDTO.CategoriaDTOCreate model)
        {
            try
            {
                Categoria resultado = await _services.createAsync(_mapper.Map<Categoria>(model));
                return Ok(_mapper.Map<CategoriaDTO.CategoriaDTOView>(resultado));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}
