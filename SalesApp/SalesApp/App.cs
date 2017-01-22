using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesApp.Model.Model;
using SalesApp.Pages;
using Xamarin.Forms;

namespace SalesApp
{
    public class App : Application
    {
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

            //ToolbarItems.Add(new ToolbarItem("Orders", "", () =>
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
