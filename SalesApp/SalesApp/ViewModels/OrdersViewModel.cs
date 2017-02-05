using System;
using System.Collections.Generic;
using System.Linq;
using SalesApp.Extensions;
using SalesApp.Model.Model;
using SalesApp.Service;

namespace SalesApp.ViewModels
{


    public class OrdersViewModel : CustomViewModelBase
    {
        private IList<OrderViewModel> orders = new List<OrderViewModel>();

        public IList<OrderViewModel> Orders
        {
            get
            {
                return this.orders;
            }
            set
            {
                this.orders = value;
                var list = new ObservableList<OrderViewModel>(this.orders);
                list.CollectionChanged += RaiseCollectionChanged;
                RaisePropertyChanged();
            }
        }

        public OrdersViewModel()
        {
            BindData();
        }

        private async void BindData()
        {
            var orderService = new OrderService();
            this.Orders = ConvertProductsToViewModels(await orderService.GetAsync());
        }

        private IList<OrderViewModel> ConvertProductsToViewModels(IList<Order> customers)
        {
            return customers.Select(product => new OrderViewModel(product)).ToList();
        }
    }
}