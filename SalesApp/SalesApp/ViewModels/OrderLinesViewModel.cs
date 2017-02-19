namespace SalesApp.ViewModels
{
    using System.Collections.Generic;

    using Extensions;
    using Model.Model;

    public class OrderLinesViewModel : CustomViewModelBase<Order>
    {
        private IList<OrderLineViewModel> orders;

        public IList<OrderLineViewModel> Orders
        {
            get
            {
                return orders;
            }
            set
            {
                orders = value;
                var list = new ObservableList<OrderLineViewModel>(orders);
                list.CollectionChanged += RaiseCollectionChanged;
                RaisePropertyChanged();
            }
        }
    }
}