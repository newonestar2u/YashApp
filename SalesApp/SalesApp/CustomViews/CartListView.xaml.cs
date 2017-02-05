using System;
using System.Collections.Generic;
using SalesApp.ViewModels;

namespace SalesApp.CustomViews
{
    public partial class CartListView 
    {
        private IList<OrderViewModel> list;

        public CartListView()
        {
            InitializeComponent();
        }

        private void List_OnBindingContextChanged(object sender, EventArgs e)
        {
            list = (IList<OrderViewModel>)this.BindingContext;
            if (list != null)
            {
                Container.Children.Clear();
                foreach (var customer in list)
                {
                    var customerView = new CartOrderView { BindingContext = customer };
                    Container.Children.Add(customerView);

                    if (customer != list[list.Count - 1])
                    {
                        Container.Children.Add(new ListDivider());
                    }
                }
            }
        }
    }
}
