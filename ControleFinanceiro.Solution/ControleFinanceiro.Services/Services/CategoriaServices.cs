using ControleFinanceiro.Domain.Models;
using ControleFinanceiro.Infra.Interfaces;
using ControleFinanceiro.Services.Interface;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Services.Services
{
    // Service responsável pela lógica de negócio da entidade Categoria.
    // Segue o padrão de herança de BaseServices para operações padronizadas.
    public class CategoriaServices : BaseServices<Categoria>, ICategoriaService
    {
        // Repositório especializado para Categoria, permitindo consultas customizadas.
        protected new readonly ICategoriaInterface _repository;

        public CategoriaServices(IBaseInterface<Categoria> repository, ICategoriaInterface repositoryCategoria) : base(repository)
        {
            _repository = repositoryCategoria;
        }

        // Obtém a lista completa de categorias através do repositório especializado.
        public override async Task<List<Categoria>> getAllAsync() => await _repository.getAllAsync();

        // Sobrescrita do método de criação para garantir que a categoria atenda aos requisitos de domínio.
        public override Task<Categoria> createAsync(Categoria model)
        {
            // Aciona o método de autovalidação da entidade Categoria.
            string validate = model.validate();

            // Interrompe o fluxo caso existam inconsistências nos dados informados.
            if (validate != "")
            {
                throw new ValidationException(validate);
            }

            return base.createAsync(model);
        }
    }
}