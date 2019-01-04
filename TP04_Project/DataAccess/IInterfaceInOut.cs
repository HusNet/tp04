using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP04_Project.DataAccess
{
    public interface IInterfaceInOut
    {
        string GetDialogTitle();

        void SetDialogTitle(string dialogTitle);


        string GetDialogFilter();

        void SetDialogFilter(string dialogTitle);



    }
}
