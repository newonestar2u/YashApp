using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SalesApp.CustomViews
{
    public partial class ImageGridView 
    {
        private IList<string> ImageUrls { get; set; }
        public ImageGridView()
        {
            InitializeComponent();
        }

        public void InitializeGrid()
        {
            if (ImageUrls != null)
            {
                
                Container.Children.Clear();
                var rows = Convert.ToInt32(Math.Ceiling(Math.Sqrt(ImageUrls.Count)));
                var columns = Convert.ToInt32(Math.Floor(Math.Sqrt(ImageUrls.Count)));
                var vertical = new Grid();
                for (var i = 0; i < rows; i++)
                {
                    Grid grid = new Grid();
                    for (var j = 0; j < columns; j++)
                    {
                        if (columns*i + j < ImageUrls.Count && !String.IsNullOrEmpty(ImageUrls[columns*i + j]))
                        {
                            StackLayout s = new StackLayout();
                            Image image = new Image();
                            image.Aspect = Aspect.Fill;
                            image.Source = ImageSource.FromResource(ImageUrls[columns*i + j]);
                            s.Children.Add(image);
                            grid.Children.Add(s, j,0);
                        }
                        vertical.Children.Add(grid,0,i);
                    }

                }
                Container.Children.Add(vertical);

            }
        }

        private void ImageGridView_OnBindingContextChanged(object sender, EventArgs e)
        {
            ImageUrls = (IList<string>)this.BindingContext;
            InitializeGrid();
        }
    }
}
