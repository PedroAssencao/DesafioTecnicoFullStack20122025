using ControleFinanceiro.Domain.Models;
using ControleFinanceiro.Infra.Interfaces;
using ControleFinanceiro.Services.Interface;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Services.Services
{
    public class PessoaServices : BaseServices<Pessoa>, IPessoaServices
    {
        protected new readonly IPessoaInterface _repository;
        public PessoaServices(IBaseInterface<Pessoa> repository, IPessoaInterface repositoryPessoa) : base(repository)
        {
            _repository = repositoryPessoa;
        }

        public override async Task<Pessoa> createAsync(Pessoa model)
        {
            string validate = model.validate();
            if (validate.Replace(",", "").Trim() != "")
            {
                throw new ValidationException(validate);
            }

            return await base.createAsync(model);
        }
        public override async Task<List<Pessoa>> getAllAsync() => await _repository.getAllAsync();
        public override async Task<bool> updateAsync(Pessoa model)
        {
            string validate = model.validate(true);
            if (validate.Replace(",", "").Trim() != "")
            {
                throw new ValidationException(validate);
            }

            return await base.updateAsync(model);
        }
    }
}
