using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP04_Project.DataManagment
{
    public interface IInterfaceFilter
    {

        string GetFilterName();

        void SetFilterName(string filterName);

        Bitmap BlackAndWhiteFilter(Bitmap selectedSource);

        Bitmap RainbowFilter(Bitmap selectedSource);


    }
}
