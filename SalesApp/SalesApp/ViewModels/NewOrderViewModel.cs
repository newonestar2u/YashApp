using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.ViewModels
{
    using SalesApp.Extensions;

    using Xamarin.Forms;

    public class NewOrderViewModel: CustomViewModelBase
    {
        public CustomersViewModel CustomersView { get; set; }
        public ProductsViewModel ProductsView { get; set; }

        public NewOrderViewModel()
        {
            this.CustomersView = new CustomersViewModel();
            this.ProductsView = new ProductsViewModel();
        }
    }
}
