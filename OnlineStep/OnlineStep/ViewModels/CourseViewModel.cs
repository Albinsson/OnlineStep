using OnlineStep.Models;
using OnlineStep.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using OnlineStep.Helpers;
using OnlineStep.Navigation.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace OnlineStep.ViewModels
{
    internal class CourseViewModel : BaseViewModel
    {
        private List<Course> courseList;
        private readonly INavigator _navigator;

  
        public CourseViewModel(INavigator navigator)
        {
            InitAsyncApiRequest();
            _navigator = navigator;
        }
        //TODO: Rename me
        public void InitAsyncApiRequest()
        {
            DbHelper dbHelper = new DbHelper();
            courseList = dbHelper.GetCourses();
            Debug.WriteLine(courseList.Count);

        }

        public ICommand GoToChapterView => new Command<string>((id) =>
        {

            Preferences.Set("chapterID", id);
            var chapterID = Preferences.Get("chapterID", "default_value");
            _navigator.PushAsync<ChapterViewModel>();

        });

        public List<Course> CourseList
        {
            get => courseList;
            set => courseList = value;
        }

    }
};

