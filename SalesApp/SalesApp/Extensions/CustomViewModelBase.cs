namespace SalesApp.Extensions
{
    using System;
    using System.Linq;
    using Model.Model;
    using GalaSoft.MvvmLight;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Collections.Generic;
    using Service;
    using Service.Contracts;

    public class CustomViewModelBase : ViewModelBase
    {
        public void RaiseCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            RaisePropertyChanged();
        }

        public void RaisePropertyModelChanged(object sender, PropertyChangedEventArgs args)
        {
            RaisePropertyChanged();
        }
    }

    public class CustomViewModelBase<T> : CustomViewModelBase
        where T : BaseModel, new()
    {
        protected IYasService<T> Service;

        public CustomViewModelBase()
        {
            Service = new ServiceBase<T>();
        }

        protected IList<TU> ConverToModelView<TU>(List<T> items) where TU : CustomViewModelBase<T>
        {
            return items.Select(i => (TU)Activator.CreateInstance(typeof(TU), i)).ToList();
        }
    }
}
