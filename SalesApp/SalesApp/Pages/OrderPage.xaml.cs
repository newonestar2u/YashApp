using SalesApp.Model.Model;
using SalesApp.Service;
using Xamarin.Forms;

namespace SalesApp.Pages
{
    public partial class OrderPage
    {
        public OrderPage()
        {
            InitializeComponent();
            InitalizeProducts();
        }

        private void InitalizeProducts()
        {
            var header = new Label
            {
                Text = "Products",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            var items = new AppService<Order>().Get();

            // Create the ListView.
            var productsListView = new ListView
            {
                // Source of data items.
                ItemsSource = items,
                RowHeight = 150,

                // Define template for displaying each item.
                // (Argument of DataTemplate constructor is called for 
                //      each item; it must return a Cell derivative.)
                ItemTemplate = new DataTemplate(() =>
                {
                    // Create views with bindings for displaying each property.
                    var customerId = new Label();
                    customerId.SetBinding(Label.TextProperty, "CustomerId");
                    var orderDate = new Label();
                    orderDate.SetBinding(Label.TextProperty, "OrderDate");

                    var totalOrders = new Label();
                    totalOrders.SetBinding<Order>(Label.TextProperty, (o) => o.OrderLines.Count);

                    var stackLayout = new StackLayout();
                    stackLayout.Children.Add(new Label() { Text = "Order#" });
                    stackLayout.Children.Add(new Label() { Text = "1000" });

                    var boxView = new BoxView();
                    boxView.SetBinding(BoxView.ColorProperty, "FavoriteColor");
                    var gridData = new Grid()
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        ColumnDefinitions = new ColumnDefinitionCollection()
                        {
                            new ColumnDefinition() {Width = new GridLength(60)},
                            new ColumnDefinition() {Width = new GridLength(260)},
                            new ColumnDefinition() {Width = new GridLength(1, GridUnitType.Star)}
                        },
                        RowDefinitions = new RowDefinitionCollection()
                        {
                            new RowDefinition() {Height =  new GridLength(1, GridUnitType.Star)},
                            new RowDefinition() {Height =  new GridLength(1, GridUnitType.Star)}
                        }
                    };
                    gridData.Children.Add(customerId, 0, 0);
                    gridData.Children.Add(orderDate, 1, 0);
                    gridData.Children.Add(totalOrders, 2, 0);
                    gridData.Children.Add(stackLayout, 0, 2);
                    // Return an assembled ViewCell.
                    return new ViewCell
                    {
                        View = gridData
                    };
                })
            };

            //productsListView.SetBinding(ListView.HeaderProperty, new Binding("."));

            // Accomodate iPhone status bar.
            //this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            OrdersStackLayout.Children.Add(new StackLayout
            {
                Children =
                {
                    header,
                    productsListView
                }
            });
        }
    }
}
