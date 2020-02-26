using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using OnlineStep.Helpers;
using OnlineStep.Models;
using OnlineStep.Navigation.Interfaces;
using OnlineStep.Services;
using Xamarin.Essentials;
using Xamarin.Forms;




namespace OnlineStep.ViewModels
{
    class ChapterViewModel : BaseViewModel
    {

        private List<Chapter> chapterList;
        private readonly DbHelper dbHelper = new DbHelper();
        private readonly INavigator _navigator;
        private Data Data;


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
    }
}
