using ControleFinanceiro.API.DTO;
using ControleFinanceiro.Domain.Models;

namespace ControleFinanceiro.API.Mapper.PessoaEntity
{
    public class PessoaMapper : IPessoaMapper
    {
        public Pessoa MapPessoaDtoViewParaPessoa(PessoaDTO.PessoaDTOView model)
        {
            return new Pessoa
            {
                PesId = model.Codigo,
                PesNome = model.Nome,
                PesIdade = model.Idade
            };
        }

        public List<PessoaDTO.PessoaDTOView> MapListPessoaParaListPessoaDTO(List<Pessoa> listModel)
        {
            List<PessoaDTO.PessoaDTOView> list = new List<PessoaDTO.PessoaDTOView>();

            foreach (var item in listModel)
            {
                list.Add(new PessoaDTO.PessoaDTOView
                {
                    Codigo = item.PesId,
                    Nome = item.PesNome,
                    Idade = item.PesIdade
                });
            }

            return list;
        }

        public Pessoa MapPessoaDtoCreateParaPessoa(PessoaDTO.PessoaDTOCreate model)
        {
            return new Pessoa
            {
                PesNome = model.Nome,
                PesIdade = model.Idade
            };
        }

        public Pessoa MapPessoaDtoUpdateParaPessoa(PessoaDTO.PessoaDTOUpdate model)
        {
            return new Pessoa
            {
                PesId = model.Codigo,
                PesNome = model.Nome,
                PesIdade = model.Idade
            };
        }
    }
}
