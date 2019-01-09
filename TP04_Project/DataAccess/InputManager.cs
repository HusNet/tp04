using ImageEdgeDetection;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TP04_Project.DataAccess
{
    public class InputManager
    {
        private Bitmap loadedImage;
        private Bitmap originalImageFromFile;
        private PictureBox pictureBoxForImageLoaded;

        /*
         *   Open the dialog box to let user chose a picture
         */
        public Bitmap LoadImageFromDisk(IInterfaceInOut input, PictureBox pictureBoxForImageLoaded) {
            this.pictureBoxForImageLoaded = pictureBoxForImageLoaded;

            OpenFileDialog filedialog = new OpenFileDialog
            {
                Title = input.GetDialogTitle(),
                Filter = input.GetDialogFilter()
            };

            // check if valid input 
            if (filedialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // import image
                StreamReader streamReader = new StreamReader(filedialog.FileName);
                originalImageFromFile = (Bitmap) Image.FromStream(streamReader.BaseStream);
                streamReader.Close();
    
                LoadImageFromFile();
               
            }
            else
            {
                throw new Exception("User cancelled image selection dialog.");
            }

            return loadedImage;
        }

        /*
         *  Resize image to fit display
         */
        private void LoadImageFromFile()
        {
            loadedImage = originalImageFromFile.CopyToSquareCanvas(pictureBoxForImageLoaded.Width);
            ApplyPreview();
            
        }

        /*
         *  Load image into picture box
         */
        private void ApplyPreview()
        {
            pictureBoxForImageLoaded.Image = loadedImage;
        }

        /*
         *  Getter for original image (without filters or edge)
         */
        public Bitmap GetOriginalImageFromFile()
        {
            return originalImageFromFile;
        }
    }
}
