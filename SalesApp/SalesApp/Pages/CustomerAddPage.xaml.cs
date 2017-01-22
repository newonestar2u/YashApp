using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SalesApp.Pages
{
    using GalaSoft.MvvmLight.Command;

    using SalesApp.ViewModels;

    public partial class CustomerAddPage : ContentPage
    {
        public CustomerAddPage()
        {
            InitializeComponent();
            this.BindingContextChanged += CustomerAddPage_BindingContextChanged;
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            this.LabelResult.Text = "";
            CustomerAddModel model = (CustomerAddModel)this.BindingContext;
            if (model.Customer.Id == 0)
            {
                this.LabelResult.Text = "Failed to insert.";
                this.LabelResult.IsVisible = true;
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
