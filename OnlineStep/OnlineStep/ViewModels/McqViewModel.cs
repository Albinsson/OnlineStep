using OnlineStep.Models;
using OnlineStep.Navigation.Interfaces;
using OnlineStep.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnlineStep.ViewModels
{
    class McqViewModel : BaseViewModel
    {
        private readonly INavigator _navigator;
        private readonly Mcq _mcq;
        private string _correctAnswer { get; set; }
        public McqViewModel(INavigator navigator)
        {
            Debug.WriteLine("McqViewModel Constructor: ");
            _mcq = (Mcq)PageNavigator.GetCurrentPage;
            _navigator = navigator;
            Title = _mcq.title;
            Question = _mcq.content.question;
            SelectedAnswer = "";
            _correctAnswer = _mcq.content.correctAnswer;
        }

        public ICommand GoToNextPage => new Command(() =>
        {
            PageNavigator.PushNextPage(_navigator);
        });

        public string Title { get; set; }

        public string Question { get; set; }

        public List<string> AnswerList { get => _mcq.content.answers; }

        private string SelectedAnswer { get; set; }
        public ICommand SelectAnswer => new Command<string>((answer) =>
        {
            Debug.WriteLine(answer);
            SelectedAnswer = answer;
        });
        public ICommand CheckCorrectAnswer => new Command(() =>
        {
            if (SelectedAnswer.Equals(_correctAnswer, StringComparison.InvariantCultureIgnoreCase))
            {
                UserProgress.AddPageResult(true);
                Debug.WriteLine("Rätt svar");
            }
            else
            {
        
                UserProgress.AddPageResult(false);
                Debug.WriteLine("Fel svar");
            }


            PageNavigator.PushNextPage(_navigator);
        });

        public double Progress => PageNavigator.GetProgress();

    }
}

