using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace TP04_Project.DataAccess
{
    public class OutputManager
    {

        /*
         *   Open the dialog box to let user save the picture
         */
        public void SaveImageToDisk(Image loadedImage, IInterfaceInOut output)
        {

            SaveFileDialog filedialog = new SaveFileDialog
            {
                Title = output.GetDialogTitle(),
                Filter = output.GetDialogFilter()
            };
            
            // check if valid input 
            if (filedialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // select right extension
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

                // export image
                StreamWriter streamWriter = new StreamWriter(filedialog.FileName, false);
                loadedImage.Save(streamWriter.BaseStream, imgFormat);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }
    }
}
