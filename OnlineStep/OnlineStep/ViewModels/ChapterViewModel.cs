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
        private readonly DbHelper dbHelper = new DbHelper();
        private readonly INavigator _navigator;


        public ChapterViewModel(INavigator navigator)
        {
            Debug.WriteLine("public ChapterViewModel(INavigator navigator)");
            InitAsyncApiRequest();
            _navigator = navigator;
        }

        public void InitAsyncApiRequest()
        {
            ChapterList = dbHelper.GetChapters(CurrentCourseID);
            Debug.WriteLine(ChapterList.Count);
            //try
            //{
            //    if (CurrentCourseID == String.Empty) { throw new ArgumentException("CurrentCourseID cannot be null or empty string");}

            //    Debug.WriteLine("InitAsyncApiRequest()");
            //    var temp = RestClient.GetChaptersAsync(CurrentCourseID);
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
