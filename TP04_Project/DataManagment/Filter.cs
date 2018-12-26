using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP04_Project.DataManagment
{
    public class Filter : InterfaceFilter
    {
        private string filterName;

        public string GetFilterName()
        {
            return filterName;
        }

        public void setFilterName(string filterName)
        {
            this.filterName = filterName;
        }
    }
}
