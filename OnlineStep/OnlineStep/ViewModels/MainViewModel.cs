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
        private string _welcomeText;
        private readonly INavigator _navigator;
        private NameOfOurAppService Service = new NameOfOurAppService();
        private List<Course> CourseList;

        public MainViewModel()
        {
            _welcomeText = RandomWelcomeText();
        }

        public MainViewModel(INavigator navigator)
        {
            Debug.WriteLine("public MainViewModel(INavigator navigator)");
            _navigator = navigator;
            InitApiRequestAsync();
        }

        public async Task InitApiRequestAsync()
        {
            //var client = new HttpClient(new NativeMessageHandler())
            //{
            //    BaseAddress = new Uri("https://online-step.herokuapp.com")
            //};           
            //var i = RestService.For<RestInterface>(client);
            //CourseList = await i.GetCourses();
            CourseList = await Service.FetchCourses();           
            var objList = CourseList.ConvertAll(x => (object)x);
            DataCenter.CreateListProcedure("SetCourseList", objList);       
        }

        public ICommand GoToNextView => new Command(() =>
        {
            Debug.WriteLine("Hejhej");
            _navigator.PushAsync<CourseViewModel>();
        });

        public ICommand GoToNext => new Command(() =>
        {
            Debug.WriteLine("Testing");
            Debug.WriteLine("MainViewModelCount" + CourseList.Count);
            _navigator.PushAsync<MainViewModel>();
        });

        //public string LoginText
        //{
        //    get => _loginText;
        //    set
        //    {
        //        SetProperty(ref _loginText, (value));
        //    }
        //}


        public string WelcomeText
        {
            get => _welcomeText;
            set => _welcomeText = value;
        }

        // Example of business-logic for a random welcome text.
        public string RandomWelcomeText()
        {
            Random r = new Random();
            int randomText = r.Next(1, 3);
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
