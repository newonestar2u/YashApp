using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesApp.Service.Contracts
{
    public interface IYasService
    {

    }

    public interface IYasService<T> : IYasService
    {
        T GetById();

        List<T> Get();

        Task<List<T>> GetAsync();

        T Put(T entity);
        T Post(T entity);
    }
}
