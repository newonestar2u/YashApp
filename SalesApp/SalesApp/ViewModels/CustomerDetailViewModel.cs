using System.ComponentModel;
using SalesApp.Extensions;
using SalesApp.Model.Model;
namespace SalesApp.ViewModels
{
    class CustomerDetailViewModel : CustomViewModelBase
    {
        private Customer customer;

        public Customer Customer
        {
            get { return this.customer; }
            set
            {
                this.customer = value;
                this.customer.PropertyChanged += this.CustomerOnPropertyChanged;
                RaisePropertyChanged();
            }
        }

        private void CustomerOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
        }

        public CustomerDetailViewModel(Customer customer)
        {
            this.Customer = customer;
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
