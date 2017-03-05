namespace SalesApp.Service
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using System.Threading.Tasks;
    using Model.Model;

    public class ServiceBase<T> : IYasService<T> where T : BaseModel, new()
    {
        protected readonly ServiceProvider<T> Provider;

        public ServiceBase()
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
            return access;
        }

        public async Task<List<T>> GetAsync()
        {
            var access = await Provider.RequestCollectionAsync();
            return access;
        }

        public T Put(T entity)
        {
            var access = Provider.PutTask(entity, entity.Id);
            return access.Result;
        }

        public T Post(T entity)
        {
            var access = Provider.PostTask(entity);
            return access.Result;
        }
    }
}
