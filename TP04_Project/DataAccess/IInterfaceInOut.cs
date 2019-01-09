using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP04_Project.DataAccess
{

    // This Interface is for the input and output dialog box
    public interface IInterfaceInOut
    {

        /*
         * Getter and Setter for DialogTitle
         */
        string GetDialogTitle();
        
        void SetDialogTitle(string dialogTitle);


        /*
         * Getter and Setter for DialogFilter
         */
        string GetDialogFilter();
        
        void SetDialogFilter(string dialogFilter);



    }
}
