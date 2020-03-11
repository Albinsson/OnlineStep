using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OnlineStep.Helpers;
using OnlineStep.Models;
using OnlineStep.Services;
using OnlineStep.ViewModels;
using OnlineStep.Views;
using Refit;

namespace OnlineStep.Test

{
    [TestClass]
    public class DataCenterTest
    {

        [TestMethod]
        public async System.Threading.Tasks.Task FetchPagesTest()
        {

            /*
             * Fetching pages
             */

            ////Arrenge
            //string chapterId = "5e3950a2dd22b950349ee26b";
            //ApiFetcher apiFetcher = new ApiFetcher();
            //List<IPage> pages = new List<IPage>();
            //ChapterViewModel chapterViewModel = new ViewModels.ChapterViewModel();

            ////Act
            //pages = await chapterViewModel.LoadPages(chapterId);
            ////Assert
            //Assert.AreEqual(pages[0]._id, "5e3945833596e0389ccc1c2b");

        }
        [TestMethod]
        public async System.Threading.Tasks.Task FetchChaptersTest()
        {

            /*
             * Fetching chapters
             */

            //Arrenge
            string courseId = "5e3bd92155de5958085644e3";
            ApiFetcher apiFetcher = new ApiFetcher();
            List<ChapterLevels> chapterLevels = new List<ChapterLevels>();

            //Act
            chapterLevels = await apiFetcher.FetchChapters(courseId);


            //Assert
            Assert.AreEqual(chapterLevels[0].ChapterList[0]._id, "5e3976792e6b5d4ee4a2956f");

        }
    }
}
