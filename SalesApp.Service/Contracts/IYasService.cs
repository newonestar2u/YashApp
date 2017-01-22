using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Service.Contracts
{
    public interface IYasService<T>
    {
        T GetById();

        List<T> Get();

        T Post(T entity);
    }
}
