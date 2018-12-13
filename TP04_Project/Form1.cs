using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP04_Project
{
    public partial class ImageDetectionTP04 : Form
    {
        public ImageDetectionTP04()
        {
            InitializeComponent();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            SetComboboxFilterActive(true);

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }


        private void ComboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFilter.SelectedIndex > 0)
            {
                SetComboboxEdgeActive(true);
            }
            else {
                SetComboboxEdgeActive(false);
            }

           

    

        }

       
        private void ComboBoxEdge_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEdge.SelectedIndex > 0)
            {
                SetComboboxFilterActive(false);
            }
            else {
                SetComboboxFilterActive(true);
            }
        }

        private void PictureBoxForImageLoaded_Click(object sender, EventArgs e)
        {

        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            SetComboboxEdgeActive(false);
            SetComboboxFilterActive(true);
            comboBoxEdge.SelectedIndex = 0;
            comboBoxFilter.SelectedIndex = 0;

        }

        // enable the filter combobox if active = true
        // disable the filter combobox if active = false
        private void SetComboboxFilterActive(bool active) {

            if (active == true)
            {
                this.comboBoxFilter.Enabled = true;
            } else
            {
                this.comboBoxFilter.Enabled = false;
            }

        }

       
        // enable the edge combobox if active = true
        // disable the edge combobox if active = false
        private void SetComboboxEdgeActive(bool active)
        {
            if (active == true)
            {
                this.comboBoxEdge.Enabled = true;
            }
            else
            {
                this.comboBoxEdge.Enabled = false;
            }


        }
    }
}
