using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using OnlineStep.Navigation.Interfaces;
using OnlineStep.Services;
using Xamarin.Forms;

namespace OnlineStep.Navigation.Modules
{
    public class DependencyRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ViewFactory>().As<IViewFactory>().SingleInstance();
            builder.RegisterType<Navigator>().As<INavigator>().SingleInstance();
            builder.Register<INavigation>(context => Application.Current.MainPage.Navigation).SingleInstance();
        }
    }
}
