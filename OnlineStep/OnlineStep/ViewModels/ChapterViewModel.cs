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
        public ChapterViewModel(INavigator navigator)
        {
            Init();
            _navigator = navigator;
        }
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
