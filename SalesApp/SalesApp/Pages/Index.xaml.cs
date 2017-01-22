using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApp.Model.Model;
using SalesApp.Service;
using SalesApp.ViewModels;
using Xamarin.Forms;

namespace SalesApp.Pages
{
    public partial class Index : ContentPage
    {
        public Index()
        {
            InitializeComponent();
            ProductService ps = new ProductService();
            foreach (Product product in ps.All())
            {
                ToolbarItems.Add(new ToolbarItem(product.Name, "", () =>
                {
                    Detail detail = new Detail();
                    ProductDetailViewModel pdvm = (ProductDetailViewModel)detail.BindingContext;
                    pdvm.Product = product;
                    detail.BindingContext = pdvm;
                    Navigation.PushAsync(detail);
                }));
            }
            ToolbarItems.Add(new ToolbarItem("Contact", "", () =>
            {
                Navigation.PushAsync(new Contact());
            }));
        }
    }
}
