namespace SalesApp
{
    using System.Collections.Generic;
    using Model.Model;
    using Pages;
    using Xamarin.Forms;

    public class App : Application
    {
        public static List<Order> Orders = new List<Order>();

        public App()
        {
            MainPage = new NavigationPage(new CustomerPage());
            //CustomerPage cusPage = new CustomerPage();
            //ProductPage productPage = new ProductPage();
            //OrderPage orderPage = new OrderPage();

            //ToolbarItems.Add(new ToolbarItem("Customers", "", () =>
            //{
            //    Navigation.PushAsync(cusPage);

            //}));

            //ToolbarItems.Add(new ToolbarItem("Products", "", () =>
            //{
            //    Navigation.PushAsync(productPage);
            //}));

            //ToolbarItems.Add(new ToolbarItem("ordersViewModels", "", () =>
            //{
            //    Navigation.PushAsync(orderPage);
            //}));
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
