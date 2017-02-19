namespace SalesApp.ViewModels
{
    using System.Collections.Generic;

    using Extensions;
    using Model.Model;
    using Service;

    public class ProductsViewModel : CustomViewModelBase<Product>
    {
        private IList<ProductViewModel> products = new List<ProductViewModel>();

        public IList<ProductViewModel> Products
        {
            get { return products; }
            set
            {
                products = value;
                var list = new ObservableList<ProductViewModel>(products);
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
            Products = this.ConverToModelView< ProductViewModel>(await productService.GetAsync());
        }
    }
}
