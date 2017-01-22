using GalaSoft.MvvmLight;
using System.Collections.Specialized;
using System.ComponentModel;

namespace SalesApp.Extensions
{
    public class CustomViewModelBase : ViewModelBase
    {
        public CustomViewModelBase()
        {

        }

        public void RaiseCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            RaisePropertyChanged();
        }

        public void RaisePropertyModelChanged(object sender, PropertyChangedEventArgs args)
        {
            RaisePropertyChanged();
        }
    }
}
