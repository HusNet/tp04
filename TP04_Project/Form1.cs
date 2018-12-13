using ImageEdgeDetection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP04_Project
{
    public partial class ImageDetectionTP04 : Form
    {
        private Bitmap originalImageFromFile = null;
        private Bitmap loadedImage = null;

        public ImageDetectionTP04()
        {
            InitializeComponent();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.Title = "Slect an image file";
            filedialog.Filter = "Images | *.jpg; *.jpeg; *.bmp; *.png";

            if (filedialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(filedialog.FileName);
                originalImageFromFile = (Bitmap)Image.FromStream(streamReader.BaseStream);
                streamReader.Close();

                LoadImageFromFile();
            }

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (loadedImage != null)
            {
                SaveFileDialog filedialog = new SaveFileDialog();
                filedialog.Title = "Location to save file";
                filedialog.Filter = "Images | *.jpg; *.jpeg; *.bmp; *.png";

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


        private void ComboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
        private void ComboBoxEdge_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PictureBoxForImageLoaded_Click(object sender, EventArgs e)
        {

        }



        private void LoadImageFromFile()
        {
            //comboBoxEdge.SelectedIndex = 0;
            //comboBoxFilter.SelectedIndex = 0;
          
            loadedImage = originalImageFromFile.CopyToSquareCanvas(pictureBoxForImageLoaded.Width);
            ApplyPreview();
        }

        private void ApplyPreview()
        {
            pictureBoxForImageLoaded.Image = loadedImage;
        }
    }
}
