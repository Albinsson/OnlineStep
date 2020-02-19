using System;
using System.Windows.Input;
using OnlineStep.Navigation.Interfaces;
using Xamarin.Forms;
using Debug = System.Diagnostics.Debug;

namespace OnlineStep.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _loginText = "Please login...";

        private readonly INavigator _navigator;

        public MainViewModel()
        {
            WelcomeText = RandomWelcomeText();
        }

        public MainViewModel(INavigator navigator)
        {
            _navigator = navigator;
        }

        public ICommand Login
        {
            get
            {
                return new Command<string>((x) => LoginText = (x));
            }
        }


        public ICommand GoToNextView => new Command(() =>
        {
            Debug.WriteLine("Hello");
            _navigator.PushAsync<CourseViewModel>();
        });

        public string LoginText
        {
            get => _loginText;
            set
            {
                SetProperty(ref _loginText, (value));
            }
        }


        public string WelcomeText { get; set; }

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
