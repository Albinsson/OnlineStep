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
        private DataCenter DataCenter;
        private Data Data;


        public ChapterViewModel(INavigator navigator)
        {
            Debug.WriteLine("ChapterViewModel Constructor");           
            DataCenter = DataCenterFactory.GetDataCenter("CourseViewModel");
            Debug.WriteLine("After DataCenter");
            InitAsyncApiRequest();
            _navigator = navigator;
        }

        public void InitAsyncApiRequest()
        {
            //var chapterID = Preferences.Get("chapterID", "default_value");
            Data = DataCenter.GetProcedure("SetChapterID");
            ChapterList = dbHelper.GetChapters(Data.Obj.ToString());
            Debug.WriteLine(ChapterList.Count);
        }

        public ICommand GoToPageView => new Command((id) =>
        {
            List<Models.Page.RootObject> pageList = new List<Models.Page.RootObject>();
            pageList = dbHelper.GetPages(id.ToString());
            
            _navigator.PushAsync<PageViewModel>();
        });

        public List<Chapter> ChapterList
        {
            get => chapterList;
            set => chapterList = value;
        }
    }
}
