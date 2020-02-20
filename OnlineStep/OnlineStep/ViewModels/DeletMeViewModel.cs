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
    internal class DeleteMeViewModel : BaseViewModel
    {
        private List<Chapter> chapterList;
        private List<Course> courseList_Test;
        private readonly INavigator _navigator;
        private string courseID;

  
        public DeleteMeViewModel(INavigator navigator)
        {
            Debug.WriteLine("DeleteMeViewModel construktor");
            InitAsyncApiRequest();
            _navigator = navigator;
        }
        //TODO: Rename me
        public void InitAsyncApiRequest()
        {
            Debug.WriteLine("Current course ID:");
            
            Debug.WriteLine(CurrentCourseID);
            Debug.WriteLine(Test);

            DbHelper dbHelper = new DbHelper();
            //courseList_Test = dbHelper.GetCourses();
            chapterList = dbHelper.GetChapters(CurrentCourseID);
            
            //Debug.WriteLine(chapterList.Count);

        }

        public ICommand GoToChapterView => new Command<string>((id) =>
        {
            Debug.WriteLine("Going to chapter: " + id);
            CurrentCourseID = id;
            Debug.WriteLine("Chapter id set to : " + CurrentCourseID);

            _navigator.PushAsync<ChapterViewModel>();
            //_navigator.PopAsync();
            

            Debug.WriteLine("_navigator.PushAsync<ChapterViewModel>();" + id);
        });

        public List<Chapter> ChapterList
        {
            get => chapterList;
            set => chapterList = value;
        }

        public List<Course> CourseList_Test
        {
            get => courseList_Test;
            set => courseList_Test = value;
        }



    }
};

