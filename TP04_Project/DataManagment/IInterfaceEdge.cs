
using System.Drawing;

namespace TP04_Project.DataManagment
{
    // Class Interface Edge
    public interface IInterfaceEdge
    {
        // Get the name of the edge
        string GetEdgeName();

        // Set the name of the edge
        void SetEdgeName(string edgeName);

        // Return a bitmap with the Prewitt edge applied on it
        Bitmap PrewittEdge(Bitmap selectedSource, bool grayscale = true);

        // Return a bitmap with the Kirsch edge applied on it
        Bitmap KirschEdge(Bitmap selectedSource, bool grayscale = true);

        // Get a double to apply the Prewitt edge (Horizontal)
        double[,] GetPrewitt3x3Horizontal();

        // Get a double to apply the Prewitt edge (Vertical)
        double[,] GetPrewitt3x3Vertical();

        // Get a double to apply the Kirsch edge (Horizontal)
        double[,] GetKirsch3x3Horizontal();

        // Get a double to apply the Kirsch edge (Vertical)
        double[,] GetKirsch3x3Vertical();
        
    }
}
