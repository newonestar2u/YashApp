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

    public class OrderLineViewModel : CustomViewModelBase
    {
        private OrderLine orderLine;

        public OrderLine OrderLine
        {
            get { return this.orderLine; }
            set
            {
                this.orderLine = value;
                RaisePropertyChanged();
            }
        }

        public OrderLineViewModel(OrderLine orderLine) : this()
        {
            this.OrderLine = orderLine;
        }

        public OrderLineViewModel()
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
