using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using OnlineStep.Navigation.Interfaces;
using OnlineStep.Services;
using Xamarin.Forms;

namespace OnlineStep.ViewModels
{
    class ClozeViewModel : BaseViewModel 
    {
        private readonly INavigator _navigator;

        private Models.Page.RootObject _cloze;

        public ClozeViewModel(INavigator navigator)
        {
            Debug.WriteLine("PageViewModel Constructor: ");
            _cloze = PageNavigator.GetCurrentPage;
            _navigator = navigator;
        }

  
        public ICommand GoToNextPage => new Command(() =>
        {
            PageNavigator.PushNextPage(_navigator);
        });

    }
}

