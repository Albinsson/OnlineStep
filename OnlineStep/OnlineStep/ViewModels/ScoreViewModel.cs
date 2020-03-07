using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using OnlineStep.Models;
using OnlineStep.Navigation.Interfaces;
using OnlineStep.Services;
using Xamarin.Forms;

namespace OnlineStep.ViewModels
{
    public class ScoreViewModel : BaseViewModel 
    {
        private readonly INavigator _navigator;
        
        public ScoreViewModel(INavigator navigator)
        {
            Debug.WriteLine("ScoreViewModel Constructor: ");
            _navigator = navigator;
            ChapterXp = UserProgress.Xp.ToString();
            ChapterResult = UserProgress.Xp.ToString();
            ResultMessage = "TODO: Logic for messaages depending on Score ";

        }

        public double Progress => PageNavigator.GetProgress();
        public string ChapterXp { get; set; }
        public string ChapterResult { get; set; }
        public string ResultMessage { get; set; }

        public ICommand GoToChapter => new Command(() =>
        {
            PageNavigator.PageList = new List<IPage>();
            _navigator.PushAsync<ChapterViewModel>();
        });




    }
}

