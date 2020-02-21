using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineStep.Helpers;
using OnlineStep.Models;
using OnlineStep.Services;


namespace OnlineStep.Test
{
    [TestClass]
    public class PageNavigationTest
    {
        [TestMethod]
        public void GetIndex()
        {
            //Arrange
            PageNavigator pageNavigator = new PageNavigator();

            //Act 
            int size = pageNavigator.GetSize;
            Trace.WriteLine("Size: " + size);

            //Assert 
            Assert.AreEqual(2, size);


            
        }
        [TestMethod]
        public void GetNextPage()
        {
            //Arrange
            PageNavigator pageNavigator = new PageNavigator();

            //Act 
            Trace.WriteLine("Index: " + pageNavigator.GetIndex);
            Models.Page.RootObject page = pageNavigator.LoadNextPage();
            Trace.WriteLine("Index: " + pageNavigator.GetIndex);
            Trace.WriteLine("Page.type: " + page.type);

            //Assert 
            Assert.AreEqual("mcq", page.type);
        }
    }
}

