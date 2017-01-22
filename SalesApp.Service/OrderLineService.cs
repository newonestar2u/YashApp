using System;
using System.Collections.Generic;
using SalesApp.Model.Model;
using SalesApp.Service.Contracts;
namespace SalesApp.Service
{
    class OrderLineService : IYasService<OrderLine>
    {
        public OrderLine GetById()
        {
            throw new NotImplementedException();
        }

        public List<OrderLine> Get()
        {
            var access = ServiceProvider.RequestCollection<OrderLine>("OrderLines");
            return access.Result;
        }

        public OrderLine Post(OrderLine entity)
        {
            throw new NotImplementedException();
        }
    }
}
