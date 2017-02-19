namespace SalesApp.ViewModels
{
    using System.ComponentModel;
    using Extensions;
    using Model.Model;

    class CustomerDetailViewModel : CustomViewModelBase
    {
        private Customer customer;

        public Customer Customer
        {
            get { return customer; }
            set
            {
                customer = value;
                customer.PropertyChanged += CustomerOnPropertyChanged;
                RaisePropertyChanged();
            }
        }

        private void CustomerOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
        }

        public CustomerDetailViewModel(Customer customer)
        {
            Customer = customer;
            InstantiateCommands();
        }

        public CustomerDetailViewModel()
        {
            InstantiateCommands();
        }

        private void InstantiateCommands()
        {
        }

    }
}
