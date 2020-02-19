using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OnlineStep.Navigation.Interfaces
{
    public interface IViewFactory
    {
        void Register<TViewModel, TView>() where TViewModel : class, IViewModelBase where TView : Page;
        Page Resolve<TViewModel>() where TViewModel : class, IViewModelBase;
    }
}