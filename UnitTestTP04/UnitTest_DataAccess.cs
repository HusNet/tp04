using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TP04_Project.DataAccess;

namespace UnitTestTP04
{
    /* 
     * This is a test calss for the input and output
     * It will test all functionalities related the input and output
     * and the Interface which concerns them with NSubstitute
     */
    [TestClass]
    public class UnitTest_DataAccess
    {

        private TestContext testContextInstance;
        
        /*  
         *  Gets or sets the test context which provides
         *  information about and functionality for the current test run.
         */
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

        public TestContext TestContextInstance { get; set; }

        // instanciations of classes
        private Input input = new Input();
        private Output output = new Output();
        private InputManager inManager = new InputManager();
        private OutputManager outManager = new OutputManager();

        /*
         *  Testing input Dialog Title Getter/Setter
         */
        [TestMethod]
        public void TestInputDialogTitle()
        {
            var inOut = Substitute.For<IInterfaceInOut>();

            string newTitle = "New Title";

            inOut.GetDialogTitle().Returns<String>(newTitle);

            input.SetDialogTitle(newTitle);

            Assert.AreEqual(input.GetDialogTitle(), inOut.GetDialogTitle());

        }
        
        /*
         *  Testing input Dialog Filter Getter/Setter
         */
        [TestMethod]
        public void TestInputDialogFilter()
        {
            var inOut = Substitute.For<IInterfaceInOut>();

            string newFilter = "New Filter";

            inOut.GetDialogFilter().Returns<String>(newFilter);

            input.SetDialogFilter(newFilter);

            Assert.AreEqual(input.GetDialogFilter(), inOut.GetDialogFilter());
        }

        /*
         *  Testing output Dialog Title Getter/Setter
         */
        [TestMethod]
        public void TestOutputDialogTitle()
        {
            var inOut = Substitute.For<IInterfaceInOut>();

            string newTitle = "New Title";

            inOut.GetDialogTitle().Returns<String>(newTitle);

            output.SetDialogTitle(newTitle);

            Assert.AreEqual(output.GetDialogTitle(), inOut.GetDialogTitle());

        }

        /*
         *  Testing output Dialog Filter Getter/Setter
         */
        [TestMethod]
        public void TestOutputDialogFilter()
        {
            var inOut = Substitute.For<IInterfaceInOut>();

            string newFilter = "New Filter";

            inOut.GetDialogFilter().Returns<String>(newFilter);

            output.SetDialogFilter(newFilter);

            Assert.AreEqual(output.GetDialogFilter(), inOut.GetDialogFilter());
        }

        /*
         * User need to select an image in the interaction dialog box
         */
        [TestMethod]
        public void TestInputManagerloadImageFromDiskValidImage()
        {
            Assert.IsInstanceOfType(inManager.LoadImageFromDisk(input, new PictureBox()), typeof(Bitmap));
        }

        /*
         * User need to cancel the interaction dialog box
         */
        [TestMethod]
        public void TestInputManagerloadImageFromDiskUnvalidImage()
        {
            Assert.ThrowsException<Exception>(() => inManager.LoadImageFromDisk(input, new PictureBox()));
        }

        /*
         * User need to select an image in the interaction dialog box
         */
        [TestMethod]
        public void TestInputManagerGetOriginalImageFromFile()
        {
            inManager.LoadImageFromDisk(input, new PictureBox());
            Assert.IsInstanceOfType(inManager.GetOriginalImageFromFile(), typeof(Bitmap));
        }


        /*
         * User need select an image and to save the image in the interaction dialog box 
         * 
         * To cover 100% of code this method needs to be run 3 time with the 3 different formats in the output dialog box 
         */
        [TestMethod]
        public void TestOutputManagerSaveImageToDisk()
        {
            inManager.LoadImageFromDisk(input, new PictureBox());
            Bitmap image = inManager.GetOriginalImageFromFile();

            outManager.SaveImageToDisk(image, output);
        }
    }
}
