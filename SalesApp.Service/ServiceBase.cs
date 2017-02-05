using System;
using System.Collections.Generic;
using SalesApp.Service.Contracts;

namespace SalesApp.Service
{
    public abstract class ServiceBase<T> : IYasService<T> where T : new()
    {
        protected readonly ServiceProvider<T> Provider;

        protected ServiceBase()
        {
            Provider = new ServiceProvider<T>();
        }

        public T GetById()
        {
            throw new NotImplementedException();
        }

        public List<T> Get()
        {
            var access = Provider.RequestCollection();
            return access.Result;
        }

        public T Post(T entity)
        {
            var access = Provider.PostTask(entity);
            return access.Result;
        }
    }
}
