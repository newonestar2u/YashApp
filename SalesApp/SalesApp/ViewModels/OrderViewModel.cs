namespace SalesApp.ViewModels
{
    using System.Collections.Generic;
    using GalaSoft.MvvmLight.Command;
    using Extensions;
    using Model.Model;

    public class OrderViewModel : CustomViewModelBase<Order>
    {
        private Order order;

        public Order Order
        {
            get { return order; }
            set
            {
                order = value;
                RaisePropertyChanged();
            }
        }

        private List<OrderLineViewModel> orderLinesViewModel;
        public List<OrderLineViewModel> OrderLinesViewModel
        {
            get { return orderLinesViewModel; }
            set
            {
                orderLinesViewModel = value;
                RaisePropertyChanged();
            }
        }

        public OrderViewModel(Order order) : this()
        {
            Order = order;
            OrderLinesViewModel= new List<OrderLineViewModel>();
            foreach (OrderLine ol in order.OrderLines)
            {
                var newItem = new OrderLineViewModel(ol);
                OrderLinesViewModel.Add(newItem);
            }
        }

        public OrderViewModel()
        {
            InstantiateCommands();
        }

        private void InstantiateCommands()
        {
            BtnDetailClickCommand = new RelayCommand(btnDetailClick);
        }

        public RelayCommand BtnDetailClickCommand { get; private set; }

        private async void btnDetailClick()
        {
            //ContentPage detail = new CustomerDetail();
            //await ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(detail);
            //CustomerDetailViewModel pdvm = (CustomerDetailViewModel)detail.BindingContext;
            //pdvm.Customer = this.Customer;
            //detail.BindingContext = pdvm;
        }
    }
}
