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
        public List<Course> CourseList
        {
            get => courseList;
            set => courseList = value;
        }
        private List<Chapter> chapterList;
        public List<Chapter> ChapterList { get => chapterList; set => chapterList = value; }
        private readonly INavigator _navigator;
        private readonly DbHelper dbHelper = new DbHelper();
        private Data Data;


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
        }

        public ICommand GoToChapterView => new Command<string>((id) =>
        {
            DataCenter.CreateSingletonProcedure("SetChapterID", id);           
            _navigator.PushAsync<ChapterViewModel>();
        });

       
        
    }
};

