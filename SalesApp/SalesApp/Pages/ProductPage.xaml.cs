using SalesApp.Model.Model;
using SalesApp.Service;
using Xamarin.Forms;

namespace SalesApp.Pages
{
    public partial class ProductPage : ContentPage
    {
        public ProductPage()
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

            var items = new AppService<Product>().Get();

            // Create the ListView.
            var productsListView = new ListView
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

                    var description = new Label();
                    description.SetBinding(Label.TextProperty, "Description");

                    var boxView = new BoxView();
                    boxView.SetBinding(BoxView.ColorProperty, "FavoriteColor");
                    var gridData = new Grid()
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        ColumnDefinitions = new ColumnDefinitionCollection()
                        {
                            new ColumnDefinition() {Width = new GridLength(1, GridUnitType.Star)},
                            new ColumnDefinition() {Width = new GridLength(40)},
                            new ColumnDefinition() {Width = new GridLength(1, GridUnitType.Star)}
                        }
                    };
                    gridData.Children.Add(nameLabel, 0, 0);
                    gridData.Children.Add(customerId, 1, 0);
                    gridData.Children.Add(description, 2, 0);
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

    }
}
