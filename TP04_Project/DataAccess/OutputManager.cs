using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP04_Project.DataAccess
{
    class OutputManager
    {

        public void SaveImageToDisk(Image loadedImage, IInterfaceInOut output)
        {

            SaveFileDialog filedialog = new SaveFileDialog
            {
                Title = output.GetDialogTitle(),
                Filter = output.GetDialogFilter()
            };

            if (filedialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                String fileExtension = Path.GetExtension(filedialog.FileName).ToUpper();
                ImageFormat imgFormat;

                switch (fileExtension)
                {
                    case "BMP":
                        imgFormat = ImageFormat.Bmp;
                        break;
                    case "JPG":
                        imgFormat = ImageFormat.Jpeg;
                        break;
                    case "PNG":
                    default:
                        imgFormat = ImageFormat.Png;
                        break;
                }

                StreamWriter streamWriter = new StreamWriter(filedialog.FileName, false);
                loadedImage.Save(streamWriter.BaseStream, imgFormat);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }
    }
}
