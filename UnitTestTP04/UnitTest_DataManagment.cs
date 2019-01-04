using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP04_Project;
using System.Drawing;
using TP04_Project.DataManagment;
using NSubstitute;

namespace UnitTestTP04
{
    [TestClass]
    public class UnitTest_DataManagment
    {

        private Filter filter = new Filter();

        private Edge edge = new Edge();

        private FilterManager filterManager = new FilterManager();

        private EdgeManager edgeManager = new EdgeManager();

        // ************* FILTER *************
        [TestMethod]
        public void TestFilterGetSetFilterName()
        {
            var filterSub = Substitute.For<IInterfaceFilter>();

            string newName = "new filter name";

            filterSub.GetFilterName().Returns<string>(newName);

            filter.SetFilterName(newName);

            Assert.AreEqual(filter.GetFilterName(), filterSub.GetFilterName());

        }

        [TestMethod]
        public void TestFilterRainbowFilter()
        {
            var filterSub = Substitute.For<IInterfaceFilter>();

            string path = "Ressources\\Iceland.jpg";

            filterSub.GetFilterName().Returns<string>("Rainbow");

            Bitmap bitmapSub = new Bitmap(path);

            bitmapSub = filterManager.ApplyFilter(bitmapSub, filterSub);

            Assert.IsInstanceOfType(bitmapSub, typeof(Bitmap));

        }


      





















        // ************* EDGE *************

        [TestMethod]
        public void TestEdgeGetSetEdgeName()
        {
            var edgeSub = Substitute.For<IInterfaceEdge>();

            string newName = "new edge name";

            edgeSub.GetEdgeName().Returns<string>(newName);

            edge.SetEdgeName(newName);

            Assert.AreEqual(edge.GetEdgeName(), edgeSub.GetEdgeName());

        }


        [TestMethod]
        public void TestEdgeGetPrewitt3x3Horizontal()
        {
            var edgeSub = Substitute.For<IInterfaceEdge>();

            double[,] newGetPrewitt3x3Horizontal = 
            {
                { -1,  0,  1, },
                { -1,  0,  1, },
                { -1,  0,  1, },
            };

            edgeSub.GetPrewitt3x3Horizontal().Returns<double[,]>(newGetPrewitt3x3Horizontal);

            edge.GetPrewitt3x3Horizontal();

            Assert.AreEqual(edge.GetPrewitt3x3Horizontal(), edge.GetPrewitt3x3Horizontal());

        }

        

    }
}
