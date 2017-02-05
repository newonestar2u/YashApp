using Xamarin.Forms;

namespace SalesApp.CustomViews
{
    public partial class ListDivider 
    {
        public ListDivider()
        {
            InitializeComponent();
            this.StackLayout.BackgroundColor = Color.Green;
        }

        public ListDivider(Color color)
        {
            InitializeComponent();
            this.StackLayout.BackgroundColor = color;
        }
    }
}
