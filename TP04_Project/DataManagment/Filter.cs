using System;
using System.Drawing;


namespace TP04_Project.DataManagment
{
    // Class Filter : Inherits from the Inteface Filter
    public class Filter : IInterfaceFilter
    {
        // Filter name
        private string filterName;

        // Get the filter name
        public string GetFilterName()
        {
            return filterName;
        }

        // Set the filter name
        public void SetFilterName(string filterName)
        {
            this.filterName = filterName;
        }

        // Return the bitmap with the Rainbow filter applied on it
        public Bitmap RainbowFilter(Bitmap selectedSource)
        {
            // Temp bitmap
            Bitmap temp = null;
            try {
                temp = new Bitmap(selectedSource.Width, selectedSource.Height);
                int raz = selectedSource.Height / 4;

                // Set the pixel of the image with Rainbow filter
                for (int i = 0; i < selectedSource.Width; i++)
                {
                    for (int x = 0; x < selectedSource.Height; x++)
                    {

                        if (i < (raz))
                        {
                            temp.SetPixel(i, x, Color.FromArgb(selectedSource.GetPixel(i, x).R / 5, selectedSource.GetPixel(i, x).G, selectedSource.GetPixel(i, x).B));
                        }
                        else if (i < (raz * 2))
                        {
                            temp.SetPixel(i, x, Color.FromArgb(selectedSource.GetPixel(i, x).R, selectedSource.GetPixel(i, x).G / 5, selectedSource.GetPixel(i, x).B));
                        }
                        else if (i < (raz * 3))
                        {
                            temp.SetPixel(i, x, Color.FromArgb(selectedSource.GetPixel(i, x).R, selectedSource.GetPixel(i, x).G, selectedSource.GetPixel(i, x).B / 5));
                        }
                        else if (i < (raz * 4))
                        {
                            temp.SetPixel(i, x, Color.FromArgb(selectedSource.GetPixel(i, x).R / 5, selectedSource.GetPixel(i, x).G, selectedSource.GetPixel(i, x).B / 5));
                        }
                        else
                        {
                            temp.SetPixel(i, x, Color.FromArgb(selectedSource.GetPixel(i, x).R / 5, selectedSource.GetPixel(i, x).G / 5, selectedSource.GetPixel(i, x).B / 5));
                        }
                    }

                }
            }
            catch (Exception e)
            {
                // If there is any exception, return null
                Console.WriteLine("Image is null");
                Console.WriteLine(e.Message);
                return null;
            }
            
            // Return the temp image
            return temp;
        }

        // Return the bitmap with the Black and white filter applied on it
        public Bitmap BlackAndWhiteFilter(Bitmap selectedSource)
        {
            int rgb;
            Color c;
            try
            {
                // Apply the Black and White on each pixel of the bitmap
                for (int y = 0; y < selectedSource.Height; y++)
                    for (int x = 0; x < selectedSource.Width; x++)
                    {
                        c = selectedSource.GetPixel(x, y);
                        rgb = (int)((c.R + c.G + c.B) / 3);
                        selectedSource.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                    }
            }
            catch (Exception e) {
                // if there is any exception, return null
                Console.WriteLine("Image is null");
                Console.WriteLine(e.Message);
                return null;
            }
          
            // return the selected source with black and white filter
            return selectedSource;
        }
    }
}
