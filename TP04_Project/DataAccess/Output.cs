using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP04_Project.DataAccess
{
    class Output : IInterfaceInOut
    {
        private String DialogTitle = "Location to save file";
        private String DialogFilter = "Images | *.jpg; *.jpeg; *.bmp; *.png";

        public string GetDialogFilter()
        {
            return DialogFilter;
        }

        public string GetDialogTitle()
        {
            return DialogTitle;
        }

        public void SetDialogFilter(string dialogFilter)
        {
            DialogFilter = dialogFilter;
        }

        public void SetDialogTitle(string dialogTitle)
        {
            DialogTitle = dialogTitle;
        }
    }
}
