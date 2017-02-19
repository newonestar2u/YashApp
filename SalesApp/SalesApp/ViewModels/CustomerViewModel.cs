namespace SalesApp.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Extensions;
    using Model.Model;
    using Pages;
    using Xamarin.Forms;

    public class CustomerViewModel : CustomViewModelBase<Customer>
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

        public CustomerViewModel(Customer customer)
        {
            this.Customer = customer;
            InstantiateCommands();
        }

        public CustomerViewModel()
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
            ContentPage detail = new CustomerDetail();
            await ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(detail);
            CustomerDetailViewModel pdvm = (CustomerDetailViewModel)detail.BindingContext;
            pdvm.Customer = this.Customer;
            detail.BindingContext = pdvm;
        }
    }
}
