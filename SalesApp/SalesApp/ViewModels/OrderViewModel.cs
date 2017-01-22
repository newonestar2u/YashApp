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

    using Xamarin.Forms;

    public class OrderViewModel : CustomViewModelBase
    {
        private Order order;

        public Order Order
        {
            get { return this.order; }
            set
            {
                this.order = value;
                RaisePropertyChanged();
            }
        }

        public OrderViewModel(Order order) : this()
        {
            this.Order = order;
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
