using System.Collections.Generic;
using System.Linq;
using SalesApp.Extensions;
using SalesApp.Model.Model;
using SalesApp.Service;

namespace SalesApp.ViewModels
{
    using GalaSoft.MvvmLight.Command;

    using SalesApp.Pages;

    using Xamarin.Forms;

    public class CustomersViewModel : CustomViewModelBase
    {
        private IList<CustomerViewModel> customers;

        public IList<CustomerViewModel> Customers
        {
            get { return this.customers; }
            set
            {
                this.customers = value;
                ObservableList<CustomerViewModel> list = new ObservableList<CustomerViewModel>(this.customers);
                list.CollectionChanged += RaiseCollectionChanged;
                RaisePropertyChanged();
            }
        }

        public CustomersViewModel()
        {
            var productService = new CustomerService();
            this.Customers = ConvertProductsToViewModels(productService.Get());
            BtnAddNewCustomerClickCommand = new RelayCommand(this.btnAddNewCustomer);
            BtnRefreshClickCommand = new RelayCommand(this.btnRefresh);
        }

        private IList<CustomerViewModel> ConvertProductsToViewModels(IList<Customer> customers)
        {
            return customers.Select(product => new CustomerViewModel(product)).ToList();
        }

        public RelayCommand BtnAddNewCustomerClickCommand { get; private set; }
        public RelayCommand BtnRefreshClickCommand { get; private set; }

        private async void btnAddNewCustomer()
        {
            ContentPage detail = new CustomerAddPage();
            await ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(detail);
            CustomerAddModel pdvm = (CustomerAddModel)detail.BindingContext;
            //  pdvm.Customer = this.Customer;
            detail.BindingContext = pdvm;
        }
        private async void btnRefresh()
        {
            Customers.Clear();
            var productService = new CustomerService();
            this.Customers = ConvertProductsToViewModels(productService.Get());
        }
    }
}
