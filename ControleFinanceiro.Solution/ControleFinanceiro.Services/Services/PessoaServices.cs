using ControleFinanceiro.Domain.Models;
using ControleFinanceiro.Infra.Interfaces;
using ControleFinanceiro.Services.Interface;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Services.Services
{
    //Service responsável pela lógica de negócio da entidade Pessoa.
    //Herda de BaseServices para reutilizar operações genéricas de CRUD.
    public class PessoaServices : BaseServices<Pessoa>, IPessoaServices
    {
        //Repositório especializado para Pessoa, contem metodos e lógicas específicas.
        protected new readonly IPessoaInterface _repository;

        public PessoaServices(IBaseInterface<Pessoa> repository, IPessoaInterface repositoryPessoa) : base(repository)
        {
            _repository = repositoryPessoa;
        }

        //Sobrescrita do método de criação para incluir a validação de domínio.
        public override async Task<Pessoa> createAsync(Pessoa model)
        {
            //Executa a validação lógica definida na classe de domínio
            string validate = model.validate();

            //Verifica se a string de retorno contém erros (removendo separadores e espaços)
            if (validate.Replace(",", "").Trim() != "")
            {
                throw new ValidationException(validate);
            }

            return await base.createAsync(model);
        }

        //Busca todas as pessoas utilizando o repositório especializado.
        public override async Task<List<Pessoa>> getAllAsync() => await _repository.getAllAsync();

        //Sobrescrita do método de atualização com lógica de validação específica para Update.
        public override async Task<bool> updateAsync(Pessoa model)
        {
            string validate = model.validate(true); //metodo de validação da entidade

            if (validate != "")
            {
                throw new ValidationException(validate);
            }

            return await base.updateAsync(model);
        }
    }
}