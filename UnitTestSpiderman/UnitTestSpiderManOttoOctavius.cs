using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprint2_Spiderman;
namespace UnitTestSpiderman
{
    /// <summary>
    /// Summary description for UnitTestSpiderManOttoOctavius
    /// </summary>
    [TestClass]
    public class UnitTestSpiderManOttoOctavius
    {
         Spiderman_Otto_Octavius oo;

        [TestMethod]
        public void Test_SpiderPeople_About()
        {
            //Arrange
            oo = new Spiderman_Otto_Octavius();
            //Act
            string testAbout = oo.About();
            //Assert
            Assert.AreEqual($"{oo.Name} has spider-based abilities \nWeb shooter with a capacity of {oo.MaxWebCount} uses, \nCurrent web count is: {oo.CurrentWebCount}", testAbout);

        }

        [TestMethod]
        public void Test_SpiderPeople_Web_Swing_not_ready()
        {
            //This test should not change the values because the web shooter isn't ready yet and also not prepared
            //Arrange
            oo = new Spiderman_Otto_Octavius();
            //Act
            int startingWebCount = oo.CurrentWebCount;
            oo.WebSwing();
            int after_one_web_swing = oo.CurrentWebCount;
            //Assert
            Assert.AreEqual(oo.MaxWebCount, startingWebCount);
            Assert.AreEqual(startingWebCount, after_one_web_swing);

        }

        [TestMethod]
        public void Test_SpiderPeople_Web_Swing_not_prepared()
        {
            //This should not change anything because the web shooter isn't prepared yet
            //Arrange
            oo = new Spiderman_Otto_Octavius();
            //Act
            int startingWebCount = oo.CurrentWebCount;
            oo.RefillWebShooter();
            oo.WebSwing();
            int after_one_swing_web_shooter_not_prepared = oo.CurrentWebCount;
            //Assert
            Assert.AreEqual(oo.MaxWebCount, startingWebCount);
            Assert.AreEqual(startingWebCount, after_one_swing_web_shooter_not_prepared);

        }

        [TestMethod]
        public virtual void Test_SpiderPeople_Web_Swing_ready_prepared()
        {
            //This should not change anything because the web shooter isn't prepared yet
            //Arrange
            oo = new Spiderman_Otto_Octavius();
            //Act
            int startingWebCount = oo.CurrentWebCount;
            oo.RefillWebShooter();
            oo.WebShooterPrepared();
            oo.WebSwing((oo.MaxWebCount + 1)); //this is to make sure the spider person can't swing webs exceeding their max web count
            int error_swing = oo.CurrentWebCount;
            oo.WebSwing(oo.CurrentWebCount);
            int final_swing =oo.CurrentWebCount;

            //Assert
            Assert.AreEqual(oo.MaxWebCount, startingWebCount);
            Assert.AreEqual(startingWebCount, error_swing);
            Assert.AreEqual(0, final_swing);
        }

        [TestMethod]
        public virtual void Test_SpiderPeople_Refill_WebShooter_After_Depletion()
        {
            //Arrange
            oo = new Spiderman_Otto_Octavius();
            //Act
            oo.RefillWebShooter();
            oo.WebShooterPrepared();
            oo.WebSwing(oo.MaxWebCount);
            int depleted_web_cartridge = oo.CurrentWebCount;
            oo.RefillWebShooter();
            int refilled_web_cartridge = oo.CurrentWebCount;
            //Assert
            Assert.AreEqual(0, depleted_web_cartridge);
            Assert.AreEqual(oo.MaxWebCount, refilled_web_cartridge);
        }

        [TestMethod]
        public virtual void Test_SpiderPeople_Refill_WebShooter()
        {
            //Assign
            oo = new Spiderman_Otto_Octavius();
            //Act
            bool defaultWebShooter = oo.WebCartridge.CartridgeInstalled;
            oo.RefillWebShooter();
            bool afterWebShooter = oo.WebCartridge.CartridgeInstalled;
            //Arrange
            Assert.AreEqual(false, defaultWebShooter);
            Assert.AreEqual(true, afterWebShooter);
        }

        [TestMethod]
        public virtual void TestSpiderPeopleEmptyWebShooter()
        {
            //Assign
            oo = new Spiderman_Otto_Octavius();
            //Act
            bool defaultWebShooter = oo.WebCartridge.CartridgeInstalled;
            oo.RefillWebShooter();
            oo.EmptyWebShooter();
            bool afterRemoveWebShooter = oo.WebCartridge.CartridgeInstalled;
            //Arrange
            Assert.AreEqual(false, defaultWebShooter);
            Assert.AreEqual(false, afterRemoveWebShooter);
        }

        [TestMethod]
        public virtual void TestSpiderPeopleWebShooterPrepared()
        {
            oo = new Spiderman_Otto_Octavius();
            //Act
            bool defaultWebShooterState = oo.WebShooterReady;
            oo.RefillWebShooter();
            bool refillWebShooter = oo.WebShooterReady;
            oo.WebShooterPrepared();
            bool finalWebShooter = oo.WebShooterReady;
            //Assert
            Assert.AreEqual(false, defaultWebShooterState);
            Assert.AreEqual(false, refillWebShooter);
            Assert.AreEqual(true, finalWebShooter);
        }

        [TestMethod]
        public void TestBuildSpiderBots()
        {
            //Arrange
            oo = new Spiderman_Otto_Octavius();
            //Act
            bool defaultSpiderBots = oo.SpiderBots;
            oo.BuildSpiderBots();
            bool afterSpiderBots = oo.SpiderBots;
            //Assert
            Assert.AreEqual(false, defaultSpiderBots);
            Assert.AreEqual(true, afterSpiderBots);
        }

        [TestMethod]
        public void TestDestroySpiderBots()
        {
            //Arrange
            oo = new Spiderman_Otto_Octavius();
            //Act
            bool defaultSpiderBots = oo.SpiderBots;
            oo.BuildSpiderBots();
            oo.DestroySpiderBots();
            bool afterSpiderBots = oo.SpiderBots;
            //Assert
            Assert.AreEqual(false, defaultSpiderBots);
            Assert.AreEqual(false, afterSpiderBots);
        }

        [TestMethod]
        public void TestDeploySpiderBots()
        {
            //Arrange
            oo = new Spiderman_Otto_Octavius();
            //Act
            string defaultBotString = oo.DeploySpiderBots();
            oo.BuildSpiderBots();
            string afterSpiderBots = oo.DeploySpiderBots();
            //Assert
            Assert.AreEqual("The spider bots are not readyy", defaultBotString);
            Assert.AreEqual(oo.Name + " throws out some spider bots.", afterSpiderBots);
        }

        [TestMethod]
        public void Test_SpiderPeople_Constructor()
        {
            //Arrange
            oo = new Spiderman_Otto_Octavius();
            //Act
            //Assert
            Assert.AreEqual(false, oo.WebShooterReady);
            Assert.AreEqual(oo.MaxWebCount, oo.CurrentWebCount);
            Assert.AreEqual("Otto Octavius", oo.Name);
        }
    }
}
