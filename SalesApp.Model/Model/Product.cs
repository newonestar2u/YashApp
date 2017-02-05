using System.Collections.Generic;

namespace SalesApp.Model.Model
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
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
