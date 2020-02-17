using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineStep.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChapterView : ContentPage
    {
        public ChapterView(string chapterId)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            Debug.WriteLine("ChapterView(string chapterId)");
            Debug.WriteLine(chapterId);
        }
    }
}