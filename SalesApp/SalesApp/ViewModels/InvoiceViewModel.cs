namespace SalesApp.ViewModels
{
    using Model.Model;
    using Extensions;

    public class InvoiceViewModel : CustomViewModelBase<Invoice>
    {
        public Invoice Invoice { get; set; }

        public InvoiceViewModel(Invoice invoice)
        {
            this.Invoice = invoice;
        }

        public InvoiceViewModel()
        {
        }
    }
}
