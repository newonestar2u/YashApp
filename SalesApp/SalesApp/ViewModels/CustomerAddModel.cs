namespace SalesApp.ViewModels
{
    using System;
    using GalaSoft.MvvmLight.Command;
    using Extensions;
    using Model.Model;
    using Service;
    using Xamarin.Forms;

    public class CustomerAddModel : CustomViewModelBase
    {
        private Customer customer;

        public Customer Customer
        {
            get { return this.customer; }
            set
            {
                this.customer = value;
                RaisePropertyChanged();
            }
        }

        public CustomerAddModel(Customer customer)
        {
            this.Customer = customer;
            InstantiateCommands();
        }

        public CustomerAddModel()
        {
            this.customer = new Customer();
            InstantiateCommands();
        }

        private void InstantiateCommands()
        {
            this.BtnSaveCustomer = new RelayCommand(this.BtnSaveClick);
        }

        public RelayCommand BtnSaveCustomer { get; private set; }

        private void BtnSaveClick()
        {
            var test = this.customer;
            var service = new CustomerService();
            this.Customer.CreatedBy = "ABC";
            this.Customer.CreatedOn = DateTime.Now;
            this.Customer.UpdatedOn = DateTime.Now;
            var result = service.Post(this.customer);
            if (result == default(Customer))
            {

            }
            else
            {
                Application.Current.MainPage.SendBackButtonPressed();
                this.Customer = result;
            }
            //Page detail = new CustomerPage();
            //await ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(detail);
            //CustomersViewModel pdvm = (CustomersViewModel)detail.BindingContext;
            //detail.BindingContext = pdvm;

            //Editor detail = new CustomerAddPage();
            //await ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(detail);
            //CustomerDetailViewModel pdvm = (CustomerDetailViewModel)detail.BindingContext;
            //pdvm.Customer = this.Customer;
            //detail.BindingContext = pdvm;
        }
    }
}