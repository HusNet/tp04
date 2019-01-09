using System;
using System.Drawing;
using ImageEdgeDetection;

namespace TP04_Project.DataManagment
{
    // Class Edge : Inherits from the Inteface Edge
    public class Edge : IInterfaceEdge
    {

        // Edge name
        private string edgeName;

        // Get the edge name
        public string GetEdgeName()
        {
            return edgeName;
        }

        // Set the edge name
        public void SetEdgeName(string edgeName)
        {
            this.edgeName = edgeName;
        }

        // Return a bitmap with the Kirsch edge applied on it
        public Bitmap KirschEdge(Bitmap selectedSource, bool grayscale = true)
        {
            try
            {
                // Apply the Kirsch edge on the bitmap with selectedSource in parameter
                // And store the result in resultBitmap
                Bitmap resultBitmap = ExtBitmap.ConvolutionEdge(selectedSource,
                                               GetKirsch3x3Horizontal(),
                                                 GetKirsch3x3Vertical(),
                                                       1.0, 0, grayscale);
                //return resultBitmap
                return resultBitmap;
            }
            catch (Exception e)
            {
                // If there is an exception catch it and return null
                Console.WriteLine("Image is null");
                Console.WriteLine(e.Message);
                return null;
            }


        }

        //  Return a bitmap with the Prewitt edge applied on it
        public Bitmap PrewittEdge(Bitmap selectedSource, bool grayscale = true)
        {
            try
            {
                // Apply the Prewitt edge on the bitmap with selectedSource in parameter
                // And store the result in resultBitmap
                Bitmap resultBitmap = ExtBitmap.ConvolutionEdge(selectedSource,
                                             GetPrewitt3x3Horizontal(),
                                               GetPrewitt3x3Vertical(),
                                                      1.0, 0, grayscale);
                // return the resultBitmap
                return resultBitmap;
            }
            catch (Exception e)
            {
                // If there is an exception catch it and return null
                Console.WriteLine("Image is null");
                Console.WriteLine(e.Message);
                return null;
            }
        }

        // Get a double Value to make the Prewitt filter (Horizontal)
        public double[,] GetPrewitt3x3Horizontal()
        {
            return new double[,]
            {
                { -1,  0,  1, },
                { -1,  0,  1, },
                { -1,  0,  1, },
            };
        }

        // Get a double Value to make the Prewitt filter (Vertical
        public double[,] GetPrewitt3x3Vertical()
        {
            return new double[,]
            {
                {  1,  1,  1, },
                {  0,  0,  0, },
                { -1, -1, -1, },
            };
        }

        // Get a double Value to make the Kirsch filter (Horizontal)
        public double[,] GetKirsch3x3Horizontal()
        {
            return new double[,]
            {
                {  5,  5,  5, },
                { -3,  0, -3, },
                { -3, -3, -3, },
            };
        }


        // Get a double Value to make the Kirsch filter (Vertical)
        public double[,] GetKirsch3x3Vertical()
        {
            return new double[,]
            {
                {  5, -3, -3, },
                {  5,  0, -3, },
                {  5, -3, -3, },
            };
        }


     

    }
}
