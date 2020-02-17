using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStep.Services;
using OnlineStep.ViewModels;
using OnlineStep.Views;
using Xamarin.Forms;

namespace OnlineStep
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

        }

        private void Handle_Clicked_Get_Started(object sender, EventArgs e)
        {


            Navigation.PushAsync(new CourseView());

            //Debug.WriteLine("Rest start");
            //var courses = await RestClient.GetCoursesAsync();
            //Debug.WriteLine("Rest done");
            //await Navigation.PushAsync(new CourseView(courses));
        }
    }
}
