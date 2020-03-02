using OnlineStep.Helpers;
using OnlineStep.Models;
using OnlineStep.Navigation.Interfaces;
using OnlineStep.Services;
using System.Collections.Generic;
using System.Diagnostics;
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


        public ChapterViewModel(INavigator navigator)
        {

            InitAsyncApiRequest();

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
            foreach (var chapter in ChapterList)
            {
                if (ChapterLevelsList.Count == 0)
                {
                    List<Chapter> chapList = new List<Chapter>();
                    chapList.Add(chapter);
                    ChapterLevels chapLvl = new ChapterLevels { ChapterList = chapList, Level = chapter.Level };

                    ChapterLevelsList.Add(chapLvl);
                    Debug.WriteLine("ChapterLevelsList == null" + ChapterLevelsList[0]);
                }
                
                    foreach (var level in ChapterLevelsList)
                    {
                        Debug.WriteLine("For each level");
                        if (chapter.Level.Equals(level.Level))
                        {
                            Debug.WriteLine("For each level: IF");
                            level.ChapterList.Add(chapter);
                        }
                        else
                        {

                            List<Chapter> chapList = new List<Chapter>();
                            chapList.Add(chapter);
                            ChapterLevels chapLvl = new ChapterLevels { ChapterList = chapList, Level = chapter.Level };

                            ChapterLevelsList.Add(chapLvl);
                            Debug.WriteLine("For each level: ELSE");
                        }
                    }
                
            }
            //foreach (var item in ChapterLevelsList)
            //{
            //    Debug.WriteLine("THE ONE AND ONLY DEBUG" + item.Level);
            //}
            Debug.WriteLine("ChapterLevelDistributor END");

        }
        public ICommand GoToPageView => new Command((id) =>
        {
            List<Models.Page.RootObject> pageList = new List<Models.Page.RootObject>();
            pageList = dbHelper.GetPages(id.ToString());
            var objList = pageList.ConvertAll(x => (object)x);
            DataCenter.CreateListProcedure("SetPageList", objList);

            PageNavigator.pageList = dbHelper.GetPages(id.ToString());
            PageNavigator.PushNextPage(_navigator);
        });

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
    }
}
