using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OnlineStep.Navigation.Interfaces;

namespace OnlineStep.ViewModels
{
    class McqViewModel : BaseViewModel
    {
        private readonly INavigator _navigator;
        public McqViewModel(INavigator navigator)
        {
            Debug.WriteLine("McqViewModel Constructor: ");

            _navigator = navigator;
        }
    }
}

