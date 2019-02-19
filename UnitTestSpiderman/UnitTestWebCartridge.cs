using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprint2_Spiderman;
namespace UnitTestSpiderman
{
    /// <summary>
    /// Summary description for UnitTestWebCartridge
    /// </summary>
    [TestClass]
    public class UnitTestWebCartridge
    {
        WebCartridge web; 

        [TestMethod]
        public void TestWebCartridgeConstructor()
        {
            //Arrange
            web = new WebCartridge();
            //Act
            //Assert
            Assert.AreEqual(false, web.CartridgeInstalled);
        }

        [TestMethod]
        public void TestWebCartridgeAbout()
        {
            //Arrange
            web = new WebCartridge();
            //Act
            string defaultWebCartridgeState = web.About();
            web.InsertWebCartridge();
            string afterWebCartridgeState = web.About();

            //Assert
            Assert.AreEqual("Web cartridge is not inserted", defaultWebCartridgeState);
            Assert.AreEqual("Web Cartridge is inserted", afterWebCartridgeState);
        }

        [TestMethod]
        public void TestInsertWebCartridge()
        {
            //Arrange
            web = new WebCartridge();
            //Act
            bool defaultWebCartridgeState = web.CartridgeInstalled;
            web.InsertWebCartridge();
            bool afterInsertWebCartridge = web.CartridgeInstalled;
            //Assert
            Assert.AreEqual(false, defaultWebCartridgeState);
            Assert.AreEqual(true, afterInsertWebCartridge);
            
        }

        [TestMethod]
        public void TestRemoveWebCartridge()
        {
            //Arrange
            web = new WebCartridge();
            //Act
            bool defaultWebCartridgeState = web.CartridgeInstalled;
            web.InsertWebCartridge();
            bool afterInsertWebCartridge = web.CartridgeInstalled;
            web.RemoveWebCartridge();
            bool finalRemoveWebCartridge = web.CartridgeInstalled;
            //Assert
            Assert.AreEqual(false, defaultWebCartridgeState);
            Assert.AreEqual(true, afterInsertWebCartridge);
            Assert.AreEqual(false, finalRemoveWebCartridge);
        }



    }
}
