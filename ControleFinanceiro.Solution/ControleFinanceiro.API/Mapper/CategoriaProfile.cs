using AutoMapper;
using ControleFinanceiro.API.DTO;
using ControleFinanceiro.Domain.Models;

namespace ControleFinanceiro.API.Mapper
{
    public class CategoriaProfile : Profile //utilizando do autoMapper para mappear as entidades dto para a entidade de negocio e visse e versa
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, CategoriaDTO.CategoriaDTOView>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.CatId))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.CatDescricao))
                .ForMember(dest => dest.Finalidade, opt => opt.MapFrom(src => new CategoriaDTO.CategoriaFinalidadeDTO
                {
                    Codigo = (int)src.CatFinalidade,
                    Descricao = src.CatFinalidade.ToString()
                }))
                .ForMember(dest => dest.Transcacoes, opt => opt.MapFrom(src => src.Transacos));

            CreateMap<Categoria, CategoriaDTO.CategoriaDTOViewForTransacoes>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.CatId))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.CatDescricao))
                .ForMember(dest => dest.Finalidade, opt => opt.MapFrom(src => new CategoriaDTO.CategoriaFinalidadeDTO
                {
                    Codigo = (int)src.CatFinalidade,
                    Descricao = src.CatFinalidade.ToString()
                }));

            CreateMap<CategoriaDTO.CategoriaDTOCreate, Categoria>()
                .ForMember(dest => dest.CatDescricao, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.CatFinalidade, opt => opt.MapFrom(src => src.Finalidade));

            CreateMap<CategoriaDTO.CategoriaDTOUpdate, Categoria>()
                .ForMember(dest => dest.CatId, opt => opt.MapFrom(src => src.Codigo))
                .ForMember(dest => dest.CatDescricao, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.CatFinalidade, opt => opt.MapFrom(src => src.Finalidade));
        }
    }
}
