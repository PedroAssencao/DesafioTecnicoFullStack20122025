using ControleFinanceiro.Domain.Models;
using ControleFinanceiro.Infra.DAL;
using ControleFinanceiro.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Infra.Repository
{
    // Repositório específico para Pessoa, herdando a base de dados genérica.
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaInterface
    {
        public PessoaRepository(ControleFinanceiroContext context) : base(context)
        {
        }

        // Sobrescrita para buscar pessoas trazendo seus relacionamentos (Eager Loading).
        public override Task<List<Pessoa>> getAllAsync()
        {
            return _context.Pessoas
                .Include(x => x.Transacos)      // Inclui a lista de transações da pessoa
                .ThenInclude(x => x.Cat)       // Para cada transação, carrega a categoria correspondente
                .ToListAsync();
        }
    }
}