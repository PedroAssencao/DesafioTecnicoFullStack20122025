using ControleFinanceiro.API.DTO;
using ControleFinanceiro.Domain.Models;

namespace ControleFinanceiro.API.Mapper.PessoaEntity
{
    public interface IPessoaMapper
    {
        Pessoa MapPessoaDtoParaPessoa(PessoaDTO model);
        List<PessoaDTO> MapListPessoaParaListPessoaDTO(List<Pessoa> listModel);
    }
}
