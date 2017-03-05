using SalesApp.Model.Model;
using SalesApp.Service;
using Xamarin.Forms;

namespace SalesApp.Pages
{
    public partial class InvoicePage : ContentPage
    {
        private ListView invoiceListView;
        public InvoicePage()
        {
            InitializeComponent();
            InitializeInvoices();
        }

        private void InitializeInvoices()
        {
            var header = new Label
            {
                Text = "Invoices",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            var items = new AppService<Invoice>().Get();

            // Create the ListView.
            invoiceListView = new ListView
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
                    nameLabel.SetBinding(Label.TextProperty, "CustomerId");
                    var orderNumberLabel = new Label();
                    orderNumberLabel.SetBinding(Label.TextProperty, "OrderNumber");
                    var amount = new Label();
                    amount.SetBinding(Label.TextProperty, "Amount");

                    var buttonAdd = new Button();
                    buttonAdd.Clicked += ButtonAdd_Clicked;
                    buttonAdd.Text = "Paid";
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
                            new ColumnDefinition() {Width = new GridLength(40)},
                            new ColumnDefinition() {Width = new GridLength(70)}
                        }
                    };
                    gridData.Children.Add(nameLabel, 0, 0);
                    gridData.Children.Add(orderNumberLabel, 1, 0);
                    gridData.Children.Add(amount, 2, 0);
                    gridData.Children.Add(buttonAdd, 3, 0);
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
            StackLayoutInvoices.Children.Add(new StackLayout
            {
                Children =
                {
                    header,
                    invoiceListView
                }
            });
        }
        private void ButtonAdd_Clicked(object sender, System.EventArgs e)
        {
            invoiceListView.BeginRefresh();
            var invoice = (sender as Button)?.CommandParameter as Invoice;
            invoice.Status = "Paid";
            var service = new AppService<Invoice>();
            service.Put(invoice);

            invoiceListView.ItemsSource = null;
            invoiceListView.ItemsSource = service.Get();
            invoiceListView.EndRefresh();
        }
    }
}