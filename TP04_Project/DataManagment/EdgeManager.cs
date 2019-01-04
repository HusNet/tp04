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

        //Edge prewitt and  Kirsch
        public Bitmap ApplyEdge(Bitmap selectedSource, IInterfaceEdge iEdge)
        {
            Bitmap bitmapApplyEdge = null;

            switch (iEdge.GetEdgeName())
            {
                case "None":
                    bitmapApplyEdge = selectedSource;
                    break;

                case "Prewitt":
                    bitmapApplyEdge = iEdge.PrewittEdge(selectedSource);
                    break;

                case "Kirsch":
                    bitmapApplyEdge = iEdge.KirschEdge(selectedSource);
                    break;
            }
            return bitmapApplyEdge;
        }



    }
}
