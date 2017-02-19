namespace SalesApp.ViewModels
{
    using System.Collections.Generic;
    using Extensions;
    using Model.Model;

    public class MainViewModel: CustomViewModelBase<Product>
    {
        private IList<ProductViewModel> products;

        public IList<ProductViewModel> Products
        {
            get { return products;}
            set
            {
                products= value;
                ObservableList<ProductViewModel> list = new ObservableList<ProductViewModel>(products);
                list.CollectionChanged += RaiseCollectionChanged;
                RaisePropertyChanged();
            }
        }

        public MainViewModel()
        {
            //IProductService productService = new ProductService();
            //this.Products = ConvertProductsToViewModels(productService.All());
        }
    }
}
