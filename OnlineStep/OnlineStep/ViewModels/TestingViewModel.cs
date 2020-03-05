using System;
using System.Collections.Generic;
using System.Text;
using OnlineStep.Models;
using OnlineStep.Helpers;
using OnlineStep.Navigation.Interfaces;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using OnlineStep.Services;
using System.Diagnostics;

namespace OnlineStep.ViewModels
{
    class TestingViewModel : BaseViewModel
    {
        private List<Course> courseList;
        public List<Course> CourseList
        {
            get => courseList;
            set => courseList = value;
        }
        private Data Data;
        private readonly INavigator _navigator;

        public TestingViewModel(INavigator navigator)
        {
            _navigator = navigator;
            RequestCourses();
        }

        void RequestCourses()
        {
            Debug.WriteLine("RequestCourses");
            Data = DataCenter.GetListProcedure("GetCourseList");
            Debug.WriteLine("Post");
            CourseList = new List<Course>();
            Debug.WriteLine("Data"+Data.ObjList.Count);
            foreach (var i in Data.ObjList)
            {
                Course c = (Course)i;
                CourseList.Add(c);
            }
           
        }

        public ICommand GoToChapterView => new Command<string>((id) =>
        {
            DataCenter.CreateSingletonProcedure("SetChapterID", id);
            _navigator.PushAsync<TestingChapterViewModel>();
        });
    }
}
