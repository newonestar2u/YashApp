using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SalesApp.CustomViews
{
    using SalesApp.ViewModels;

    public partial class OrderLineListView 
    {
        private IList<OrderLineViewModel> list;
        public OrderLineListView()
        {
            InitializeComponent();
        }

        private void List_OnBindingContextChanged(object sender, EventArgs e)
        {
            list = (IList<OrderLineViewModel>)this.BindingContext;
            if (list != null)
            {
                Container.Children.Clear();
                foreach (var product in list)
                {
                    var productView = new OrderLineView();
                    productView.BindingContext = product;
                    Container.Children.Add(productView);
                    if (product != list[list.Count - 1])
                    {
                        Container.Children.Add(new ListDivider(Color.Blue));
                    }
                }
            }
        }
    }
}
