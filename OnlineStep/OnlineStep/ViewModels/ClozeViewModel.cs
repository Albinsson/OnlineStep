using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using OnlineStep.Models;
using OnlineStep.Navigation.Interfaces;
using OnlineStep.Services;
using Xamarin.Forms;
using Page = Xamarin.Forms.Page;

namespace OnlineStep.ViewModels
{
    class ClozeViewModel : BaseViewModel 
    {
        private readonly INavigator _navigator;

        private Cloze _cloze;

        public ClozeViewModel(INavigator navigator)
        {
            Debug.WriteLine("PageViewModel Constructor: ");
            _cloze = (Cloze) PageNavigator.GetCurrentPage;
            _navigator = navigator;
        }
        
        public Cloze Cloze
        {
            get
            {
                Debug.WriteLine("Getting Cloze: " + _cloze);
                return _cloze;
            }
        }


        public ICommand GoToNextPage => new Command(() =>
        {
            
            PageNavigator.PushNextPage(_navigator);
        });

    }
}

