using System;
using SalesApp.ViewModels;
using System.Collections.Generic;

namespace SalesApp.CustomViews
{
    public partial class ProductList
    {
        private IList<ProductViewModel> list;

        public ProductList()
        {
            InitializeComponent();
        }


        private void List_OnBindingContextChanged(object sender, EventArgs e)
        {
            list = (IList<ProductViewModel>)this.BindingContext;
            if (list != null)
            {
                Container.Children.Clear();
                foreach (var product in list)
                {
                    var productView = new ProductView { BindingContext = product };
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
