using System.ComponentModel;
using SalesApp.Extensions;
using SalesApp.Model.Model;

namespace SalesApp.ViewModels
{
    public class ProductDetailViewModel : CustomViewModelBase
    {
        private Product product;
        private double total;


        public Product Product
        {
            get { return product; }
            set
            {
                product = value;
                product.PropertyChanged += ProductOnPropertyChanged;
                RaisePropertyChanged();
            }
        }

        private void ProductOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
        }

        public double Total
        {
            get { return total; }
            set
            {
                total = value;
                RaisePropertyChanged();
            }
        }

        public ProductDetailViewModel(Product product)
        {
            this.Product = product;
        }

        public ProductDetailViewModel()
        {
        }

    }
}
