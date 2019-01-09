using System;
using System.Drawing;


namespace TP04_Project.DataManagment
{
    // Class Edge Manager : Manage the Edge Prewitt and Kirsch
    public class EdgeManager
    {
        // Return a Bitmap with the edge selected by the user
        public Bitmap ApplyEdge(Bitmap selectedSource, IInterfaceEdge iEdge)
        {
            // Bitmap which store the result with the applied edge
            Bitmap bitmapApplyEdge = null;

            try
            {
                // Detect the name of the Edge selected
                switch (iEdge.GetEdgeName())
                {
                    // None : The user don't want any edge on the bitmap. Get the original bitmap
                    case "None":
                        bitmapApplyEdge = selectedSource;
                        break;

                    // Prewitt : apply the Prewitt edge on the bitmap
                    case "Prewitt":
                        bitmapApplyEdge = iEdge.PrewittEdge(selectedSource);
                        break;

                    // Kirsch : apply the Kirsch edge on the bitmap
                    case "Kirsch":
                        bitmapApplyEdge = iEdge.KirschEdge(selectedSource);
                        break;
                }
                return bitmapApplyEdge;
            }
            catch (Exception e)
            {
                // If there is any exception, return null
                Console.WriteLine(e);
                return null; ;              
            }                
        }
    }
}
