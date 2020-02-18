using System;
using System.Diagnostics;
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
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        //This part should probably be handle by a viewmodel
        private void Button_Tapped(object sender, EventArgs e)
        {
            Debug.WriteLine("Button clicked");

           

            StackLayout stackLayout = (StackLayout)sender;
            string courseId = stackLayout.ClassId;
            Debug.WriteLine("Course ID selected: " + courseId);

            ((CourseViewModel) this.BindingContext).SetChapterId = courseId;

            //Navigation.PushAsync(new ChapterView(courseId));
            Navigation.PushAsync(new ChapterView());
        }
    }
}