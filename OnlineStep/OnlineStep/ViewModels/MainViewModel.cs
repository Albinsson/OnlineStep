using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using OnlineStep.Annotations;
using Xamarin.Forms;

namespace OnlineStep.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
      
        private string _welcomeText;
        private string _loginText = "Please login...";
       

        public MainViewModel()
        {
            Debug.WriteLine("MainViewModel(): Constructor started");

            _welcomeText = RandomWelcomeText();
            

            Debug.WriteLine("MainViewModel(): Constructor finished");

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

        // Example of business-logic.
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
