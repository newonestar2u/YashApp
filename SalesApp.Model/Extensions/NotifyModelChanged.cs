using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SalesApp.Model.Extensions
{
    public class NotifyModelChanged:INotifyPropertyChanged
    {
        #region events
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void NotifyCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            NotifyPropertyChanged();
        }

        #endregion
    }
}
