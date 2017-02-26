using System.Collections.Generic;
using System.Linq;
using SalesApp.Model.Model;
using SalesApp.Service;
using SalesApp.ViewModels;
using Xamarin.Forms;
namespace SalesApp.Pages
{
    public partial class CustomerPage : ContentPage
    {
        private ListView customersListView;
        private ListView productsListView;

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
            InitializeProducts();
            InitializeCustomers();
        }

        private void InitializeProducts()
        {
            var header = new Label
            {
                Text = "Products",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            var items = new AppService<Product>().Get();

            // Create the ListView.
            productsListView = new ListView
            {
                // Source of data items.
                ItemsSource = items,
                RowHeight = 40,

                // Define template for displaying each item.
                // (Argument of DataTemplate constructor is called for 
                //      each item; it must return a Cell derivative.)
                ItemTemplate = new DataTemplate(() =>
                {
                    // Create views with bindings for displaying each property.
                    var nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "Name");
                    var customerId = new Label();
                    customerId.SetBinding(Label.TextProperty, "Amount");

                    var buttonAdd = new Button();
                    buttonAdd.Clicked += ButtonAdd_Clicked;
                    buttonAdd.Text = "Add";
                    buttonAdd.FontSize = 10;
                    buttonAdd.SetBinding(Button.CommandParameterProperty, new Binding("."));

                    var boxView = new BoxView();
                    boxView.SetBinding(BoxView.ColorProperty, "FavoriteColor");
                    var gridData = new Grid()
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        ColumnDefinitions = new ColumnDefinitionCollection()
                        {
                            new ColumnDefinition() {Width = new GridLength(1, GridUnitType.Star)},
                            new ColumnDefinition() {Width = new GridLength(40)},
                            new ColumnDefinition() {Width = new GridLength(70)}
                        }
                    };
                    gridData.Children.Add(nameLabel, 0, 0);
                    gridData.Children.Add(customerId, 1, 0);
                    gridData.Children.Add(buttonAdd, 2, 0);
                    // Return an assembled ViewCell.
                    return new ViewCell
                    {
                        View = gridData
                    };
                })
            };

            // Accomodate iPhone status bar.
            //this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            ProductsStackLayout.Children.Add(new StackLayout
            {
                Children =
                {
                    header,
                    productsListView
                }
            });
        }

        private void ButtonAdd_Clicked(object sender, System.EventArgs e)
        {
            var product = (sender as Button)?.CommandParameter as Product;
            var customer = customersListView.SelectedItem as Customer;
            if (product != null && customer != null)
            {
                if (App.Orders.Any(x => x.CustomerId == customer.CustomerId))
                {
                    var order = App.Orders.First(x => x.CustomerId == customer.CustomerId);
                    var orderLine = order.OrderLines.FirstOrDefault(x => x.Product == product.Name);

                    if (orderLine != null)
                    {
                        orderLine.Quantity += 1;
                    }
                    else
                    {
                        var newOrderline = new OrderLine
                        {
                            Set = true,
                            Amount = product.Amount,
                            DeliveredBy = "Application",
                            Product = product.Name,
                            Quantity = 1,
                        };
                        order.OrderLines.Add(newOrderline);
                    }
                }
                else
                {
                    App.Orders.Add(new Order()
                    {
                        CustomerId = customer.CustomerId,
                        OrderBy = "Application",
                        Set = true,
                        OrderLines = new List<OrderLine>()
                        {
                            new OrderLine()
                            {
                                Set = true,
                                Amount = product.Amount,
                                DeliveredBy = "Application",
                                Product = product.Name,
                                Quantity = 1
                            }
                        }
                    });
                }
            }
        }

        private void InitializeCustomers()
        {

            var header = new Label
            {
                Text = "Customers",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            var items = new AppService<Customer>().Get();

            // Create the ListView.
            customersListView = new ListView
            {
                // Source of data items.
                ItemsSource = items,
                RowHeight = 80,

                // Define template for displaying each item.
                // (Argument of DataTemplate constructor is called for 
                //      each item; it must return a Cell derivative.)
                ItemTemplate = new DataTemplate(() =>
                {
                    // Create views with bindings for displaying each property.
                    var nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "FirstName");
                    var customerId = new Label();
                    customerId.SetBinding(Label.TextProperty, "DoorNo");
                    var mobileNo = new Label();
                    mobileNo.SetBinding(Label.TextProperty, "Mobile");

                    BoxView boxView = new BoxView();
                    boxView.SetBinding(BoxView.ColorProperty, "FavoriteColor");
                    var gridData = new Grid()
                    {
                        //HorizontalOptions = LayoutOptions.FillAndExpand,
                        ColumnDefinitions = new ColumnDefinitionCollection()
                        {
                            new ColumnDefinition() {Width = new GridLength(1, GridUnitType.Star)}
                            //new ColumnDefinition() {Width = new GridLength(1, GridUnitType.Star)},
                            //new ColumnDefinition() {Width = new GridLength(80)}
                        },
                        RowDefinitions = new RowDefinitionCollection() {
                            new RowDefinition() { Height = GridLength.Auto },
                            new RowDefinition() { Height = GridLength.Auto },
                            new RowDefinition() { Height = GridLength.Auto }
                        }
                    };
                    gridData.Children.Add(nameLabel, 0, 0);
                    gridData.Children.Add(customerId, 0, 1);
                    gridData.Children.Add(mobileNo, 0, 2);
                    // Return an assembled ViewCell.
                    return new ViewCell
                    {

                        View = gridData
                    };
                })
            };

            // Accomodate iPhone status bar.
            //this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            CustomersStackLayout.Children.Add(new StackLayout
            {
                Children =
                {
                    header,
                    customersListView
                }
            });
        }
    }
}
