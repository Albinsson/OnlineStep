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


        public ChapterViewModel(INavigator navigator)
        {
            Debug.WriteLine("ChapterViewModel Constructor");
            
            InitAsyncApiRequest();
            _navigator = navigator;
        }

        public void InitAsyncApiRequest()
        {
            var chapterID = Preferences.Get("chapterID", "default_value");
            ChapterList = dbHelper.GetChapters(chapterID);
            Debug.WriteLine(ChapterList.Count);
        }

        public ICommand GoToNextView => new Command((id) =>
        {
            
            _navigator.PushAsync<CourseViewModel>();
        });

        public List<Chapter> ChapterList
        {
            get => chapterList;
            set => chapterList = value;
        }
    }
}
