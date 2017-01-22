using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApp.Extensions;
using SalesApp.Model.Model;
using Xamarin.Forms;
using SalesApp.Service.Contracts;
using SalesApp.Service;

namespace SalesApp.ViewModels
{
    public class MainViewModel: CustomViewModelBase
    {
        #region fields
        private IList<ProductViewModel> products;
        #endregion

        #region properties

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
        #endregion

        #region constructors
        public MainViewModel()
        {
            //IProductService productService = new ProductService();
            //this.Products = ConvertProductsToViewModels(productService.All());
        }
        #endregion

        #region methods

        private IList<ProductViewModel> ConvertProductsToViewModels(IList<Product> products)
        {
            IList<ProductViewModel> productViewModels = new List<ProductViewModel>();
            foreach (Product product in products)
            {
                ProductViewModel pvm = new ProductViewModel(product);
                productViewModels.Add(pvm);
            }
            return productViewModels;
        }


        #endregion
    }
}
