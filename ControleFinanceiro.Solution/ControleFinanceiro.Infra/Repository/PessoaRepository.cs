using ControleFinanceiro.Domain.Models;
using ControleFinanceiro.Infra.DAL;
using ControleFinanceiro.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Infra.Repository
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaInterface
    {
        public PessoaRepository(ControleFinanceiroContext context) : base(context)
        {
        }
        public override Task<List<Pessoa>> getAllAsync()
        {
            return _context.Pessoas
                .Include(x => x.Transacos)
                .ThenInclude(x => x.Cat)
                .ToListAsync();
        }
    }
}
