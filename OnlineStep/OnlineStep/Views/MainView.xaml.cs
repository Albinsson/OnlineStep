using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineStep.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Handle_Clicked_Get_Started(object sender, EventArgs e)
        {
            
            Navigation.PushAsync(new CourseView());
        }
    }
}