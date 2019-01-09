using System;
using System.Drawing;
using System.Windows.Forms;
using ImageEdgeDetection;
using TP04_Project.DataAccess;
using TP04_Project.DataManagment;

namespace TP04_Project
{
    public partial class ImageDetectionTP04 : Form
    {
        // Bitmap loaded from the user
        private Bitmap loadedImage = null;

        // Current bitmap for filter and edge
        private Bitmap currentBitmapFilter = null;
        private Bitmap currentBitmapEdge = null;

       // Iterface and manager for filter
        private IInterfaceFilter filter = new Filter();
        private FilterManager filterManager = new FilterManager();

        // Iterface and manager for edge
        private IInterfaceEdge edge = new Edge();
        private EdgeManager edgeManager = new EdgeManager();

        // Iterface and manager for input
        private IInterfaceInOut input = new Input();
        private InputManager inputManager = new InputManager();

        // Iterface and manager for output
        private IInterfaceInOut output = new Output();
        private OutputManager outputManager = new OutputManager();

        //Initialize component for the form
        public ImageDetectionTP04()
        {
            InitializeComponent();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                loadedImage = inputManager.LoadImageFromDisk(input, pictureBoxForImageLoaded);
                Clear();
                SetButtonClearActive(true);
                SetButtonSaveActive(true);
            }
            catch (Exception dialogCancelled)
            {
                System.Diagnostics.Debug.WriteLine(dialogCancelled.Message);
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
                
        // Manage the combo box for the filters
        // Apply the filter when one is selected
        private void ComboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {   
             // If the combobox is selected > 0 It means that one filter was selected
             // So the user can choose a Edge to apply (enable the combobox edge)
            if (comboBoxFilter.SelectedIndex > 0)
            {
                SetComboboxEdgeActive(true);
            }
            
            // If the combobox is selected < 0 It means that no filter was selected
            // So the user cannot choose an Edge until he hasn't chose a filter (disable the combobox edge)
            else
            {
                SetComboboxEdgeActive(false);
            }

            // Once a filter/no filter was choosen by the user it will be applied on the bitmap loaded
            try
            {
                // Get the original bitmap to apply the filter
                currentBitmapFilter = inputManager.GetOriginalImageFromFile().CopyToSquareCanvas(pictureBoxForImageLoaded.Width);
                // Get the name of the filter selected by the user and add it to the interface filter
                filter.SetFilterName(comboBoxFilter.SelectedItem.ToString());
                // Apply the filter selected on the bitmap through the manager
                currentBitmapFilter = filterManager.ApplyFilter(currentBitmapFilter, filter);
                // Put the bimtap with the applied filter on the picture box
                pictureBoxForImageLoaded.Image = currentBitmapFilter;
            }
            // If there is any exception it will be catch and set the bitmap to null
            catch (Exception ex)
            {
                Console.WriteLine(e);
                pictureBoxForImageLoaded.Image = null;
            }
        }

        // Manage the combo box for the edge
        // Apply the Edge when one is selected
        private void ComboBoxEdge_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If the combobox is selected > 0 It means that one edge was selected
            // So the user cannot choose any filters after he select the edge (disable the combobox filter)
            if (comboBoxEdge.SelectedIndex > 0)
            {
                SetComboboxFilterActive(false);
            }
            // If the combobox is selected < 0 It means that no edge was selected
            // So the user can change the Filter that he has selected before 
            // until he hasn't chose a edge (enable the combobox filter)
            else
            {
                SetComboboxFilterActive(true);
            }

            // Once an edge/no edge was choosen by the user it will be applied 
            // On the preview bitmap (the bitmap with the filter already applied to it)
            try
            {
                // Each edge is applied on the bitmap where there is already the filter on it
                // So we will get the current bitmap with the filter
                currentBitmapEdge = currentBitmapFilter;
                // Get the name of the filter selected by the user and add it to the interface filter
                edge.SetEdgeName(comboBoxEdge.SelectedItem.ToString());
                // Apply the edge selected on the bitmap through the manager
                currentBitmapEdge = edgeManager.ApplyEdge(currentBitmapEdge, edge);
                // Put the bimtap with the applied edge on the picture box
                pictureBoxForImageLoaded.Image = currentBitmapEdge;
            }
            // If there is any exception it will be catch and set the bitmap to null
            catch (Exception ex) {
                Console.WriteLine(e);
                pictureBoxForImageLoaded.Image = null;
            }
        }

        private void PictureBoxForImageLoaded_Click(object sender, EventArgs e)
        {

        }

        // When the user click on the Clear button
        // It will set the two combobox on 'None'
        // Enable the filter combobox and disable the edge combobox
        private void Clear()
        {
            SetComboboxEdgeActive(false);
            SetComboboxFilterActive(true);
            comboBoxEdge.SelectedIndex = 0;
            comboBoxFilter.SelectedIndex = 0;
        }

        // Enable and disable the filter combobox for the user 
        // Enable -> active = true
        // disable -> active = false
        private void SetComboboxFilterActive(bool actived)
        {
            this.comboBoxFilter.Enabled = actived;
        }

        // Enable and disable the edge combobox for the user 
        // Enable -> active = true
        // disable -> active = false
        private void SetComboboxEdgeActive(bool actived)
        {
            this.comboBoxEdge.Enabled = actived;
        }

        private void SetButtonClearActive(bool actived)
        {
            this.btnClear.Enabled = actived;
        }

        private void SetButtonSaveActive(bool actived)
        {
            this.btnSave.Enabled = actived;
        }

    }
}
