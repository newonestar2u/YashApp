using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.ViewModels
{
    using SalesApp.Extensions;
    using SalesApp.Model.Model;

    public class OrderLinesViewModel : CustomViewModelBase
    {
        private IList<OrderLineViewModel> orders;

        public IList<OrderLineViewModel> Orders
        {
            get
            {
                return this.orders;
            }
            set
            {
                this.orders = value;
                ObservableList<OrderLineViewModel> list = new ObservableList<OrderLineViewModel>(this.orders);
                list.CollectionChanged += RaiseCollectionChanged;
                RaisePropertyChanged();
            }
        }

        public OrderLinesViewModel()
        {

        }

        private IList<OrderLineViewModel> ConvertProductsToViewModels(IList<OrderLine> customers)
        {
            return customers.Select(product => new OrderLineViewModel(product)).ToList();
        }
    }
}