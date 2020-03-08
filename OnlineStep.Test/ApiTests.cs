using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineStep.Helpers;
using OnlineStep.Models;
using OnlineStep.ViewModels;
using OnlineStep.Views;

namespace OnlineStep.Test

{
    [TestClass]
    public class DbHelperTest
    {

        [TestMethod]
        public void ClozeSentenceTest()
        {

            /*
             * Test if split method works in ClozeViewModel
             */

            //Arrenge
            string sentence = "Här kommer ett test";
            List<string> missingWords = new List<string>();
            missingWords.Add("test");
            missingWords.Add("en helt värdelös sträng");
            ClozeViewModel clozeViewModel = new ClozeViewModel();

            //Act
            string[] sentences = clozeViewModel.SplitSentence(sentence, missingWords);

            //Assert
            Assert.AreEqual("Här kommer ett ", sentences[0]);
            Assert.AreEqual("", sentences[1]);

        }

        [TestMethod]
        public void ClozePlaceholderTest()
        {

            /*
             * Test if split method works in ClozeViewModel
             */

            //Arrenge
            string missingWord = "Missingword";
   
            ClozeViewModel clozeViewModel = new ClozeViewModel();

            //Act
            
            string placeholder = clozeViewModel.CreatePlaceholder(missingWord);

            //Assert
            Assert.AreEqual("___________", placeholder);

        }

        [TestMethod]
        public void ChapterLevelTest()
        {
            /*
             * Test if the number of pages are correct from the API
             */

            //Arrange
            DbHelper dbHelper = new DbHelper();
            String courserID = "5e3bd92155de5958085644e3";
            List<ChapterLevels> listOfChapters = new List<ChapterLevels>();

            //Act 
            listOfChapters = dbHelper.GetChaptersByLevel(courserID);


            Debug.WriteLine(listOfChapters[0].ChapterList.Count);
            Debug.WriteLine(listOfChapters[1].ChapterList.Count);
            Debug.WriteLine(listOfChapters[2].ChapterList.Count);
            Debug.WriteLine(listOfChapters[3].ChapterList.Count);

            Debug.WriteLine(listOfChapters[3].ChapterList[0].Name);
            Debug.WriteLine(listOfChapters[3].ChapterList[1].Name);

            Debug.WriteLine("Size");
            Debug.WriteLine(listOfChapters.Count);

            //Assert
            Assert.AreEqual( 1, listOfChapters[0].Level);
        }


        [TestMethod]
        public void PagesApiRequestTest()
        {
            /*
             * Test if the number of pages are correct from the API
             */

            //Arrange
            DbHelper dbHelper = new DbHelper();
            String chapterID = "5e3950a2dd22b950349ee26b";
            List<IPage> pageList = new List<IPage>();


            //Act 
            pageList = dbHelper.GetPages(chapterID);
            Debug.WriteLine(pageList.Count);

            //Assert 

            Assert.AreEqual(2, pageList.Count);
        }

        [TestMethod]
        public void PageTypeTest()
        {

            /*
            * Test the type of pages returned from the API
            */

            //Arrange
            DbHelper dbHelper = new DbHelper();
            String chapterID = "5e3950a2dd22b950349ee26b";
            List<IPage> pageList = new List<IPage>();

            //Act 
            pageList = dbHelper.GetPages(chapterID);

            //Assert 

            foreach (var page in pageList)
            {
                Trace.WriteLine("id: " + page._id + "  type: " + page.type);
            }

            Assert.AreEqual("cloze", pageList[0].type);
            Assert.AreEqual("mcq", pageList[1].type);

        }
        [TestMethod]
        public void PageContentTest()
        {

            /*
            * Test the type of pages returned from the API
            */

            //Arrange
            DbHelper dbHelper = new DbHelper();
            String chapterID = "5e3950a2dd22b950349ee26b";
            List<IPage> pageList = new List<IPage>();

            //Act 
            pageList = dbHelper.GetPages(chapterID);

            //Assert 

           
            Cloze cloze = (Cloze) pageList[0];
            Assert.AreEqual("Erik bor i Borlänge", cloze.content.sentence);
            Assert.AreEqual("mcq", pageList[1].type);

        }
    }
}
