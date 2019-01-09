using System;

namespace TP04_Project.DataAccess
{
    public class Output : IInterfaceInOut
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
