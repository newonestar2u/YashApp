﻿using System;
using System.Collections.Generic;

namespace SalesApp.CustomViews
{
    using SalesApp.ViewModels;

    public partial class OrderList 
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
                foreach (var order in list)
                {
                    var productView = new OrderView { BindingContext = order };
                    Container.Children.Add(productView);
                    if (order != list[list.Count - 1])
                    {
                        Container.Children.Add(new ListDivider());
                    }
                }
            }
        }
    }
}
