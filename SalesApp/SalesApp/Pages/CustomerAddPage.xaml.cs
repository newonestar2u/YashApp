using System;
using SalesApp.ViewModels;

namespace SalesApp.Pages
{
    public partial class CustomerAddPage
    {
        public event EventHandler SaveComplete;

        public CustomerAddPage()
        {
            InitializeComponent();
            this.BindingContextChanged += CustomerAddPage_BindingContextChanged;
        }

        private void OnButtonClicked(object sender, EventArgs args)
        {
            this.LabelResult.Text = "";
            var model = (CustomerAddModel)this.BindingContext;
            if (model == null || model.Customer.Id == 0)
            {
                this.LabelResult.Text = "Failed to insert.";
                this.LabelResult.IsVisible = true;
            }
            else
            {
                this.SaveComplete?.Invoke(this, null);
            }
        }

        private void CustomerAddPage_BindingContextChanged(object sender, EventArgs e)
        {
            //if (this.BindingContext != null)
            //{
            //    CustomerAddModel customerAddModel = (CustomerAddModel)this.BindingContext;
            //}
        }
    }
}
