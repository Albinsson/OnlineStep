using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OnlineStep.Services;
using OnlineStep.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineStep.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseView : ContentPage
    {
        public CourseView()
        {
            Debug.WriteLine("CourseView(): Constructor, starting");
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Debug.WriteLine("CourseView(): Constructor, ending");


        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
          
        //}


        private void Item_Selected(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("Item_Selected" + e);
        }
    }
}