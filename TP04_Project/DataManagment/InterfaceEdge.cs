using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP04_Project.DataManagment
{
    public interface InterfaceEdge
    {
        string GetEdgeName();

        void SetEdgeName(string edgeName);

        Bitmap PrewittEdge(Bitmap selectedSource, bool grayscale = true);

        Bitmap KirschEdge(Bitmap selectedSource, bool grayscale = true);
        
    }
}
