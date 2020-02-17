using System;
using OnlineStep.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineStep
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
