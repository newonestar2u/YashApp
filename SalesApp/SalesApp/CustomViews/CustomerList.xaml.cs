using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SalesApp.CustomViews
{
    using SalesApp.ViewModels;

    public partial class CustomerList : ContentView
    {
        private IList<CustomerViewModel> list;
        public CustomerList()
        {
            InitializeComponent();
        }

        private void List_OnBindingContextChanged(object sender, EventArgs e)
        {
            list = (IList<CustomerViewModel>)this.BindingContext;
            if (list != null)
            {
                Container.Children.Clear();
                foreach (CustomerViewModel customer in list)
                {
                    CustomerView customerView = new CustomerView();
                    customerView.BindingContext = customer;
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
