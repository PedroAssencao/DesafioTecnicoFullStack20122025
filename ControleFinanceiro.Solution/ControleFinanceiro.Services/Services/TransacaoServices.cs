using ControleFinanceiro.Domain.Models;
using ControleFinanceiro.Infra.Interfaces;
using ControleFinanceiro.Services.Interface;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Services.Services
{
    // Service especializada em Transações, gerenciando a integração entre Pessoa e Categoria.
    public class TransacaoServices : BaseServices<Transaco>, ITransacoesServices
    {
        protected readonly IPessoaServices _pessoaServices;
        protected readonly ICategoriaService _categoriaService;

        public TransacaoServices(IBaseInterface<Transaco> repository, IPessoaServices pessoaServices, ICategoriaService categoriaService) : base(repository)
        {
            _pessoaServices = pessoaServices;
            _categoriaService = categoriaService;
        }

        // Sobrescrita para garantir que a transação possua os objetos relacionados antes de validar e persistir.
        public override async Task<Transaco> createAsync(Transaco model)
        {
            // Busca e anexa a Pessoa e Categoria completas para permitir validações de regra de negócio (ex: idade vs tipo)
            // e garantir que o retorno da API contenha as informações relacionadas.
            model.Pes = await _pessoaServices.getByIdAsync(model.PesId) ?? throw new Exception("Pessoa não encontrada para a transação");
            model.Cat = await _categoriaService.getByIdAsync(model.CatId) ?? throw new Exception("Categoria não encontrada para a transação");

            // Validação de domínio com os objetos Pessoa e Categoria já carregados no estado do modelo.
            string validate = model.validate();
            if (validate.Replace(",", "").Trim() != "")
            {
                throw new ValidationException(validate);
            }

            return await base.createAsync(model);
        }
    }
}