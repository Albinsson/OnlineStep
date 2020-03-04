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
        private readonly NameOfOurAppService Service = new NameOfOurAppService();

        public TestingViewModel(INavigator navigator)
        {
            _navigator = navigator;
            RequestCourses();
        }

        void RequestCourses()
        {
            Debug.WriteLine("RequestCourses");
            Data = DataCenter.GetListProcedure("GetCourseList");
            CourseList = new List<Course>();
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
