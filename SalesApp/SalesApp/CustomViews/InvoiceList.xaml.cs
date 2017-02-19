using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SalesApp.CustomViews
{
    using SalesApp.ViewModels;

    public partial class InvoiceList : ContentView
    {
        private IList<InvoiceViewModel> list;
        public InvoiceList()
        {
            InitializeComponent();
        }

        private void List_OnBindingContextChanged(object sender, EventArgs e)
        {
            list = (IList<InvoiceViewModel>)this.BindingContext;
            if (list != null)
            {
                Container.Children.Clear();
                foreach (var invoice in list)
                {
                    var customerView = new InvoiceView { BindingContext = invoice };
                    Container.Children.Add(customerView);
                    if (invoice != list[list.Count - 1])
                    {
                        Container.Children.Add(new ListDivider());
                    }
                }
            }
        }
    }
}
