using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnlineStep.ViewModels;

namespace OnlineStep.Services
{
    class NavigationService : INavigationService
    {
        public BaseViewModel PreviousPageViewModel { get; }
        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            throw new NotImplementedException();
        }

        public Task RemoveLastFromBackStackAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveBackStackAsync()
        {
            throw new NotImplementedException();
        }
    }
}
