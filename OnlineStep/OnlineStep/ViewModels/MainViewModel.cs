using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnlineStep.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _welcomeText;
        private string _loginText = "Please login...";

        public MainViewModel()
        {
            _welcomeText = RandomWelcomeText();

        }

        public ICommand Login
        {
            get
            {
                return new Command<string>((x) => LoginText = (x));
            }
        }

        public string LoginText
        {
            get => _loginText;
            set
            {
                SetProperty(ref _loginText, (value));
            }

        }


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
