using System.Collections.Generic;
using System.Linq;
using SalesApp.Extensions;
using SalesApp.Model.Model;
using SalesApp.Service;

namespace SalesApp.ViewModels
{
    public class ProductsViewModel : CustomViewModelBase
    {
        private IList<ProductViewModel> products = new List<ProductViewModel>();

        public IList<ProductViewModel> Products
        {
            get { return this.products; }
            set
            {
                this.products = value;
                ObservableList<ProductViewModel> list = new ObservableList<ProductViewModel>(this.products);
                list.CollectionChanged += RaiseCollectionChanged;
                RaisePropertyChanged();
            }
        }

        public ProductsViewModel()
        {
            BindData();
        }

        private async void BindData()
        {
            var productService = new ProductService();
            this.Products = ConvertProductsToViewModels(await productService.GetAsync());
        }

        private IList<ProductViewModel> ConvertProductsToViewModels(IList<Product> products)
        {
            return products.Select(product => new ProductViewModel(product)).ToList();
        }
    }
}
