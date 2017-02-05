using System.Collections.Generic;

namespace SalesApp.Service.Contracts
{
    public interface IYasService<T>
    {
        T GetById();

        List<T> Get();

        T Post(T entity);
    }
}
