using SalesApp.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Repo.Contracts
{
    public interface IProductRepo
    {
        Product Get(int id);
        IList<Product> All();
    }
}
