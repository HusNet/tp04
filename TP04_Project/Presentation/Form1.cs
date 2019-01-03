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
using TP04_Project.DataAccess;
using TP04_Project.DataManagment;



namespace TP04_Project
{
    public partial class ImageDetectionTP04 : Form
    {
        private Bitmap loadedImage = null;

        private Bitmap currentBitmapFilter = null;
        private Bitmap currentBitmapEdge = null;

        private InterfaceFilter filter = new Filter();
        private FilterManager filterManager = new FilterManager();

        private InterfaceEdge edge = new Edge();
        private EdgeManager edgeManager = new EdgeManager();

        private IInterfaceInOut input = new Input();
        private InputManager inputManager = new InputManager();

        private IInterfaceInOut output = new Output();
        private OutputManager outputManager = new OutputManager();

        public ImageDetectionTP04()
        {
            InitializeComponent();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            loadedImage = inputManager.LoadImageFromDisk(input, pictureBoxForImageLoaded);
            if (loadedImage != null)
            {
                Clear();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            outputManager.SaveImageToDisk(pictureBoxForImageLoaded.Image, output);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void ComboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {    
            if (comboBoxFilter.SelectedIndex > 0)
            {
                SetComboboxEdgeActive(true);
            }
            else
            {
                SetComboboxEdgeActive(false);
            }

            currentBitmapFilter = inputManager.GetOriginalImageFromFile().CopyToSquareCanvas(pictureBoxForImageLoaded.Width);

            filter.setFilterName(comboBoxFilter.SelectedItem.ToString());
            currentBitmapFilter = filterManager.ApplyFilter(currentBitmapFilter, filter);
            pictureBoxForImageLoaded.Image = currentBitmapFilter;
        }

        private void ComboBoxEdge_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEdge.SelectedIndex > 0)
            {
                SetComboboxFilterActive(false);
            }
            else
            {
                SetComboboxFilterActive(true);
            }

            edge.setEdgeName(comboBoxEdge.SelectedItem.ToString());
            currentBitmapEdge = currentBitmapFilter;
            currentBitmapEdge = edgeManager.ApplyEdge(currentBitmapEdge, edge);
            pictureBoxForImageLoaded.Image = currentBitmapEdge;





        }

        private void PictureBoxForImageLoaded_Click(object sender, EventArgs e)
        {

        }
        


        // enable the filter combobox if active = true
        // disable the filter combobox if active = false
        private void SetComboboxFilterActive(bool actived)
        {
            this.comboBoxFilter.Enabled = actived;
        }

        // enable the edge combobox if active = true
        // disable the edge combobox if active = false
        private void SetComboboxEdgeActive(bool actived)
        {
            this.comboBoxEdge.Enabled = actived;
        }
        
        private void Clear()
        {
            SetComboboxEdgeActive(false);
            SetComboboxFilterActive(true);
            comboBoxEdge.SelectedIndex = 0;
            comboBoxFilter.SelectedIndex = 0;
        }
    }
}
