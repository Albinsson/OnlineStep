using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using OnlineStep.Models;
using OnlineStep.Navigation.Interfaces;
using OnlineStep.Services;
using Xamarin.Forms;

namespace OnlineStep.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly INavigator _navigator;
        //TODO: Rename the class DbService
        private DbService Service = new DbService();
        private List<Course> CourseList;

        public MainViewModel(INavigator navigator)
        {
            Debug.WriteLine("public MainViewModel(INavigator navigator)");
            _navigator = navigator;
            InitApiRequestAsync();
        }

        public async Task InitApiRequestAsync()
        {
            CourseList = await Service.FetchCourses();           
            var objList = CourseList.ConvertAll(x => (object)x);
            DataCenter.CreateListProcedure("SetCourseList", objList);       
        }

        public ICommand GoToCourses => new Command(() =>
        {
            _navigator.PushAsync<CourseViewModel>();
        });

        public string WelcomeText => RandomWelcomeText();

        public string RandomWelcomeText()
        {
            var r = new Random();
            var randomText = r.Next(1, 3);
            switch (randomText)
            {
                case 1: return "Nice to see you again";
                case 2: return "Good luck studding";
                case 3: return "Time to practice some english";
            }
            return null;
        }
    }
}
