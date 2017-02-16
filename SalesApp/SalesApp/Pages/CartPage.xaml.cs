using System.Collections.Generic;
using SalesApp.ViewModels;

namespace SalesApp.Pages
{
   
    public partial class CartPage
    {
        public CartPage()
        {
            InitializeComponent();
            //this.BindingContext = this;
            //this.Count = App.Orders.Count;
            //this.UpdateChildrenLayout();
        }

        private void ButtonCheckOutClicked(object sender, System.EventArgs e)
        {
            var orderModels = (CartModel)this.BindingContext;
            orderModels.SaveChanges();
        }
    }
}
