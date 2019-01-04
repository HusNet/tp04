using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageEdgeDetection;

namespace TP04_Project.DataManagment
{
    public class Edge : InterfaceEdge {
        private string edgeName;

        public string GetEdgeName()
        {
            return edgeName;
        }


        public Bitmap KirschEdge(Bitmap selectedSource, bool grayscale = true)
        {

            Bitmap resultBitmap = ExtBitmap.ConvolutionFilter(selectedSource,
                                                Kirsch3x3Horizontal,
                                                  Kirsch3x3Vertical,
                                                        1.0, 0, grayscale);

            return resultBitmap;
        }

        public Bitmap PrewittEdge(Bitmap selectedSource, bool grayscale = true)
        {
            Bitmap resultBitmap = ExtBitmap.ConvolutionFilter(selectedSource,
                                              Prewitt3x3Horizontal,
                                                Prewitt3x3Vertical,
                                                       1.0, 0, grayscale);

            return resultBitmap;
        }

        public void SetEdgeName(string edgeName)
        {
            this.edgeName = edgeName;
        }
        
        public double[,] Prewitt3x3Horizontal
        {
            get
            {
                return new double[,]
                { { -1,  0,  1, },
                  { -1,  0,  1, },
                  { -1,  0,  1, }, };
            }
        }

        public double[,] Prewitt3x3Vertical
        {
            get
            {
                return new double[,]
                { {  1,  1,  1, },
                  {  0,  0,  0, },
                  { -1, -1, -1, }, };
            }
        }


        public double[,] Kirsch3x3Horizontal
        {
            get
            {
                return new double[,]
                { {  5,  5,  5, },
                  { -3,  0, -3, },
                  { -3, -3, -3, }, };
            }
        }

        public double[,] Kirsch3x3Vertical
        {
            get
            {
                return new double[,]
                { {  5, -3, -3, },
                  {  5,  0, -3, },
                  {  5, -3, -3, }, };
            }
        }
    }
}
