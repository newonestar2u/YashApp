using SalesApp.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Service.Contracts
{
    public interface IProductService
    {
        Product Get(int id);
        IList<Product> All();
    }
}
