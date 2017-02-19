namespace SalesApp.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    using Model.Model;
    using Service;
    using Xamarin.Forms;

    public class CartModel : CustomViewModelBase<Order>
    {
        public event EventHandler SaveComplete;

        private IList<OrderViewModel> ordersViewModels;

        public IList<OrderViewModel> OrdersViewModels
        {
            get
            {
                return ordersViewModels;
            }
            set
            {
                ordersViewModels = value;
                var list = new ObservableList<OrderViewModel>(ordersViewModels.ToList());
                list.CollectionChanged += RaiseCollectionChanged;
                RaisePropertyChanged();
            }
        }

        public CartModel()
        {
            OrdersViewModels = ConverToModelView<OrderViewModel>(App.Orders);
        }

        public void SaveChanges()
        {
            foreach (var order in this.ordersViewModels)
            {
                var orderService = new OrderService();
                order.Order.SalesBy = "megha";
                var result = orderService.Post(order.Order);
                if (result != default(Order))
                {
                    App.Orders.Clear();
                    SaveComplete?.Invoke(this, null);
                    Application.Current.MainPage.SendBackButtonPressed();
                }
            }
        }
    }
}