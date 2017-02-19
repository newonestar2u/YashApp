namespace SalesApp.CustomViews
{
    using System;

    using SalesApp.ViewModels;

    public partial class CartOrderView 
    {
        public CartOrderView()
        {
            InitializeComponent();
        }

        private void ButtonRemoveClicked(object sender, EventArgs e)
        {
            var viewModel = this.BindingContext as OrderViewModel;
            if (viewModel != null)
            {
                //viewModel.Order.Set = false;
                App.Orders.Remove(viewModel.Order);
            }
        }
    }
}
