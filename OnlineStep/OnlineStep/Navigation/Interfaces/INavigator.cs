using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStep.Navigation.Interfaces
{
    public interface INavigator
    {
        Task PopAsync();
        Task PopToRootAsync();
        Task PushAsync<TViewModel>() where TViewModel : class, IViewModelBase;
        Task PushModalAsync<TViewModel>() where TViewModel : class, IViewModelBase;
    }
}
