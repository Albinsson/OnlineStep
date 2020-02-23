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
    class McqViewModel : BaseViewModel
    {
        private readonly INavigator _navigator;

        private  Models.Page.RootObject _mcq;
        public McqViewModel(INavigator navigator)
        {
            Debug.WriteLine("McqViewModel Constructor: ");
            
            _mcq = PageNavigator.GetCurrentPage;

            _navigator = navigator;
        }


        public ICommand GoToNextPage => new Command(() =>
        {
            PageNavigator.PushNextPage(_navigator);
        });

        public Models.Page.RootObject Mcq
        {
            get => _mcq;

        }
    }
}

