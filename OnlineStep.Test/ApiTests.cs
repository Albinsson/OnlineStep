using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineStep.Helpers;
using OnlineStep.Models;

namespace OnlineStep.Test

{
    [TestClass]
    public class DbHelperTest
    {
        [TestMethod]
        public void ChapterLevelTest()
        {
            /*
             * Test if the number of pages are correct from the API
             */

            //Arrange
            DbHelper dbHelper = new DbHelper();
            String courserID = "5e3bd92155de5958085644e3";
            List<List<Chapter>> listOfChapters = new List<List<Chapter>>();



            //Act 

            listOfChapters = dbHelper.GetChaptersByLevel(courserID);


            Debug.WriteLine(listOfChapters[0].Count);
            Debug.WriteLine(listOfChapters[1].Count);
            Debug.WriteLine(listOfChapters[2].Count);
            Debug.WriteLine(listOfChapters[3].Count);

            Debug.WriteLine(listOfChapters[3][0].Name);
            Debug.WriteLine(listOfChapters[3][1].Name);

            Debug.WriteLine("Size");
            Debug.WriteLine(listOfChapters.Count);

            //Assert

            Assert.AreEqual( 1, listOfChapters[0].Count);
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
            List<Models.Page.RootObject> pageList = new List<Page.RootObject>();


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
            List<Models.Page.RootObject> pageList = new List<Page.RootObject>();

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
    }
}
