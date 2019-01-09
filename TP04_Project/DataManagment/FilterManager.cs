using System;
using System.Drawing;

namespace TP04_Project.DataManagment
{
    // Class Filter Manager : Manage the Rainbow and the Black and White filters
    public class FilterManager 
    {
        // Return a bitmap with the correct filter selected on it
        public Bitmap ApplyFilter(Bitmap selectedSource, IInterfaceFilter ifilter)
        {
            // Bitmap where the filter will apply
            Bitmap bitmapApplyFilter = null;

            try {

                // Get the name of the filter selected
                switch (ifilter.GetFilterName())
                {
                    // None : The user don't want any filter on the bitmap. Get the original bitmap
                    case "None":
                        bitmapApplyFilter = selectedSource;
                        break;

                    // Rainbow : apply the Rainbow filter on the bitmap
                    case "Rainbow":
                        bitmapApplyFilter = ifilter.RainbowFilter(selectedSource);
                        break;

                    // Black and White :  apply the Black and white filter on the bitmap
                    case "Black and White":
                        bitmapApplyFilter = ifilter.BlackAndWhiteFilter(selectedSource);
                        break;
                }
            }
            catch (Exception e)
            {
                // If there is any exception, return null
                Console.WriteLine(e);
                bitmapApplyFilter = null;
            }
           
            // return the bitmap with the filter selected
            return bitmapApplyFilter;
        }
    }
}
