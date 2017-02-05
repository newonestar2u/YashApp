using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesApp.Service.Contracts
{

    public interface IYasService<T>
    {
        T GetById();

        List<T> Get();

        Task<List<T>> GetAsync();

        T Post(T entity);
    }
}
