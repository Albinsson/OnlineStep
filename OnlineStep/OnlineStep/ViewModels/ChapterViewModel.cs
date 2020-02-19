using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using OnlineStep.Helpers;
using OnlineStep.Models;
using OnlineStep.Navigation.Interfaces;
using OnlineStep.Services;
using Xamarin.Forms;

namespace OnlineStep.ViewModels
{
    class ChapterViewModel : BaseViewModel
    {

        private List<Chapter> chapterList;
        private DbHelper dbHelper;
        private readonly INavigator _navigator;

        public ChapterViewModel()
        {
            Debug.WriteLine("ChapterViewModel()");
            Debug.WriteLine(CurrentChapterID);

            //Task.Run(async () => { await InitAsyncApiRequest(); }).Wait();
            dbHelper = new DbHelper();
        }

        public ChapterViewModel(INavigator navigator)
        {
            Debug.WriteLine("public MainViewModel(INavigator navigator)");
            InitAsyncApiRequest();
            _navigator = navigator;
        }

        public void InitAsyncApiRequest()
        {
            ChapterList = dbHelper.GetChapters(CurrentChapterID);
            Debug.WriteLine(ChapterList.Count);
            //try
            //{
            //    if (CurrentChapterID == String.Empty) { throw new ArgumentException("CurrentChapterID cannot be null or empty string");}

            //    Debug.WriteLine("InitAsyncApiRequest()");
            //    var temp = RestClient.GetChaptersAsync(CurrentChapterID);
            //    chapterList = await temp;
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine("InitAsyncApiRequest()");
            //    Debug.WriteLine(ex);

            //}
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
