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
                Text = "Orders",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            var items = new AppService<Order>().Get();

            // Create the ListView.
            var ordersListView = new ListView
            {
                // Source of data items.
                ItemsSource = items,
                RowHeight = 70,

                ItemTemplate = new DataTemplate(() =>
                {
                    // Create views with bindings for displaying each property.
                    var customerId = new Label(); customerId.SetBinding(Label.TextProperty, "CustomerId");
                    var orderDate = new Label(); orderDate.SetBinding(Label.TextProperty, "OrderDate");
                    var totalOrders = new Label(); totalOrders.SetBinding<Order>(Label.TextProperty, o => o.OrderLines.Count);

                    //var stackLayout = new StackLayout();

                    #region Order lines view
                    var orderLinesView = new ListView
                    {
                        //RowHeight = 100,
                        //ItemsSource = "OrderLines",
                        ItemTemplate = new DataTemplate(() =>
                        {
                            // Create views with bindings for displaying each property.
                            var product = new Label();
                            product.SetBinding(Label.TextProperty, "Product");
                            var amount = new Label();
                            amount.SetBinding(Label.TextProperty, "Amount");
                            var quantity = new Label();
                            quantity.SetBinding(Label.TextProperty, "Quantity");

                            var gridDataOrderLines = new Grid()
                            {
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                ColumnDefinitions = new ColumnDefinitionCollection()
                                {
                                    new ColumnDefinition() {Width = new GridLength(1, GridUnitType.Star)},
                                    new ColumnDefinition() {Width = new GridLength(80)},
                                    new ColumnDefinition() {Width = new GridLength(80)}
                                },
                                RowDefinitions = new RowDefinitionCollection()
                                {
                                    new RowDefinition() {Height =  new GridLength(60)},
                                }
                            };
                            gridDataOrderLines.Children.Add(product, 0, 0);
                            gridDataOrderLines.Children.Add(amount, 1, 0);
                            gridDataOrderLines.Children.Add(quantity, 2, 0);
                            // Return an assembled ViewCell.
                            return new ViewCell()
                            {
                                View = gridDataOrderLines
                            };
                        })
                    };
                    #endregion

                    //stackLayout.Children.Add(orderLinesView);
                    orderLinesView.SetBinding<Order>(ListView.ItemsSourceProperty, o => o.OrderLines);
                    //var boxView = new BoxView();
                    //boxView.SetBinding(BoxView.ColorProperty, "FavoriteColor");
                    var gridData = new Grid()
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        ColumnDefinitions = new ColumnDefinitionCollection()
                        {
                            new ColumnDefinition() {Width = new GridLength(80)},
                            new ColumnDefinition() {Width = new GridLength(260)},
                            new ColumnDefinition() {Width = new GridLength(1, GridUnitType.Star)}
                        },
                        RowDefinitions = new RowDefinitionCollection()
                        {
                            new RowDefinition() {Height =  new GridLength(1,GridUnitType.Star)},
                            new RowDefinition() {Height =  new GridLength(1, GridUnitType.Star)}
                        }
                    };
                    gridData.Children.Add(customerId, 0, 0);
                    gridData.Children.Add(orderDate, 1, 0);
                    gridData.Children.Add(totalOrders, 2, 0);
                    gridData.Children.Add(orderLinesView, 0, 1);
                    Grid.SetColumnSpan(orderLinesView, 3);
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
                    ordersListView
                }
            });
        }
    }
}
