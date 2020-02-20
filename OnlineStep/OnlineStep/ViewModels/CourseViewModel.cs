using OnlineStep.Models;
using OnlineStep.Services;
using System;
using System.Collections.Generic;

using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using OnlineStep.Helpers;
using OnlineStep.Navigation.Interfaces;
using Xamarin.Forms;

namespace OnlineStep.ViewModels
{
    internal class CourseViewModel : BaseViewModel
    {
        private List<Course> courseList;
        //public StackLayout _id { get; set; }
        private readonly INavigator _navigator;

  
        public CourseViewModel(INavigator navigator)
        {
            Debug.WriteLine("public CourseViewModel(INavigator navigator)");
            InitAsyncApiRequest();
            _navigator = navigator;
        }
        //TODO: Rename me
        public void InitAsyncApiRequest()
        {
            Debug.WriteLine("Hello");
            DbHelper dbHelper = new DbHelper();
            courseList = dbHelper.GetCourses();
            Debug.WriteLine(courseList.Count);

        }

        public ICommand GoToChapterView => new Command<string>((id) =>
        {
            Debug.WriteLine("Going to course: " + id);
            CurrentCourseID = id;
            Test = "Set from course view model";
            Debug.WriteLine("Course id set to : " + CurrentCourseID);

            ///_navigator.PushAsync<DeleteMeViewModel>();

            _navigator.PushAsync<DeleteMeViewModel>();
            //_navigator.PopAsync();
            

            Debug.WriteLine("_navigator.PushAsync<ChapterViewModel>();" + id);
        });

        public List<Course> CourseList
        {
            get => courseList;
            set => courseList = value;
        }

        //public ICommand SetCurrentChapterId
        //{
        //    get
        //    {
        //        return new Command<string>((x) => CurrentCourseID = (x));
        //    }
        //}

        //public String SetChapterId
        //{
        //    set => CurrentCourseID = value;
        //}
        

    }
};

