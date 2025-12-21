using ControleFinanceiro.Domain.Models;
using ControleFinanceiro.Infra.Interfaces;
using ControleFinanceiro.Services.Interface;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Services.Services
{
    public class PessoaServices : BaseServices<Pessoa>, IPessoaServices
    {
        public PessoaServices(IBaseInterface<Pessoa> repository) : base(repository)
        {
        }

        public override async Task<Pessoa> createAsync(Pessoa model)
        {
            string validate = model.validate();
            if (!validate.IsNullOrEmpty())
            {
                throw new ValidationException(validate);
            }

            return await _repository.createAsync(model);
        }
    }
}
