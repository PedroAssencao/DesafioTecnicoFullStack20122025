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

        public async Task<List<T>> getAllAsync() //metodo para listagem dos itens no banco
        {
            IQueryable<T> iQueryAble = _context.Set<T>(); //Definir a entidade para começar a consulta

            var navigationProperties = _context.Model.FindEntityType(typeof(T))?
                .GetNavigations()
                .Select(e => e.Name); //Resgatar todas as propriedades de navegação da entidade

            foreach (var item in navigationProperties!) //Incluir todas as propriedades de navegação na consulta. Ex: pessoa -> transações
            {
                iQueryAble = iQueryAble.Include(item);
            }

            return await iQueryAble.ToListAsync(); //Executar a consulta e retornar a lista de itens
        }
        public async Task<T?> getByIdAsync(int id) //metodo para busca de um item expecifico pelo id
        {
            IQueryable<T> query = _context.Set<T>(); //Definir a entidade para começar a consulta

            var navigationProperties = _context.Model.FindEntityType(typeof(T))!
                .GetNavigations()
                .Select(n => n.Name); //Resgatar todas as propriedades de navegação da entidade

            foreach (var property in navigationProperties) //Incluir todas as propriedades de navegação na consulta. Ex: pessoa -> transações
            {
                query = query.Include(property);
            }

            //Como e um metodo generico, e não temos como saber a exata entidade que e o id do objeto, fazemos essa busca para achar qual e o atributo que representa a chave primaria
            var primaryKeyName = _context?.Model?.FindEntityType(typeof(T))
                ?.FindPrimaryKey()
                ?.Properties
                ?.Select(p => p.Name)
                ?.FirstOrDefault();

            if (primaryKeyName == null) //se não achar a chave primaria, lançar um erro
            {
                throw new InvalidOperationException($"A entidade {typeof(T).Name} não possui uma chave primária definida.");
            }

            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, primaryKeyName) == id); //Executar a consulta e retornar o item com o id correspondente
        }
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
