using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.ViewModels
{
    using SalesApp.CustomViews;
    using SalesApp.Extensions;
    using SalesApp.Model.Model;
    using SalesApp.Service;

    public class CartModel : CustomViewModelBase
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

        public CartModel()
        {
            this.Orders = ConvertProductsToViewModels(App.Orders);
        }

        private IList<OrderViewModel> ConvertProductsToViewModels(IList<Order> customers)
        {
            return customers.Select(product => new OrderViewModel(product)).ToList();
        }
    }
}