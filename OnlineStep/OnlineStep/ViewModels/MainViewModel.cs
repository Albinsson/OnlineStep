using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using OnlineStep.Annotations;
using Xamarin.Forms;

namespace OnlineStep.ViewModels
{
    public class MainViewModel
    {
      
        public string WelcomeText => RandomWelcomeText();


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
