using System.Collections.Generic;
using SalesApp.Model.Attributes;

namespace SalesApp.Model.Model
{
    [Uri("Products")]
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductType { get; set; }
        public bool IsActive { get; set; }
        public IList<string> ImageUrls
        {
            get { return imageUrls; }
            set
            {
                if (value != null)
                    imageUrls = value;
            }
        }

        private IList<string> imageUrls = new List<string>() { "SalesApp.Images.bf4.bf4cover.png" };
    }
}
