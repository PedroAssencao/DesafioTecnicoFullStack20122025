using ControleFinanceiro.Domain.Models;
using ControleFinanceiro.Infra.Interfaces;
using ControleFinanceiro.Services.Interface;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Services.Services
{
    public class CategoriaServices : BaseServices<Categoria>, ICategoriaService
    {
        protected new readonly ICategoriaInterface _repository;
        public CategoriaServices(IBaseInterface<Categoria> repository, ICategoriaInterface repositoryCategoria) : base(repository)
        {
            _repository = repositoryCategoria;
        }

        public override async Task<List<Categoria>> getAllAsync() => await _repository.getAllAsync();
        public override Task<Categoria> createAsync(Categoria model)
        {
            string validate = model.validate();
            if (validate.Replace(",", "").Trim() != "")
            {
                throw new ValidationException(validate);
            }

            return base.createAsync(model);
        }
    }
}
