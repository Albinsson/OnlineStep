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
        public StackLayout _id { get; set; }
        private readonly INavigator _navigator;

        //public Command GoToNextView
        //{
        //    get
        //    {
        //        return new Command((() =>
        //        {
        //            string courseId = _id.ClassId;
        //            _navigator.PushAsync<ChapterViewModel>();
        //        }));
        //    }
        //}


        //public CourseViewModel()
        //{
        //    Debug.WriteLine("CourseViewModel()"); 
        //    //Task.Run(async () => { await InitAsyncApiRequest(); }).Wait();
            
            
        //}
        public CourseViewModel(INavigator navigator)
        {
            Debug.WriteLine("public MainViewModel(INavigator navigator)");
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
            //try
            //{
            //    Debug.WriteLine("InitAsyncApiRequest()");
            //    var temp = RestClient.GetCoursesAsync();
            //    courseList = await temp;
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine("InitAsyncApiRequest()");
            //    Debug.WriteLine(ex);
            //}
        }

        public ICommand GoToChapterView => new Command((id) =>
        {
            Debug.WriteLine("Going to chapter: " + id);
            _navigator.PushAsync<ChapterViewModel>();
        });

        public List<Course> CourseList
        {
            get => courseList;
            set => courseList = value;
        }

        public ICommand SetCurrentChapterId
        {
            get
            {
                return new Command<string>((x) => CurrentChapterID = (x));
            }
        }

        public String SetChapterId
        {
            set => CurrentChapterID = value;
        }
      
        //public ICommand GoToNextView => new Command(() =>
        //{
        //    Debug.WriteLine("Button clicked");


        //    string courseId = _id.ClassId;
        //    Debug.WriteLine("Course ID selected: " + courseId);

        //    //((ChapterViewModel)this.BindingContext).SetChapterId = courseId;
        //    _navigator.PushAsync<ChapterViewModel>();
        //});

        public void NavigateTest()
        {
            
        }
    }
};

