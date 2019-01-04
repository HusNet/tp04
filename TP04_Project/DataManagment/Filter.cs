using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP04_Project.DataManagment
{
    public class Filter : IInterfaceFilter
    {
        private string filterName;

       

        public string GetFilterName()
        {
            return filterName;
        }

      
        public void SetFilterName(string filterName)
        {
            this.filterName = filterName;
        }

        public Bitmap RainbowFilter(Bitmap selectedSource)
        {
            Bitmap temp = new Bitmap(selectedSource.Width, selectedSource.Height);
            int raz = selectedSource.Height / 4;
            for (int i = 0; i < selectedSource.Width; i++)
            {
                for (int x = 0; x < selectedSource.Height; x++)
                {

                    if (i < (raz))
                    {
                        temp.SetPixel(i, x, Color.FromArgb(selectedSource.GetPixel(i, x).R / 5, selectedSource.GetPixel(i, x).G, selectedSource.GetPixel(i, x).B));
                    }
                    else if (i < (raz * 2))
                    {
                        temp.SetPixel(i, x, Color.FromArgb(selectedSource.GetPixel(i, x).R, selectedSource.GetPixel(i, x).G / 5, selectedSource.GetPixel(i, x).B));
                    }
                    else if (i < (raz * 3))
                    {
                        temp.SetPixel(i, x, Color.FromArgb(selectedSource.GetPixel(i, x).R, selectedSource.GetPixel(i, x).G, selectedSource.GetPixel(i, x).B / 5));
                    }
                    else if (i < (raz * 4))
                    {
                        temp.SetPixel(i, x, Color.FromArgb(selectedSource.GetPixel(i, x).R / 5, selectedSource.GetPixel(i, x).G, selectedSource.GetPixel(i, x).B / 5));
                    }
                    else
                    {
                        temp.SetPixel(i, x, Color.FromArgb(selectedSource.GetPixel(i, x).R / 5, selectedSource.GetPixel(i, x).G / 5, selectedSource.GetPixel(i, x).B / 5));
                    }
                }

            }
            return temp;
        }

        public Bitmap BlackAndWhiteFilter(Bitmap selectedSource)
        {
            int rgb;
            Color c;

            for (int y = 0; y < selectedSource.Height; y++)
                for (int x = 0; x < selectedSource.Width; x++)
                {
                    c = selectedSource.GetPixel(x, y);
                    rgb = (int)((c.R + c.G + c.B) / 3);
                    selectedSource.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
            return selectedSource;
        }
    }
}
