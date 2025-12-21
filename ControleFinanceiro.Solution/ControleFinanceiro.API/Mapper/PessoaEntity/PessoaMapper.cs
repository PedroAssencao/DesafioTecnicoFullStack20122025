using ControleFinanceiro.API.DTO;
using ControleFinanceiro.Domain.Models;

namespace ControleFinanceiro.API.Mapper.PessoaEntity
{
    public class PessoaMapper : IPessoaMapper
    {
        public Pessoa MapPessoaDtoParaPessoa(PessoaDTO model)
        {
            return new Pessoa
            {
                PesId = model.Codigo,
                PesNome = model.Nome,
                PesIdade = model.Idade
            };
        }

        public List<PessoaDTO> MapListPessoaParaListPessoaDTO(List<Pessoa> listModel)
        {
            List<PessoaDTO> list = new List<PessoaDTO>();

            foreach (var item in listModel)
            {
                list.Add(new PessoaDTO
                {
                    Codigo = item.PesId,
                    Nome = item.PesNome,
                    Idade = item.PesIdade
                });
            }

            return list;
        }
    }
}
