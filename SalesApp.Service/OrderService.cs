using System;
using System.Collections.Generic;
using SalesApp.Model.Model;
using SalesApp.Service.Contracts;

namespace SalesApp.Service
{

    public class OrderService : IYasService<Order>
    {
        public Order GetById()
        {
            throw new NotImplementedException();
        }

        public List<Order> Get()
        {
            var access = ServiceProvider.RequestCollection<Order>("Orders");
            return access.Result;
        }

        public Order Post(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}