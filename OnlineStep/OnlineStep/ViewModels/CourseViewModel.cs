using OnlineStep.Models;
using OnlineStep.Helpers;
using OnlineStep.Navigation.Interfaces;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using static Android.Content.ClipData;

namespace OnlineStep.ViewModels
{
    internal class CourseViewModel : BaseViewModel
    {
        private List<Course> courseList;
        private Item _selectedItem;

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
            InitAsyncApiRequest();
            _navigator = navigator;
        }

       

        //TODO: Rename me
        public void InitAsyncApiRequest()
        {
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


        public Command GoToChapterView => new Command((id) =>
        {
            Debug.WriteLine("Going to chapter: " + id);
            _navigator.PushAsync<ChapterViewModel>();
        });

        //void GoToChapterView()
        //{
        //    string id = _id.ClassId;
        //    Debug.WriteLine("Going to chapter: " + id);
        //    _navigator.PushAsync<ChapterViewModel>();
        //}

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

        public string SetChapterId
        {
            set => CurrentChapterID = value;
        }

        //public Item SelectedItem
        //{
        //    get
        //    {
        //        return _selectedItem;
        //    }

        //    set
        //    {
        //        _selectedItem = value;
        //        if (_selectedItem == null) return;

        //        GoToChapterView.Execute(_selectedItem);
        //        SelectedItem = null;
        //    }
        //}

    }
};

