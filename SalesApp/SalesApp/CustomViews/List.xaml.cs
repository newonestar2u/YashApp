using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApp.Model.Model;
using SalesApp.ViewModels;
using Xamarin.Forms;

namespace SalesApp.CustomViews
{
    public partial class List : ContentView
    {
        private IList<ProductViewModel> list;
        public List()
        {
            InitializeComponent();
        }


        private void List_OnBindingContextChanged(object sender, EventArgs e)
        {
            list = (IList<ProductViewModel>) this.BindingContext;
            if (list != null)
            {
                Container.Children.Clear();
                foreach (ProductViewModel product in list)
                {
                    ProductView productView = new ProductView();
                    productView.BindingContext = product;
                    Container.Children.Add(productView);
                    if (product != list[list.Count - 1])
                    {
                        Container.Children.Add(new ListDivider());
                    }
                }
            }
        }
    }
}
