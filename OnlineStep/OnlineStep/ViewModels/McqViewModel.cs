using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using OnlineStep.Models;
using OnlineStep.Navigation.Interfaces;
using OnlineStep.Services;
using Xamarin.Forms;
using Page = OnlineStep.Models.IPage;

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
            _mcq = (Mcq) PageNavigator.GetCurrentPage;
            _navigator = navigator;
            Title = _mcq.title;
            Question = _mcq.content.question;
            AnswerList = _mcq.content.answers;
            SelectedAnswer = "";
            _correctAnswer = _mcq.content.correctAnswer;
            Debug.WriteLine(AnswerList[0]);
        }
        public ICommand GoToNextPage => new Command(() =>
        {
            PageNavigator.PushNextPage(_navigator);
        });

        public string Title { get; set; }

        public string Question { get; set; }

        public List<string> AnswerList { get; set; }
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
                //TODO Logic for right answer
                Debug.WriteLine("Rätt svar");
            }
            else
            {
                //TODO logic for wrong answer
                Debug.WriteLine("Fel svar");
            }

            PageNavigator.PushNextPage(_navigator);
        });
    }
}

