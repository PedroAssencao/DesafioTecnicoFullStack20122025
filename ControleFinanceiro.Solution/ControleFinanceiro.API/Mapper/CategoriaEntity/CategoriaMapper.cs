using ControleFinanceiro.API.DTO;
using ControleFinanceiro.Domain.Enums.Base;
using ControleFinanceiro.Domain.Models;

namespace ControleFinanceiro.API.Mapper.CategoriaEntity
{
    public class CategoriaMapper : ICategoriaMapper
    {
        public CategoriaDTO.CategoriaDTOView MapCategoriaParaCategoriaDtoView(Categoria model)
        {
            return new CategoriaDTO.CategoriaDTOView
            {
                Codigo = model.CatId,
                Nome = model.CatDescricao,
                Finalidade = MapCategoriaFinalidadeParaCategoriaFinalidadeDto(model.CatFinalidade)
            };
        }
        public Categoria MapCategoriaDtoCreateParaCategoria(CategoriaDTO.CategoriaDTOCreate model)
        {
            return new Categoria
            {
                CatDescricao = model.Nome,
                CatFinalidade = model.Finalidade
            };
        }

        public Categoria MapCategoriaDTOUpdateParaCategoria(CategoriaDTO.CategoriaDTOUpdate model)
        {
            return new Categoria
            {
                CatId = model.Codigo,
                CatDescricao = model.Nome,
                CatFinalidade = model.Finalidade
            };
        }
        private CategoriaDTO.CategoriaFinalidadeDTO MapCategoriaFinalidadeParaCategoriaFinalidadeDto(ECategoriaEnum Finalidade)
        {
            return new CategoriaDTO.CategoriaFinalidadeDTO
            {
                Codigo = (int)Finalidade,
                Descricao = Finalidade.ToString()
            };
        }
    }
}
