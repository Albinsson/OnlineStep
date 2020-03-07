using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineStep.Helpers;
using OnlineStep.Models;
using OnlineStep.Services;
using OnlineStep.ViewModels;
using OnlineStep.Views;

namespace OnlineStep.Test

{
    [TestClass]
    public class GameificationTest
    {

        [TestMethod]
        public void AddXpTest()
        {

            /*
             * Test adding XP to Gamification 
             */

            //Arrange
            Gamification.Xp = 10;
            Gamification.Xp = 10;
            Gamification.Xp = 10;


            //Act
            int result = Gamification.Xp;

            //Assert
            Assert.AreEqual(30, result);

        }

        [TestMethod]
        public void AddPageResult()
        {

            /*
             * Test adding PageResult to Gamification 
             */

            //Arrange
            Gamification.maxScore = 5;
            Gamification.highestScore = 2;
            Trace.WriteLine("maxScore" + Gamification.maxScore);
            
            Gamification.AddPageResult(true);
            Gamification.AddPageResult(true);
            Gamification.AddPageResult(false);
            Gamification.AddPageResult(false);
            Gamification.AddPageResult(true);



            //Act
            Gamification.AddChapterResult();
            double results = Gamification.highestScoreProcentage;


            //Assert
            Assert.AreEqual(0.6, results);

        }

    }
}
