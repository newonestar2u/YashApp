using System;
namespace SalesApp.Model.Attributes
{
    public class UriAttribute : Attribute
    {
        public string Uri { get; set; }

        public UriAttribute(string uri)
        {
            this.Uri = uri;
        }
    }
}
