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
