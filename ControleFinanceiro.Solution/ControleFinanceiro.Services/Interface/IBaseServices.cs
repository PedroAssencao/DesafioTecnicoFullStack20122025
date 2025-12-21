namespace ControleFinanceiro.Services.Interface
{
    //metodos genericos para serem implementados em services
    public interface IBaseServices<T> where T : class
    {
        Task<List<T>> getAllAsync(); //resgatar todos os itens
        Task<T?> getByIdAsync(int id); //resgatar item por id
        Task<T> createAsync(T model); //criar item
        Task<bool> updateAsync(T model); //atualziar item
        Task<bool> deleteAsync(int id); //deletar item
    }
}
