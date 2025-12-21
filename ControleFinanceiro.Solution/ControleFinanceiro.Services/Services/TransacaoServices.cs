using ControleFinanceiro.Domain.Models;
using ControleFinanceiro.Infra.Interfaces;
using ControleFinanceiro.Services.Interface;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Services.Services
{
    public class TransacaoServices : BaseServices<Transaco>, ITransacoesServices
    {
        protected readonly IPessoaServices _pessoaServices;
        protected readonly ICategoriaService _categoriaService;
        public TransacaoServices(IBaseInterface<Transaco> repository, IPessoaServices pessoaServices, ICategoriaService categoriaService) : base(repository)
        {
            _pessoaServices = pessoaServices;
            _categoriaService = categoriaService;
        }

        public override async Task<Transaco> createAsync(Transaco model)
        {
            model.Pes = await _pessoaServices.getByIdAsync(model.PesId) ?? throw new Exception("Pessoa não encontrada para a transação"); //Necessario para validação, e para retorno da entidade no json
            model.Cat = await _categoriaService.getByIdAsync(model.CatId) ?? throw new Exception("Categoria não encontrada para a transação"); //Necessario para validação, e para retorno da entidade no json

            string validate = model.validate();
            if (validate.Replace(",", "").Trim() != "")
            {
                throw new ValidationException(validate);
            }

            return await base.createAsync(model);
        }
    }
}
