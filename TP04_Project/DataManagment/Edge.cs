using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageEdgeDetection;

namespace TP04_Project.DataManagment
{
    public class Edge : InterfaceEdge
    {
        private string edgeName;

        public string GetEdgeName()
        {
            return edgeName;
        }


        public Bitmap KirschEdge(Bitmap selectedSource, bool grayscale = true)
        {

            Bitmap resultBitmap = ExtBitmap.ConvolutionFilter(selectedSource,
                                                Matrix.Kirsch3x3Horizontal,
                                                  Matrix.Kirsch3x3Vertical,
                                                        1.0, 0, grayscale);

            return resultBitmap;
        }

        public Bitmap PrewittEdge(Bitmap selectedSource, bool grayscale = true)
        {
            Bitmap resultBitmap = ExtBitmap.ConvolutionFilter(selectedSource,
                                              Matrix.Prewitt3x3Horizontal,
                                                Matrix.Prewitt3x3Vertical,
                                                       1.0, 0, grayscale);

            return resultBitmap;
        }

        public void SetEdgeName(string edgeName)
        {
            this.edgeName = edgeName;
        }


    }
}
