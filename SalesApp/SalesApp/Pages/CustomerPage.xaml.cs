using Xamarin.Forms;
namespace SalesApp.Pages
{
    public partial class CustomerPage : ContentPage
    {
        public CustomerPage()
        {
            InitializeComponent();

            var productPage = new ProductPage();
            var orderPage = new OrderPage();
            var invoicePage = new InvoicePage();

            ToolbarItems.Add(new ToolbarItem("Customers", "", () =>
            {
                //Navigation.PushAsync(this);
                //foreach (Customer customer in ps.GetCustomer())
                //{
                //    CustomerDetail detail = new CustomerDetail();
                //    CustomerDetailViewModel pdvm = (CustomerDetailViewModel)detail.BindingContext;
                //    pdvm.Customer = customer;
                //    detail.BindingContext = pdvm;
                //    // Navigation.PushAsync(detail);

                //    //ToolbarItems.Add(new ToolbarItem(customer.CustomerId, "", () =>
                //    //{
                //    //    CustomerDetail detail = new CustomerDetail();
                //    //    CustomerDetailViewModel pdvm = (CustomerDetailViewModel)detail.BindingContext;
                //    //    pdvm.Customer = customer;
                //    //    detail.BindingContext = pdvm;
                //    //    Navigation.PushAsync(detail);
                //    //}));
                //}
            }));

            ToolbarItems.Add(new ToolbarItem("Products", "", () =>
            {
                Navigation.PushAsync(productPage);
            }));

            ToolbarItems.Add(new ToolbarItem("Orders", "", () =>
            {
                Navigation.PushAsync(orderPage);
            }));

            ToolbarItems.Add(new ToolbarItem("Invoice", "", () =>
            {
                Navigation.PushAsync(invoicePage);
            }));

            ToolbarItems.Add(new ToolbarItem("Cart", Icon = "cart.png", () =>
            {
                Navigation.PushAsync(new CartPage());
            }));

        }
    }
}
