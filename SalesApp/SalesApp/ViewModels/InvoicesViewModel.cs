namespace SalesApp.ViewModels
{
    using System.Collections.Generic;

    using Model.Model;
    using Service;
    using Extensions;

    public class InvoicesViewModel : CustomViewModelBase<Invoice>
    {
        private IList<InvoiceViewModel> invoices;

        public IList<InvoiceViewModel> Invoices
        {
            get { return invoices; }
            set
            {
                invoices = value;
                var list = new ObservableList<InvoiceViewModel>(invoices);
                list.CollectionChanged += RaiseCollectionChanged;
                RaisePropertyChanged();
            }
        }

        public InvoicesViewModel()
        {
            BindData();
        }

        private async void BindData()
        {
            var invoiceService = new InvoiceService();
            Invoices = ConverToModelView< InvoiceViewModel>(await invoiceService.GetAsync());
        }
    }
}
