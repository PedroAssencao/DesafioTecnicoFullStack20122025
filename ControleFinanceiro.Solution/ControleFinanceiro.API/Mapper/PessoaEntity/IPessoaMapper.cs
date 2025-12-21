using ControleFinanceiro.API.DTO;
using ControleFinanceiro.Domain.Models;

namespace ControleFinanceiro.API.Mapper.PessoaEntity
{
    public interface IPessoaMapper
    {
        Pessoa MapPessoaDtoViewParaPessoa(PessoaDTO.PessoaDTOView model);
        Pessoa MapPessoaDtoCreateParaPessoa(PessoaDTO.PessoaDTOCreate model);
        Pessoa MapPessoaDtoUpdateParaPessoa(PessoaDTO.PessoaDTOUpdate model);
        List<PessoaDTO.PessoaDTOView> MapListPessoaParaListPessoaDTO(List<Pessoa> listModel);
    }
}
