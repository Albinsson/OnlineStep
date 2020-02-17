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
       
        
        //public CourseView(List<Course> courses)
        //{
        //    InitializeComponent();
        //    NavigationPage.SetHasNavigationBar(this, false);

        //    CourseViewModel courseViewModel = new CourseViewModel { CourseList = courses };
        //    courseViewModel.Test = "kjdashkjdhaskjd";
        //    BindingContext = courseViewModel;
        //    Debug.WriteLine("CourseView(): Constructor, ending");
        //}

        private void Item_Selected(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("Item_Selected" + e);
        }
    }
}