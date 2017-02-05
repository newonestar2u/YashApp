using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SalesApp.Pages
{
    using System.Collections.Specialized;

    using GalaSoft.MvvmLight;

    public partial class CartPage : ContentPage
    {
        public CartPage()
        {
            InitializeComponent();
            //this.BindingContext = this;
            //this.Count = App.Orders.Count;
            //this.UpdateChildrenLayout();
        }
    }
}
