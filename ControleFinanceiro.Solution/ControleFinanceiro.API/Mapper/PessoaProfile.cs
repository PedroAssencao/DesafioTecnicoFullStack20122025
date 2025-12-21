using AutoMapper;
using ControleFinanceiro.API.DTO;
using ControleFinanceiro.Domain.Models;

namespace ControleFinanceiro.API.Mapper
{
    public class PessoaProfile : Profile //utilizando do autoMapper para mappear as entidades dto para a entidade de negocio e visse e versa
    {
        public PessoaProfile()
        {
            CreateMap<Pessoa, PessoaDTO.PessoaDTOView>()
                    .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.PesId))
                    .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.PesNome))
                    .ForMember(dest => dest.Idade, opt => opt.MapFrom(src => src.PesIdade))
                    .ForMember(dest => dest.Transacoes, opt => opt.MapFrom(src => src.Transacos));

            CreateMap<Pessoa, PessoaDTO.PessoaDTOViewForTransacoes>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.PesId))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.PesNome))
                .ForMember(dest => dest.Idade, opt => opt.MapFrom(src => src.PesIdade));

            CreateMap<PessoaDTO.PessoaDTOCreate, Pessoa>()
                .ForMember(dest => dest.PesNome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.PesIdade, opt => opt.MapFrom(src => src.Idade));

            CreateMap<PessoaDTO.PessoaDTOUpdate, Pessoa>()
                .ForMember(dest => dest.PesId, opt => opt.MapFrom(src => src.Codigo))
                .ForMember(dest => dest.PesNome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.PesIdade, opt => opt.MapFrom(src => src.Idade));
        }
    }
}
