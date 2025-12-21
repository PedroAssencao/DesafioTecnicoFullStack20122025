using ControleFinanceiro.API.DTO;
using ControleFinanceiro.Domain.Models;

namespace ControleFinanceiro.API.Mapper.CategoriaEntity
{
    public interface ICategoriaMapper
    {
        CategoriaDTO.CategoriaDTOView MapCategoriaParaCategoriaDtoView(Categoria model);
        Categoria MapCategoriaDtoCreateParaCategoria(CategoriaDTO.CategoriaDTOCreate model);
        Categoria MapCategoriaDTOUpdateParaCategoria(CategoriaDTO.CategoriaDTOUpdate model);
    }
}
