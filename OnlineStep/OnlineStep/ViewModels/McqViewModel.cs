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
        private bool HasPropertyValueChanged { get; set; }
        public McqViewModel(INavigator navigator)
        {
            Debug.WriteLine("McqViewModel Constructor: ");
            _mcq = (Mcq)PageNavigator.GetCurrentPage;
            _navigator = navigator;
            Title = _mcq.title;
            Question = _mcq.content.question;
            SelectedAnswer = "";
            _correctAnswer = _mcq.content.correctAnswer;

            ShowCorrection = false;
            ShowCorrectMeButton = true;
        }

        public string Title { get; set; }

        public string Question { get; set; }

        public List<string> AnswerList { get => _mcq.content.answers; }

        private string SelectedAnswer { get; set; }
        public ICommand SelectAnswer => new Command<string>((answer) =>
        {
            Debug.WriteLine(answer);
            SelectedAnswer = answer;
        });
        //public ICommand CheckCorrectAnswer => new Command(() =>
        //{
        //    if (SelectedAnswer.Equals(_correctAnswer, StringComparison.InvariantCultureIgnoreCase))
        //    {
        //        //TODO Logic for right answer
        //        Debug.WriteLine("Rätt svar");
        //    }
        //    else
        //    {
        //        //TODO logic for wrong answer
        //        Debug.WriteLine("Fel svar");
        //    }

        //    PageNavigator.PushNextPage(_navigator);
        //});
        public ICommand CheckCorrectAnswer => new Command(() =>
        {

            Debug.WriteLine(SelectedAnswer);
            if (SelectedAnswer.Equals(_correctAnswer, StringComparison.InvariantCultureIgnoreCase))
            {
                //TODO Logic for right answer
                Debug.WriteLine("Rätt svar");
                CorectOrWrongBool = true;
                CorrectOrWrongMessage = "Du har svarat rätt!";
                HasPropertyValueChanged = false;
                PageNavigator.Xp += 10;
            }
            else
            {
                //TODO logic for wrong answer
                Debug.WriteLine("Fel svar");
                CorectOrWrongBool = false;
                CorrectOrWrongMessage = "Tyvärr svarade du fel på frågan...";
                HasPropertyValueChanged = true;
            }
            PageNavigator.PageResults.Add(CorectOrWrongBool);
            ShowCorrection = true;
            ShowCorrectMeButton = false;
        });

        public ICommand GoToNextPage => new Command(() =>
        {
            PageNavigator.PushNextPage(_navigator);
        });

        public string CorrectOrWrongMessage { set; get; }
        public bool CorectOrWrongBool { set; get; }
        public bool ShowCorrection { set; get; }
        public bool ShowCorrectMeButton { set; get; }
        public bool HasPropertyValueChanged1 { get => HasPropertyValueChanged2; set => HasPropertyValueChanged2 = value; }
        public bool HasPropertyValueChanged2 { get => HasPropertyValueChanged; set => HasPropertyValueChanged = value; }
    }
}

