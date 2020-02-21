using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using OnlineStep.Navigation.Interfaces;
using Xamarin.Forms;

namespace OnlineStep.ViewModels
{
    class ClozeViewModel : BaseViewModel 
    {
        private readonly INavigator _navigator;
        public ClozeViewModel(INavigator navigator)
        {
            Debug.WriteLine("PageViewModel Constructor: ");
            _navigator = navigator;
        }

  
        public ICommand GoToNextPage => new Command(() =>
        {
            //TODO
           
        });

    }
}

