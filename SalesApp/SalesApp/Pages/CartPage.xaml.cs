﻿namespace SalesApp.Pages
{
    using ViewModels;

    public partial class CartPage
    {
        public CartPage()
        {
            InitializeComponent();
            //this.BindingContext = this;
            //this.Count = App.ordersViewModels.Count;
            //this.UpdateChildrenLayout();
        }

        private void ButtonCheckOutClicked(object sender, System.EventArgs e)
        {
            var orderModels = (CartModel)this.BindingContext;
            orderModels.SaveChanges();
        }
    }
}
