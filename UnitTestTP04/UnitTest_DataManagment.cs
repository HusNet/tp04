using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using TP04_Project.DataManagment;
using NSubstitute;
using System.IO;

namespace UnitTestTP04
{
    // This is a test calss for the filter and the edge
    // It will test all functionalities related the filter and the edge 
    // and the Interface which concerns them with NSubstitute
    [TestClass]
    public class UnitTest_DataManagment
    {
              
        private TestContext testContextInstance;

        //Gets or sets the test context which provides
        //information about and functionality for the current test run.
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        // Properties (Interface + Filters)
        private IInterfaceFilter iFilter = new Filter();
        private IInterfaceEdge iEdge = new Edge();
        private EdgeManager edgeManager = new EdgeManager();
        private FilterManager filterManager = new FilterManager();

        // path for all images
        private string pathIceland;
        private string pathIceland_BlackAndWhite;
        private string pathIceland_Rainbow;
        private string pathIceland_Prewitt;
        private string pathIceland_Kirsch;

        // Initialize all paths for the tests
        [TestInitialize]
        public void TestInitialize()
        {
            // Get the directory for the pictures
            var projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            // get each path for each pictures
            pathIceland = Path.Combine(projectFolder, @"pictures\", "Iceland.jpg");
            pathIceland_BlackAndWhite = Path.Combine(projectFolder, @"pictures\", "IcelandBlackWhite.jpg");
            pathIceland_Rainbow = Path.Combine(projectFolder, @"pictures\", "IcelandRainbow.jpg");
            pathIceland_Prewitt = Path.Combine(projectFolder, @"pictures\", "IcelandPrewitt.jpg");
            pathIceland_Kirsch = Path.Combine(projectFolder, @"pictures\", "IcelandKirsch.jpg");

        }

        // ******************** TEST FILTER ********************

        // Test if the get and the set for filters works correctly
        [TestMethod]
        public void TestFilter_GetSetFilterName()
        {
            // Substitute of the interface Filter
            var filterSub = Substitute.For<IInterfaceFilter>();
            // Give a new Name to the filter
            string newName = "Rainbow";
            // Give to the filterSub the new name
            filterSub.GetFilterName().Returns<string>(newName);
            // Set the filter with the new name
            iFilter.SetFilterName(newName);
            // Check if the names are equals
            Assert.AreEqual(iFilter.GetFilterName(), filterSub.GetFilterName());
        }

        // Test if the Rainbow filter is correctly applied
        [TestMethod]
        public void TestFilter_RainbowFilter()
        { 
            // Create a substitute of filter
            var filterSub = Substitute.For<Filter>();

            // Create the image with Rainbow applied using the correct path
            Bitmap bitmapRainbow = new Bitmap(pathIceland_Rainbow);

            // Create a bitmap with the path of the original image
            Bitmap bitmapResult = new Bitmap(pathIceland);
            // Apply on the bitmapResult the filter Rainbow
            bitmapResult = filterSub.RainbowFilter(bitmapResult);

            // Compare the pixels of the 2 bitamps to check if they are the same
            comparePixelImages(bitmapRainbow, bitmapResult);

        }

        // Test if the Black and White filter works correctly
        [TestMethod]
        public void TestFilter_BlackAndWhite()
        {
            // Create a substitute of filter
            var filterSub = Substitute.For<Filter>();

            // Create the bitmap with black and white filter applied
            Bitmap bitmapBlackWhite = new Bitmap(pathIceland_BlackAndWhite);

            // Create a bitmap with the path of the original image
            Bitmap bitmapResult = new Bitmap(pathIceland);
            // Apply the filter directly on the bitmap 
            bitmapResult = filterSub.BlackAndWhiteFilter(bitmapResult);
                 
            // Compare the pixels of the 2 bitamps
            comparePixelImages(bitmapBlackWhite, bitmapResult);

        }

        // Test if the none filter works correctly
        [TestMethod]
        public void TestFilter_NoneFilterManager()
        {
            // Create the bitmap with No filter applied using the correct path
            Bitmap bitmapNone = new Bitmap(pathIceland);

            // Set filter name 'None'
            iFilter.SetFilterName("None");

            // Create a bitmap with the path of the original image
            Bitmap bitmapResult = new Bitmap(pathIceland);
            // Apply the filter directly on the bitmap 
            bitmapResult = filterManager.ApplyFilter(bitmapResult, iFilter);

            // Compare the pixels of the 2 bitamps to check if they are the same
            comparePixelImages(bitmapNone, bitmapResult);

        }
    
        // Test the exception when the bitmap and the filter are null
        [TestMethod]
        public void TestFilter_NullBitmapNullFilter()
        {           
            // Create a null bitmap
            Bitmap bitmapNull = null;
           
            // Test the Applyfilter with null values
            bitmapNull = filterManager.ApplyFilter(bitmapNull, null);

            // Check if the result is null
            Assert.AreEqual(bitmapNull, null);
        }

        // Test the exception with the Black and White filter on a null bitmap
        [TestMethod]
        public void TestFilter_NullBitmapBlackAndWhiteFilter()
        {
            // Create a substitute of filter
            var filterSub = Substitute.For<Filter>(); 

            // Create a null bitmap
            Bitmap bitmapBlackWhite = null;

            // Force to throw an exception when a null bitmap is used to apply the black and white filter
            filterSub.When(x => x.BlackAndWhiteFilter(null)).Do(x => { throw new System.Exception("Null Nitmap"); });

            // Apply the black and white filter on a null bitmap
            bitmapBlackWhite = filterSub.BlackAndWhiteFilter(bitmapBlackWhite);

            // Check if result is null
            Assert.AreEqual(bitmapBlackWhite, null);
        }

        // Test the exception with the Rainbow filter on a null bitmap
        [TestMethod]
        public void TestFilter_NullBitmapRainbowFilter()
        {
            // Create a substitute of filter
            var filterSub = Substitute.For<Filter>();

            // Create a null bitmap
            Bitmap bitmapRainbow = null;

            // Force to throw an exception when a null bitmap is used to apply the rainbow filter
            filterSub.When(x => x.RainbowFilter(null)).Do(x => { throw new System.Exception("Null Nitmap"); });

            // Apply Rainbow filter on null bitmap
            bitmapRainbow = filterSub.RainbowFilter(bitmapRainbow);

            // Check if result is null
            Assert.AreEqual(bitmapRainbow, null);

        }

        // Test the filter manager with Black and White 
        [TestMethod]
        public void TestFilter_BlackAndWhiteFilterManager()
        {
            // Create the bitmap with black and white filter already applied
            Bitmap bitmapBlackWhite = new Bitmap(pathIceland_BlackAndWhite);

            // Set filter name 'Black and white'
            iFilter.SetFilterName("Black and White");

            // Create a bitmap with the path of the original image
            Bitmap bitmapResult = new Bitmap(pathIceland);
            // Apply the filter directly on the bitmap 
            bitmapResult = filterManager.ApplyFilter(bitmapResult, iFilter);

            // Compare the pixels of the 2 bitamps to check if they are the same
            comparePixelImages(bitmapBlackWhite, bitmapResult);

        }

        // Test the filter manager with Rainbow
        [TestMethod]
        public void TestFilter_RainbowFilterManager()
        {
            // Create the bitmap with Rainbow filter already applied
            Bitmap bitmapRainbow = new Bitmap(pathIceland_Rainbow);

            // Set filter name 'Rainbow'
            iFilter.SetFilterName("Rainbow");

            // Create a bitmap with the path of the original image
            Bitmap bitmapResult = new Bitmap(pathIceland);
            // Apply the filter directly on the bitmap 
            bitmapResult = filterManager.ApplyFilter(bitmapResult, iFilter);

            // Compare the pixels of the 2 bitamps to check if they are the same
            comparePixelImages(bitmapRainbow, bitmapResult);

        }



        // ******************** TEST EDGE ********************

        // Test if the get and the set works correctly
        [TestMethod]
        public void TestEdge_GetSetEdgeName()
        {
            // Substitute for the interface Edge
            var edgeSub = Substitute.For<IInterfaceEdge>();

            // Define a new name
            string newName = "Prewitt";

            // Give the new name for the substitute
            edgeSub.GetEdgeName().Returns<string>(newName);

            // Set Edge with the new name
            iEdge.SetEdgeName(newName);

            // Check if the names are the same
            Assert.AreEqual(iEdge.GetEdgeName(), edgeSub.GetEdgeName());

        }

        // Test the Prewitt Edge
        // The prewitt Edge is tested on a image with Rainbow filter already on it
        [TestMethod]
        public void TestEdge_Prewitt()
        {
            // Substitute for the interface Edge
            var edgeSub = Substitute.For<Edge>();

            // Create the image with Prewitt Edge applied using the correct path 
            Bitmap bitmapPrewitt = new Bitmap(pathIceland_Prewitt);

            // Create a bitmap with the path of the image with Rainbow filter already applied
            Bitmap bitmapResult = new Bitmap(pathIceland_Rainbow);
            // Apply the Edge Prewitt on the bitmapResult
            bitmapResult = edgeSub.PrewittEdge(bitmapResult);

            // Compare the 2 pixels of the bitmap to check if they are the same
            comparePixelImages(bitmapPrewitt, bitmapResult);

        }

        // Test the Kirsch Edge
        // The Kirsch Edge is tested on a image with Rainbow filter already on it
        [TestMethod]
        public void TestEdge_Kirsch()
        {
            // Substitute for the interface Edge
            var edgeSub = Substitute.For<Edge>();

            // Create the image with Kirsch Edge applied using the correct path
            Bitmap bitmapKirsch = new Bitmap(pathIceland_Kirsch);

            // Set the correct edge 'Kirsch'
            iEdge.SetEdgeName("Kirsch");

            // Create a bitmap with the path of the image with Rainbow filter already applied
            Bitmap bitmapResult = new Bitmap(pathIceland_Rainbow);
            // Apply the Kirsch Edge on the BitmapResult
            bitmapResult = edgeSub.KirschEdge(bitmapResult);

            // Compare the 2 pixels of the bitmap to check if they are the same
            comparePixelImages(bitmapKirsch, bitmapResult);

        }

        // Check the 'None' Edge
        // The original bitmap in this cas is an image with the rainbow filter already applied on it
        [TestMethod]
        public void TestEdge_NoneEdgeManager()
        {
            // Create the image with Rainbow Filter applied as original bitmap
            Bitmap bitmapNone = new Bitmap(pathIceland_Rainbow);

            // Set the correct edge 'None' 
            iEdge.SetEdgeName("None");

            // Create a bitmap with the path of the image with Rainbow filter already applied
            Bitmap bitmapResult = new Bitmap(pathIceland_Rainbow);
            // Apply the filer 'None' on the bitmapResult.
            bitmapResult = edgeManager.ApplyEdge(bitmapResult, iEdge);

            // Compare the 2 pixels of the bitmap if they are the same
            comparePixelImages(bitmapNone, bitmapResult);

        }

        // Test the exception with the prewitt edge on null bitmap
        [TestMethod]
        public void TestEdge_NullBitmapPrewittEdge()
        {
            // Create a substitute of edge
            var edgeSub = Substitute.For<Edge>();

            // Create a null bitmap
            Bitmap bitmapPrewitt = null;

            // Force to throw an exception when apply the prewitt edge on a null bitmap
            edgeSub.When(x => x.PrewittEdge(null)).Do(x => { throw new System.Exception("Null Nitmap"); });

            // Apply the Prewitt edge on null bitmap
            bitmapPrewitt = edgeSub.PrewittEdge(bitmapPrewitt);
            
            // Check if the result is null
            Assert.AreEqual(bitmapPrewitt, null);
        }

        // Test the exception with Kirsch edge on null bitmap
        [TestMethod]
        public void TestEdge_NullBitmapKirschEdge()
        {
            // Create a substitute of edge
            var edgeSub = Substitute.For<Edge>();

            // Create a null bitmap
            Bitmap bitmapKirsch = null;

            // Force to throw an exception when apply the kirsch edge on a null bitmap
            edgeSub.When(x => x.KirschEdge(null)).Do(x => { throw new System.Exception("Null Nitmap"); });

            // Apply the Kirsch edge on null bitmap
            bitmapKirsch = edgeSub.KirschEdge(bitmapKirsch);

            // Check if the result is null
            Assert.AreEqual(bitmapKirsch, null);
        }
        
        // Test the apply edge with null filter and null bitmap
        [TestMethod]
        public void TestEdge_NullBitmapNullFilter()
        {
            // Create a null bitmap
            Bitmap bitmapNull = null;
           
            //Apply null bitmap and null filter name on ApplyEdge
            bitmapNull = edgeManager.ApplyEdge(bitmapNull, null);

            // Check if result is null
            Assert.AreEqual(bitmapNull, null);
        }


        // Test the edge manager with Prewitt
        [TestMethod]
        public void TestFilter_PrewittEdgeManager()
        {
            // Create the bitmap with the prewitt edge applied 
            Bitmap bitmapPrewitt = new Bitmap(pathIceland_Prewitt);

            // Set filter name 'Prewitt'
            iEdge.SetEdgeName("Prewitt");

            // Create a bitmap with Rainbow filter as  original image
            Bitmap bitmapResult = new Bitmap(pathIceland_Rainbow);
            // Apply the filter directly on the bitmap 
            bitmapResult = edgeManager.ApplyEdge(bitmapResult, iEdge);

            // Compare the pixels of the 2 bitamps to check if they are the same
            comparePixelImages(bitmapPrewitt, bitmapResult);

        }


        // Test the edge manager with Kirsch
        [TestMethod]
        public void TestFilter_KirschEdgeManager()
        {
            // Create the bitmap with kirsch edge applied using 
            Bitmap bitmapKirsch = new Bitmap(pathIceland_Kirsch);

            // Set filter name 'Kirsch'
            iEdge.SetEdgeName("Kirsch");

            // Create a bitmap with rainbow filter as the original image
            Bitmap bitmapResult = new Bitmap(pathIceland_Rainbow);
            // Apply the filter directly on the bitmap 
            bitmapResult = edgeManager.ApplyEdge(bitmapResult, iEdge);

            // Compare the pixels of the 2 bitamps to check if they are the same
            comparePixelImages(bitmapKirsch, bitmapResult);

        }


        // ******************** COMPARE PIXELS ********************

        //Compare all pixel of two images
        public void comparePixelImages(Bitmap bitmapModified, Bitmap bitmapResult)
        {
            // Chekc if the size of the 2 bitmaps are the same
            if (bitmapModified.Size == bitmapResult.Size)
            {
                // Loop on each pixel of each bitmap
                for (int x = 0; x < bitmapModified.Width; ++x)
                {
                    for (int y = 0; y < bitmapModified.Height; ++y)
                    {
                        // Check if the pixel selected is not the same
                        if (bitmapModified.GetPixel(x, y) != bitmapResult.GetPixel(x, y))
                        {
                            // Pixel are not the same -> not the same bitmap
                            Assert.Fail("pixels of bitmap are not the same");
                        }
                    }
                }
            }
            else
            {
                // Size of the 2 bitmap are not the same
                Assert.Fail("size of bitmap are not the same");

            }
        }
    }
}
