using System.Collections.Generic;
using System.Linq;
using SalesApp.Extensions;
using SalesApp.Model.Model;
using SalesApp.Service;
using GalaSoft.MvvmLight.Command;
using SalesApp.Pages;
using Xamarin.Forms;

namespace SalesApp.ViewModels
{
    public class CustomersViewModel : CustomViewModelBase
    {
        private IList<CustomerViewModel> customers;

        public IList<CustomerViewModel> Customers
        {
            get { return this.customers; }
            set
            {
                this.customers = value;
                var list = new ObservableList<CustomerViewModel>(this.customers);
                list.CollectionChanged += RaiseCollectionChanged;
                RaisePropertyChanged();
            }
        }

        public CustomersViewModel()
        {
            this.customers = new List<CustomerViewModel>();
            BindData();
            BtnAddNewCustomerClickCommand = new RelayCommand(this.btnAddNewCustomer);
        }

        private async void BindData()
        {
            var productService = new CustomerService();
            var result = await productService.GetAsync();
            this.Customers = ConvertProductsToViewModels(result);
        }

        private IList<CustomerViewModel> ConvertProductsToViewModels(IEnumerable<Customer> customerList)
        {
            return customerList.Select(c => new CustomerViewModel(c)).ToList();
        }

        public RelayCommand BtnAddNewCustomerClickCommand { get; private set; }
        public RelayCommand BtnRefreshClickCommand { get; private set; }

        private async void btnAddNewCustomer()
        {
            var newCustomer = new CustomerAddPage();
            await Application.Current.MainPage.Navigation.PushAsync(newCustomer);
            newCustomer.SaveComplete += NewCustomer_SaveComplete;
            var pdvm = (CustomerAddModel)newCustomer.BindingContext;
            //  pdvm.Customer = this.Customer;
            newCustomer.BindingContext = pdvm;
        }

        private async void NewCustomer_SaveComplete(object sender, System.EventArgs e)
        {
            var customerService = new CustomerService();
            this.Customers = ConvertProductsToViewModels(await customerService.GetAsync());
        }

    }
}
