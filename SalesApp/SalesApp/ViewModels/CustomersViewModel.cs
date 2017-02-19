namespace SalesApp.ViewModels
{
    using System.Collections.Generic;
    using Extensions;
    using Model.Model;
    using Service;
    using GalaSoft.MvvmLight.Command;
    using Pages;
    using Xamarin.Forms;

    public class CustomersViewModel : CustomViewModelBase<Customer>
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
            BtnAddNewCustomerClickCommand = new RelayCommand(this.BtnAddNewCustomer);
        }

        private async void BindData()
        {
            var productService = new CustomerService();
            var result = await productService.GetAsync();
            Customers = base.ConverToModelView<CustomerViewModel>(result);
        }

        public RelayCommand BtnAddNewCustomerClickCommand { get; private set; }

        private async void BtnAddNewCustomer()
        {
            var newCustomer = new CustomerAddPage();
            await Application.Current.MainPage.Navigation.PushAsync(newCustomer);
            newCustomer.SaveComplete += NewCustomerSaveComplete;
            var pdvm = (CustomerAddModel)newCustomer.BindingContext;
            //  pdvm.Customer = this.Customer;
            newCustomer.BindingContext = pdvm;
        }

        private async void NewCustomerSaveComplete(object sender, System.EventArgs e)
        {
            var customerService = new CustomerService();
            Customers = base.ConverToModelView<CustomerViewModel>(await customerService.GetAsync());
        }
    }
}
