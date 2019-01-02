using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ImageEdgeDetection;

namespace TP04_Project.DataManagment
{
    public class EdgeManager
    {

        //Edge   Prewitt3X3 Laplacian3x3OfGaussian3x3Filter
        public Bitmap ApplyEdge(Bitmap selectedSource, InterfaceEdge iEdge)
        {
            Bitmap bitmapApplyEdger = null;

            switch (iEdge.GetEdgeName())
            {
                case "None":
                    bitmapApplyEdger = selectedSource;
                    break;

                case "Prewitt":
                    bitmapApplyEdger = selectedSource.PrewittFilter(false);
                    break;

                case "Laplacian 3x3 of Gaussian 3x3":
                    bitmapApplyEdger = selectedSource.Laplacian3x3OfGaussian3x3Filter();
                    break;
            }
            return bitmapApplyEdger;
        }



    }
}
