using GalaSoft.MvvmLight.Command;
using SalesApp.Extensions;
using SalesApp.Model.Model;
using SalesApp.Pages;
using Xamarin.Forms;

namespace SalesApp.ViewModels
{
    public class ProductViewModel : CustomViewModelBase
    {
        private Product product;

        public Product Product
        {
            get { return product; }
            set
            {
                product = value;
                RaisePropertyChanged();
            }
        }

        public ProductViewModel(Product product)
        {
            this.Product = product;
            InstantiateCommands();
        }

        public ProductViewModel()
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
            ContentPage detail = new Detail();
            await ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(detail);
            ProductDetailViewModel pdvm = (ProductDetailViewModel)detail.BindingContext;
            pdvm.Product = Product;
            detail.BindingContext = pdvm;
        }
    }
}
