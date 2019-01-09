using System;

namespace TP04_Project.DataAccess
{
    public class Output : IInterfaceInOut
    {
        private String DialogTitle = "Location to save file";
        private String DialogFilter = "Images | *.jpg; *.jpeg; *.bmp; *.png";


        /*
         * Getter and Setter for DialogFilter
         */
        public string GetDialogFilter()
        {
            return DialogFilter;
        }
        
        public void SetDialogFilter(string dialogFilter)
        {
            DialogFilter = dialogFilter;
        }
        
        /*
         * Getter and Setter for DialogTitle
         */
        public string GetDialogTitle()
        {
            return DialogTitle;
        }

        public void SetDialogTitle(string dialogTitle)
        {
            DialogTitle = dialogTitle;
        }
    }
}
