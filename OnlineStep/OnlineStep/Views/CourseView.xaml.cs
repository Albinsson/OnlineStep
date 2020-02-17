using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OnlineStep.Models;
using OnlineStep.Services;
using OnlineStep.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineStep.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseView : ContentPage
    {
        //CourseViewModel courseViewModel = new CourseViewModel();

        public CourseView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

        }

        private void Button_Tapped(object sender, EventArgs e)
        {
            Debug.WriteLine("Button clicked");
        }
    }
}