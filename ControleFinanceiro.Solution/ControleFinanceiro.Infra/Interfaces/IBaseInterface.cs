namespace ControleFinanceiro.Infra.Interfaces
{
    //Define um interface generica, para implementação da classe generica de CRUD
    public interface IBaseInterface<T> where T : class
    {
        Task<List<T>> getAllAsync();
        Task<T?> getByIdAsync(int id);
        Task<T> createAsync(T model);
        Task<bool> updateAsync(T model);
        Task<bool> deleteAsync(int id);
    }
}
