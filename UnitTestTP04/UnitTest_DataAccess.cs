using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TP04_Project.DataAccess;

namespace UnitTestTP04
{
    [TestClass]
    public class UnitTest_DataAccess
    {

        private TestContext testContextInstance;

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

        private Input input = new Input();
        private Output output = new Output();
        private InputManager inManager = new InputManager();
        private OutputManager outManager = new OutputManager();


        [TestMethod]
        public void TestInputDialogTitle()
        {
            var inOut = Substitute.For<IInterfaceInOut>();

            string newTitle = "New Title";

            inOut.GetDialogTitle().Returns<String>(newTitle);

            input.SetDialogTitle(newTitle);

            Assert.AreEqual(input.GetDialogTitle(), inOut.GetDialogTitle());

        }

        [TestMethod]
        public void TestInputDialogFilter()
        {
            var inOut = Substitute.For<IInterfaceInOut>();

            string newFilter = "New Filter";

            inOut.GetDialogFilter().Returns<String>(newFilter);

            input.SetDialogFilter(newFilter);

            Assert.AreEqual(input.GetDialogFilter(), inOut.GetDialogFilter());
        }


        [TestMethod]
        public void TestOutputDialogTitle()
        {
            var inOut = Substitute.For<IInterfaceInOut>();

            string newTitle = "New Title";

            inOut.GetDialogTitle().Returns<String>(newTitle);

            output.SetDialogTitle(newTitle);

            Assert.AreEqual(output.GetDialogTitle(), inOut.GetDialogTitle());

        }

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
         * Run it 3 times with the 3 different formats to test it 100%
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
