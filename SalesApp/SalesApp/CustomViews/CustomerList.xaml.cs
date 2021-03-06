﻿using System;
using System.Collections.Generic;
using SalesApp.ViewModels;

namespace SalesApp.CustomViews
{
    public partial class CustomerList 
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
                foreach (var customer in list)
                {
                    var customerView = new CustomerView { BindingContext = customer };
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
