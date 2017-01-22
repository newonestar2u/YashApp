using SalesApp.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesApp.Model.Model;
using SalesApp.Repo.Contracts;
using SalesApp.Repo;

namespace SalesApp.Service
{
    public class ProductService: IYasService<Product>
    {
        public Product GetById()
        {
            throw new NotImplementedException();
        }

        public List<Product> Get()
        {
            var access = ServiceProvider.RequestCollection<Product>("products");
            return access.Result;
        }

        public Product Post(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
