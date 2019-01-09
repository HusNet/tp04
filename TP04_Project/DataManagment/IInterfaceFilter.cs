using System.Drawing;

namespace TP04_Project.DataManagment
{
    // Class Interface Filter
    public interface IInterfaceFilter
    {
        // Get the filter name
        string GetFilterName();
        
        // Set the filter name
        void SetFilterName(string filterName);

        // Return a bitmap with black and white filter applied on it
        Bitmap BlackAndWhiteFilter(Bitmap selectedSource);

        // Return a bitmap with Rainbow filter applied on it
        Bitmap RainbowFilter(Bitmap selectedSource);
    }
}
