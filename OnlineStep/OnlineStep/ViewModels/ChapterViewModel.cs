using OnlineStep.Helpers;
using OnlineStep.Models;
using OnlineStep.Navigation.Interfaces;
using OnlineStep.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;




namespace OnlineStep.ViewModels
{
    class ChapterViewModel : BaseViewModel
    {

        private List<Chapter> chapterList;
        private readonly DbHelper dbHelper = new DbHelper();
        private readonly INavigator _navigator;
        private Data Data;
        private List<ChapterLevels> chapterLevelsList;

        private List<ChapterLevels> chapterLevels;

        public List<ChapterLevels> ChapterLevels
        {
            get => chapterLevels;
            set => chapterLevels = value;
        }

        private void Init()
        {
            Data = DataCenter.GetSingletonProcedure("GetChapterID");
            chapterLevels = dbHelper.GetChaptersByLevel(Data.Obj.ToString());
        }

        public List<Chapter> ChapterList
        {
            get => chapterList;
            set => chapterList = value;
        }

        public List<ChapterLevels> ChapterLevelsList
        {
            get => chapterLevelsList;
            set => chapterLevelsList = value;
        }

        public ChapterViewModel(INavigator navigator)
        {

            //InitAsyncApiRequest();

            Init();

            _navigator = navigator;
        }

    

        public void InitAsyncApiRequest()
        {
            Data = DataCenter.GetSingletonProcedure("GetChapterID");
            ChapterList = dbHelper.GetChapters(Data.Obj.ToString());
            var objList = ChapterList.ConvertAll(x => (object)x);
            DataCenter.CreateListProcedure("SetChapters", objList);
            Debug.WriteLine(ChapterList.Count);
            ChapterLevelDistributor();
        }

        void ChapterLevelDistributor()
        {
            ChapterLevelsList = new List<ChapterLevels>();
            int index = 1;
            foreach (var c in ChapterList.Where(c => c.Level.Equals(index.ToString())))
            {
                Chapter chap = new Chapter { Author = c.Author, Level = c.Level, Name = c.Name, Pages = c.Pages, Subject = c.Subject, Subjects = c.Subjects, _id = c._id, __v = c.__v };
                List<Chapter> cList = new List<Chapter> { chap };
                ChapterLevels cListLevel = new ChapterLevels { ChapterList = cList, Level = index.ToString() };
                chapterLevelsList.Add(cListLevel);
                index++;               
            }
            ChapterLevelsList.ForEach(i => Console.WriteLine(i.ChapterList.Count));
            Debug.WriteLine("ChapterLevelList count: " + ChapterLevelsList.Count);
            Debug.WriteLine(ChapterLevelsList[0].ChapterList[0].Name);
        }


        //void ChapterLevelDistributor()
        //{
        //    ChapterLevelsList = new List<ChapterLevels>();
        //    foreach (var chapter in ChapterList)
        //    {
        //        if (ChapterLevelsList.Count == 0)
        //        {
        //            List<Chapter> chapList = new List<Chapter>();
        //            chapList.Add(chapter);
        //            ChapterLevels chapLvl = new ChapterLevels { ChapterList = chapList, Level = chapter.Level };

        //            ChapterLevelsList.Add(chapLvl);
        //            Debug.WriteLine("ChapterLevelsList == null" + ChapterLevelsList[0]);
        //        }

        //            foreach (var level in ChapterLevelsList)
        //            {
        //                Debug.WriteLine("For each level");
        //                if (chapter.Level.Equals(level.Level))
        //                {
        //                    Debug.WriteLine("For each level: IF");
        //                    level.ChapterList.Add(chapter);
        //                }
        //                else
        //                {

        //                    List<Chapter> chapList = new List<Chapter>();
        //                    chapList.Add(chapter);
        //                    ChapterLevels chapLvl = new ChapterLevels { ChapterList = chapList, Level = chapter.Level };

        //                    ChapterLevelsList.Add(chapLvl);
        //                    Debug.WriteLine("For each level: ELSE");
        //                }
        //            }

        //    }
        //    //foreach (var item in ChapterLevelsList)
        //    //{
        //    //    Debug.WriteLine("THE ONE AND ONLY DEBUG" + item.Level);
        //    //}
        //    Debug.WriteLine("ChapterLevelDistributor END");

        //}
        public ICommand GoToPageView => new Command((id) =>
        {
            List<Models.Page.RootObject> pageList = new List<Models.Page.RootObject>();
            pageList = dbHelper.GetPages(id.ToString());
            var objList = pageList.ConvertAll(x => (object)x);
            DataCenter.CreateListProcedure("SetPageList", objList);

            PageNavigator.pageList = dbHelper.GetPages(id.ToString());
            PageNavigator.PushNextPage(_navigator);
        });


    }
}
