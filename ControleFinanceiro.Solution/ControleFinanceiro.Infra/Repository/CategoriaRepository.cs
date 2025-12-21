using ControleFinanceiro.Domain.Models;
using ControleFinanceiro.Infra.DAL;
using ControleFinanceiro.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Infra.Repository
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaInterface
    {
        public CategoriaRepository(ControleFinanceiroContext context) : base(context)
        {
        }

        public override async Task<List<Categoria>> getAllAsync() => await _context.Categorias.Include(x => x.Transacos).ThenInclude(x => x.Pes).ToListAsync();
    }
}
