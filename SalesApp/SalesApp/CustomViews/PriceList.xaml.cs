using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApp.Model.Model;
using Xamarin.Forms;

namespace SalesApp.CustomViews
{
    public partial class PriceList : ContentView
    {
        public IList<Price> Prices { get; set; }

        public PriceList()
        {
            InitializeComponent();
            Prices = new List<Price>();
        }

        private void UpdatePrices()
        {
            if (Prices != null)
            {
                list.Children.Clear();
                foreach (Price price in Prices)
                {
                    PriceListItem pli = new PriceListItem();
                    pli.BindingContext = price;
                    list.Children.Add(pli);
                }
            }
        }

        private void PriceList_OnBindingContextChanged(object sender, EventArgs e)
        {
            Prices = (IList<Price>) this.BindingContext;
            UpdatePrices();
        }
    }
}
