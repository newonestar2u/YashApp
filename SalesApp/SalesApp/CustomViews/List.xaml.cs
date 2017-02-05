using System;
using System.Collections.Generic;
using SalesApp.ViewModels;

namespace SalesApp.CustomViews
{
    public partial class List 
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
                foreach (var product in list)
                {
                    var productView = new ProductView();
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
