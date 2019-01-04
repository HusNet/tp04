using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageEdgeDetection;
using System.Drawing;

namespace TP04_Project.DataManagment
{
    public class FilterManager 
    {

        //Filtres : rainbow - Black and white

        public Bitmap ApplyFilter(Bitmap selectedSource, IInterfaceFilter ifilter)
        {
            Bitmap bitmapApplyFilter = null;

            try {
                switch (ifilter.GetFilterName())
                {
                    case "None":
                        bitmapApplyFilter = selectedSource;
                        break;

                    case "Rainbow":
                        bitmapApplyFilter = ifilter.RainbowFilter(selectedSource);
                        break;

                    case "Black and White":
                        bitmapApplyFilter = ifilter.BlackAndWhiteFilter(selectedSource);
                        break;
                }

            }
            catch (Exception e)
            {
                bitmapApplyFilter = selectedSource;
                System.Diagnostics.Debug.Write(e);
            }
           
            return bitmapApplyFilter;
        }
    }
}
