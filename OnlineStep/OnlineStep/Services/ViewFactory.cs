﻿/*
 Title   : Xamplate
 Author  : Tomislav Erić
 Summary : ViewModel First Navigation, View to ViewModel autowireing
 Website : https://github.com/tomislaveric/Xamplate 
*/

using System;
using System.Collections.Generic;
using Autofac;
using OnlineStep.Navigation.Interfaces;
using Xamarin.Forms;

namespace OnlineStep.Services
{
    public class ViewFactory : IViewFactory
    {
        private readonly IDictionary<Type, Type> _map = new Dictionary<Type, Type>();
        private readonly IComponentContext _componentContext;

        public ViewFactory(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public void Register<TViewModel, TView>() where TViewModel : class, IViewModelBase where TView : Page
        {
            _map[typeof(TViewModel)] = typeof(TView);
        }

        public Page Resolve<TViewModel>() where TViewModel : class, IViewModelBase
        {
            var viewModel = _componentContext.Resolve<TViewModel>();
            var viewType = _map[typeof(TViewModel)];
            var view = _componentContext.Resolve(viewType) as Page;

            view.BindingContext = viewModel;
            return view;
        }
    }
}
