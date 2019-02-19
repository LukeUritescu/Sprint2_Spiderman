using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprint2_Spiderman;

namespace UnitTestSpiderman
{
    /// <summary>
    /// Summary description for UnitTestPeterParker
    /// </summary>
    [TestClass]
    public class UnitTestPeterParker
    {
        PeterParker pp;

        [TestMethod]
        public void Test_SpiderPeople_About()
        {
            //Arrange
            pp = new PeterParker();
            //Act
            string testAbout = pp.About();
            //Assert
            Assert.AreEqual($"{pp.Name} has spider-based abilities \nWeb shooter with a capacity of {pp.MaxWebCount} uses, \nCurrent web count is: {pp.CurrentWebCount}", testAbout);

        }

        [TestMethod]
        public void Test_SpiderPeople_Constructor()
        {
            //Arrange
            pp = new PeterParker();
            //Act
            //Assert
            Assert.AreEqual(false, pp.WebShooterReady);
            Assert.AreEqual(pp.MaxWebCount, pp.CurrentWebCount);
        }

        [TestMethod]
        public void Test_SpiderPeople_Web_Swing_not_ready()
        {
            //This test should not change the values because the web shooter isn't ready yet and also not prepared
            //Arrange
            pp = new PeterParker();
            //Act
            int startingWebCount = pp.CurrentWebCount;
            pp.WebSwing();
            int after_one_web_swing = pp.CurrentWebCount;
            //Assert
            Assert.AreEqual(pp.MaxWebCount, startingWebCount);
            Assert.AreEqual(startingWebCount, after_one_web_swing);

        }

        [TestMethod]
        public void Test_SpiderPeople_Web_Swing_not_prepared()
        {
            //This should not change anything because the web shooter isn't prepared yet
            //Arrange
            pp = new PeterParker();
            //Act
            int startingWebCount = pp.CurrentWebCount;
            pp.RefillWebShooter();
            pp.WebSwing();
            int after_one_swing_web_shooter_not_prepared = pp.CurrentWebCount;
            //Assert
            Assert.AreEqual(pp.MaxWebCount, startingWebCount);
            Assert.AreEqual(startingWebCount, after_one_swing_web_shooter_not_prepared);

        }

        [TestMethod]
        public virtual void Test_SpiderPeople_Web_Swing_ready_prepared()
        {
            //This should not change anything because the web shooter isn't prepared yet
            //Arrange
            pp = new PeterParker();
            //Act
            int startingWebCount = pp.CurrentWebCount;
            pp.RefillWebShooter();
            pp.WebShooterPrepared();
            pp.WebSwing((pp.MaxWebCount + 1)); //this is to make sure the spider person can't swing webs exceeding their max web count
            int error_swing = pp.CurrentWebCount;
            pp.WebSwing(pp.CurrentWebCount);
            int final_swing = pp.CurrentWebCount;

            //Assert
            Assert.AreEqual(pp.MaxWebCount, startingWebCount);
            Assert.AreEqual(startingWebCount, error_swing);
            Assert.AreEqual(0, final_swing);
        }

        /// <summary>
        /// Test if the web shooter gets properly replenished
        /// </summary>
        [TestMethod]
        public virtual void Test_SpiderPeople_Refill_WebShooter_After_Depletion()
        {
            //Arrange
            pp = new PeterParker();
            //Act
            pp.RefillWebShooter();
            pp.WebShooterPrepared();
            pp.WebSwing(pp.MaxWebCount);
            int depleted_web_cartridge = pp.CurrentWebCount;
            pp.RefillWebShooter();
            int refilled_web_cartridge = pp.CurrentWebCount;
            //Assert
            Assert.AreEqual(0, depleted_web_cartridge);
            Assert.AreEqual(pp.MaxWebCount, refilled_web_cartridge);
        }

        [TestMethod]
        public virtual void Test_SpiderPeople_Refill_WebShooter()
        {
            //Assign
            pp = new PeterParker();
            //Act
            bool defaultWebShooter = pp.WebCartridge.CartridgeInstalled;
            pp.RefillWebShooter();
            bool afterWebShooter = pp.WebCartridge.CartridgeInstalled;
            //Arrange
            Assert.AreEqual(false, defaultWebShooter);
            Assert.AreEqual(true, afterWebShooter);
        }

        [TestMethod]
        public virtual void TestSpiderPeopleEmptyWebShooter()
        {
            //Assign
            pp = new PeterParker();
            //Act
            bool defaultWebShooter = pp.WebCartridge.CartridgeInstalled;
            pp.RefillWebShooter();
            pp.EmptyWebShooter();
            bool afterRemoveWebShooter = pp.WebCartridge.CartridgeInstalled;
            //Arrange
            Assert.AreEqual(false, defaultWebShooter);
            Assert.AreEqual(false, afterRemoveWebShooter);
        }

        [TestMethod]
        public virtual void TestSpiderPeopleWebShooterPrepared()
        {
            pp = new PeterParker();
            //Act
            bool defaultWebShooterState = pp.WebShooterReady;
            pp.RefillWebShooter();
            bool refillWebShooter = pp.WebShooterReady;
            pp.WebShooterPrepared();
            bool finalWebShooter = pp.WebShooterReady;
            //Assert
            Assert.AreEqual(false, defaultWebShooterState);
            Assert.AreEqual(false, refillWebShooter);
            Assert.AreEqual(true, finalWebShooter);
        }

        [TestMethod]
        public void Test_PeterParker_Constructor()
        {
            //Arrange
             PeterParker pp = new PeterParker();
            //Act
            //Assert
            Assert.AreEqual(false, pp.WebShooterReady);
            Assert.AreEqual(pp.MaxWebCount, pp.CurrentWebCount);
            Assert.AreEqual("Peter Parker", pp.Name);
        }
    }
}