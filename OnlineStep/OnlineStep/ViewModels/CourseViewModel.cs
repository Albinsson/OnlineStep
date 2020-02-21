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
        private DataCenter DataCenter;

  
        public CourseViewModel(INavigator navigator)
        {
            InitAsyncApiRequest();
            _navigator = navigator;
            DataCenter = new DataCenter { ContainerId = this.GetType().ToString()};
            DataCenterFactory.DataCenterList.Add(DataCenter);           
        }
        //TODO: Rename me
        public void InitAsyncApiRequest()
        {
            DbHelper dbHelper = new DbHelper();
            courseList = dbHelper.GetCourses();           
        }

        public ICommand GoToChapterView => new Command<string>((id) =>
        {
            //Preferences.Set("chapterID", id);
            DataCenter.CreateProcedure("SetChapterID", id);
            //var chapterID = Preferences.Get("chapterID", "default_value");
            _navigator.PushAsync<ChapterViewModel>();
        });

        public List<Course> CourseList
        {
            get => courseList;
            set => courseList = value;
        }

    }
};

