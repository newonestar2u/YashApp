using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SalesApp.CustomViews
{
    using SalesApp.ViewModels;

    public partial class OrderList : ContentView
    {
        private IList<OrderViewModel> list;
        public OrderList()
        {
            InitializeComponent();
        }

        private void List_OnBindingContextChanged(object sender, EventArgs e)
        {
            list = (IList<OrderViewModel>)this.BindingContext;
            if (list != null)
            {
                Container.Children.Clear();
                foreach (OrderViewModel product in list)
                {
                    OrderView productView = new OrderView();
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
