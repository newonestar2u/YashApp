using SalesApp.Model.Extensions;

namespace SalesApp.Model.Model
{
    public class Price : NotifyModelChanged
    {
        private string description;
        private double cost;
        private double quantity;
        private bool bought;
        public double Value
        {
            get { return cost; }
            set
            {
                cost = value;
                NotifyPropertyChanged();
            }
        }

        public double Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                NotifyPropertyChanged();
            }

        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                NotifyPropertyChanged();
            }
        }

        public bool Bought
        {
            get { return bought; }
            set
            {
                bought = value;
                NotifyPropertyChanged();
            }
        }
    }
}
