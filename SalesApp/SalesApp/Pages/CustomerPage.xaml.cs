using Xamarin.Forms;
namespace SalesApp.Pages
{
    using GalaSoft.MvvmLight.Command;

    using SalesApp.ViewModels;

    public partial class CustomerPage : ContentPage
    {
        public CustomerPage()
        {

            InitializeComponent();

            //Navigation.PushAsync(new CustomerDetail());
            //Navigation.PushAsync(new Detail());
            // CustomerService ps = new CustomerService();

            //CustomerPage cusPage = new CustomerPage();
            ProductPage productPage = new ProductPage();
            OrderPage orderPage = new OrderPage();

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
        }

     
    }
}
