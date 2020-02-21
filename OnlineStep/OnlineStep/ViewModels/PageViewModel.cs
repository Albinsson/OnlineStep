using System;
using System.Collections.Generic;
using System.Text;
using OnlineStep.Navigation.Interfaces;

namespace OnlineStep.ViewModels
{
    class PageViewModel : BaseViewModel
    {
        private readonly INavigator _navigator;
        public PageViewModel(INavigator navigator)
        {
            _navigator = navigator;
        }
    }
}
