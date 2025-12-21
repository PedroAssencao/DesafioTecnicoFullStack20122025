using ControleFinanceiro.Infra.Interfaces;
using ControleFinanceiro.Services.Interface;

namespace ControleFinanceiro.Services.Services
{
    //classe generica criada para implementar os metodos basicos de CRUD com regras genericas
    public class BaseServices<T> : IBaseServices<T> where T : class
    {
        protected readonly IBaseInterface<T> _repository;

        public BaseServices(IBaseInterface<T> repository)
        {
            _repository = repository;
        }
        public virtual async Task<List<T>> getAllAsync() //implementação do metodo para resgatar todos os itens
        {
            try
            {
                return await _repository.getAllAsync(); //chamada do metodo do repositório
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um error ao tentar resgatar todos os itens, error: " + ex.Message);
            }
        }
        public virtual async Task<T?> getByIdAsync(int id) //implementação do metodo para resgatar um item pelo id
        {
            try
            {
                if (id <= 0) //verificação basica para saber se o id e invalido para resgatar o item
                {
                    throw new Exception("O id informado e invalido"); //lançar error se for invalido
                }

                return await _repository.getByIdAsync(id); //chamada do metodo do repositorio
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um error ao tentar resgatar o item, error: " + ex.Message);
            }
        }
        public virtual async Task<T> createAsync(T model) //implementação do metodo para criação de um item
        {
            try
            {
                if (model == null) //verificação basica para saber se o model enviado e nulo
                {
                    throw new Exception("O modelo para criação do item e obrigatorio");
                }

                return await _repository.createAsync(model); //chamada do metodo no repositorio
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um error ao tentar criar o item, error: " + ex.Message);
            }
        }
        public virtual async Task<bool> updateAsync(T model) //implementação do metodo para atualização de um item
        {
            try
            {
                if (model == null) //verificação basica para saber se o model enviado e nulo
                {
                    throw new Exception("O modelo para atualização do item e obrigatorio");
                }

                return await _repository.updateAsync(model); //chamada do metodo no repositorio
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um error ao tentar atualizar o item, error: " + ex.Message);
            }
        }

        public virtual async Task<bool> deleteAsync(int id) //implementação do metodo para deleção de um item
        {
            try
            {
                if (id <= 0) //verificação basica para saber se o id e invalido para deleção do item
                {
                    throw new Exception("O id informado e invalido");
                }

                return await _repository.deleteAsync(id); //chamada do metodo no repositorio
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um error ao tentar deletar o item, error: " + ex.Message);
            }
        }
    }
}
