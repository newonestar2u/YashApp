using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SalesApp.Service
{
    using SalesApp.Model.Model;
    using SalesApp.Service.Contracts;

    public class CustomerService : IYasService<Customer>
    {
        public Customer GetById()
        {
            throw new NotImplementedException();
        }

        public List<Customer> Get()
        {
            var access = ServiceProvider.RequestCollection<Customer>("customers");
            return access.Result;
        }

        public Customer Post(Customer entity)
        {
            var access = ServiceProvider.PosTask("customers", entity);
            return access.Result;
        }
    }
}
