using ControleFinanceiro.Domain.Models;
using ControleFinanceiro.Infra.DAL;
using ControleFinanceiro.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Infra.Repository
{
    // Repositório específico para Categoria.
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaInterface
    {
        public CategoriaRepository(ControleFinanceiroContext context) : base(context)
        {
        }

        // Sobrescrita para listar categorias incluindo a árvore de relacionamentos.
        public override async Task<List<Categoria>> getAllAsync() =>
            await _context.Categorias
                .Include(x => x.Transacos)    // Carrega todas as transações vinculadas à categoria
                .ThenInclude(x => x.Pes)      // Carrega os dados da pessoa dona de cada transação
                .ToListAsync();
    }
}