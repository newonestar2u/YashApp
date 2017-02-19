namespace SalesApp.ViewModels
{
    using System.Collections.Generic;
    using Extensions;
    using Model.Model;
    using Service;

    public class OrdersViewModel : CustomViewModelBase<Order>
    {
        private IList<OrderViewModel> orders = new List<OrderViewModel>();

        public IList<OrderViewModel> Orders
        {
            get
            {
                return orders;
            }
            set
            {
                orders = value;
                var list = new ObservableList<OrderViewModel>(orders);
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
            Orders = this.ConverToModelView<OrderViewModel>(await orderService.GetAsync());
        }
    }
}