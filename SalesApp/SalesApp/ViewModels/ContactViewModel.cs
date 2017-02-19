namespace SalesApp.ViewModels
{
    using SalesApp.Extensions;

    public class ContactViewModel : CustomViewModelBase
    {
        #region fields
        private string address;
        private string phonenumber;
        private string email;
        private string googleMapsUri;
        #endregion

        #region properties

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                RaisePropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get { return phonenumber; }
            set
            {
                phonenumber = value;
                RaisePropertyChanged();
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                RaisePropertyChanged();
            }
        }

        public string GoogleMapsUri
        {
            get { return googleMapsUri; }
            set
            {
                googleMapsUri = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region constructor

        public ContactViewModel()
        {
            Address = "Katarinavägen 15, Stockholm, Zweden";
            PhoneNumber = "056 475 589";
            Email = "battlefield@eadice.com";
            GoogleMapsUri = "https://maps.googleapis.com/maps/api/staticmap?center=" + Address + "&size=900x600";
        }
        #endregion
    }
}
