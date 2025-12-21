using AutoMapper;
using ControleFinanceiro.API.DTO;
using ControleFinanceiro.Domain.Models;

namespace ControleFinanceiro.API.Mapper
{
    public class TransacoesProfile : Profile
    {
        public TransacoesProfile()
        {
            CreateMap<Transaco, TransacoesDTO.TranscacoesDTOView>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.TraId))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.TraDescricao))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.TraValor))
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => new TransacoesDTO.TipoTransacao
                {
                    Codigo = (int)src.TraTipo,
                    Descricao = src.TraTipo.ToString()
                }))
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Cat))
                .ForMember(dest => dest.Pessoa, opt => opt.MapFrom(src => src.Pes));

            CreateMap<Transaco, TransacoesDTO.TranscacoesDTOViewForPessoa>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.TraId))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.TraDescricao))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.TraValor))
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => new TransacoesDTO.TipoTransacao
                {
                    Codigo = (int)src.TraTipo,
                    Descricao = src.TraTipo.ToString()
                }))
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Cat));

            CreateMap<TransacoesDTO.transacoesDTOCreate, Transaco>()
                .ForMember(dest => dest.TraDescricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.TraValor, opt => opt.MapFrom(src => src.Valor))
                .ForMember(dest => dest.TraTipo, opt => opt.MapFrom(src => src.Tipo))
                .ForMember(dest => dest.CatId, opt => opt.MapFrom(src => src.CategoriaCodigo))
                .ForMember(dest => dest.PesId, opt => opt.MapFrom(src => src.PessoaCodigo));

            CreateMap<TransacoesDTO.transacoesDTOUpdate, Transaco>()
                .ForMember(dest => dest.TraId, opt => opt.MapFrom(src => src.Codigo))
                .ForMember(dest => dest.TraDescricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.TraValor, opt => opt.MapFrom(src => src.Valor))
                .ForMember(dest => dest.TraTipo, opt => opt.MapFrom(src => src.Tipo))
                .ForMember(dest => dest.CatId, opt => opt.MapFrom(src => src.CategoriaCodigo))
                .ForMember(dest => dest.PesId, opt => opt.MapFrom(src => src.PessoaCodigo));
        }
    }
}
