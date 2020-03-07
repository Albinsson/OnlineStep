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
            UserProgress.Xp = 10;
            UserProgress.Xp = 10;
            UserProgress.Xp = 10;


            //Act
            int result = UserProgress.Xp;

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
            UserProgress.maxScore = 5;
            UserProgress.highestScore = 2;
            Trace.WriteLine("maxScore" + UserProgress.maxScore);
            
            UserProgress.AddPageResult(true);
            UserProgress.AddPageResult(true);
            UserProgress.AddPageResult(false);
            UserProgress.AddPageResult(false);
            UserProgress.AddPageResult(true);



            //Act
            UserProgress.AddChapterResult();
            double results = UserProgress.highestScoreProcentage;


            //Assert
            Assert.AreEqual(0.6, results);

        }

    }
}
