using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP04_Project.DataManagment
{
    public class Edge : InterfaceEdge
    {
        private string edgeName;

        public string GetEdgeName()
        {
            return edgeName;
        }

        public void setEdgeName(string edgeName)
        {
            this.edgeName = edgeName;
        }
    }
}
