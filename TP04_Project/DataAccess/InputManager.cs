using ImageEdgeDetection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP04_Project.DataAccess
{
    class InputManager
    {
        private Bitmap loadedImage;
        private Bitmap originalImageFromFile;
        private PictureBox pictureBoxForImageLoaded;

        public Bitmap LoadImageFromDisk(IInterfaceInOut input, PictureBox pictureBoxForImageLoaded) {
            this.pictureBoxForImageLoaded = pictureBoxForImageLoaded;

            OpenFileDialog filedialog = new OpenFileDialog
            {
                Title = input.GetDialogTitle(),
                Filter = input.GetDialogFilter()
            };


            if (filedialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(filedialog.FileName);
                originalImageFromFile = (Bitmap) Image.FromStream(streamReader.BaseStream);
                streamReader.Close();
    
                LoadImageFromFile();
               
            }

            return loadedImage;
        }

        private void LoadImageFromFile()
        {
            loadedImage = originalImageFromFile.CopyToSquareCanvas(pictureBoxForImageLoaded.Width);
            ApplyPreview();
            
        }

        private void ApplyPreview()
        {
            pictureBoxForImageLoaded.Image = loadedImage;
        }

        public Bitmap GetOriginalImageFromFile()
        {
            return originalImageFromFile;
        }
    }
}
