using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.ViewModels
{
    using GalaSoft.MvvmLight.Command;

    using SalesApp.Extensions;
    using SalesApp.Model.Model;
    using SalesApp.Pages;
    using SalesApp.Service;

    using Xamarin.Forms;

    public class OrdersViewModel : CustomViewModelBase
    {
        private IList<OrderViewModel> orders;

        public IList<OrderViewModel> Orders
        {
            get
            {
                return this.orders;
            }
            set
            {
                this.orders = value;
                ObservableList<OrderViewModel> list = new ObservableList<OrderViewModel>(this.orders);
                list.CollectionChanged += RaiseCollectionChanged;
                RaisePropertyChanged();
            }
        }

        public OrdersViewModel()
        {
            var productService = new OrderService();
            this.Orders = ConvertProductsToViewModels(productService.Get());
        }

        private IList<OrderViewModel> ConvertProductsToViewModels(IList<Order> customers)
        {
            return customers.Select(product => new OrderViewModel(product)).ToList();
        }
    }
}