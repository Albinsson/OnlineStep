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
    public class ClozeTest
    {

        [TestMethod]
        public void ClozeSentenceSplit()
        {

            /*
             * Test adding XP to Gamification 
             */

            //Arrange
            string missingWord = "project";
            string sentence = "Severity Code description project file line suppression state";
            ClozeViewModel clozeViewModel = new ClozeViewModel();





            //Act
            List<ClozeRow> displayCloze = clozeViewModel.InitCloze(missingWord, sentence);

            foreach (var row in displayCloze)
            {
                Trace.WriteLine(row.SentenceFirstPart);
                Trace.WriteLine(row.EntryLenght);
                Trace.WriteLine(row.SentenceSecondPart);
            }

            //Assert
            Assert.AreEqual(2, displayCloze.Count);

        }

    }
}
