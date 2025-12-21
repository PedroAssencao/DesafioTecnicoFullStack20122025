using ControleFinanceiro.Infra.DAL;
using ControleFinanceiro.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Infra.Repository
{
    //classe generica para operações básicas de CRUD
    //pode ser usada para criação de classes derivadas com regras mais especificas
    //pode ser usada para casos que não necessitam de regras especificas, apenas a operação padrão de CRUD
    public class BaseRepository<T> : IBaseInterface<T> where T : class
    {
        protected readonly ControleFinanceiroContext _context;

        public BaseRepository(ControleFinanceiroContext context)
        {
            _context = context;
        }

        public async Task<List<T>> getAllAsync() => await _context.Set<T>().ToListAsync(); //metodo para listagem dos itens no banco
        public async Task<T?> getByIdAsync(int id) => await _context.Set<T>().FindAsync(id); //metodo para busca de um item expecifico pelo id
        public async Task<T> createAsync(T model) //metodo para criação de um item
        {
            var result = await _context.Set<T>().AddAsync(model);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<bool> updateAsync(T model) //metodo para atualização de um item
        {
            try
            {
                _context.Set<T>().Update(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> deleteAsync(int id) //metodo para deleção de um item
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null) return false;
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
