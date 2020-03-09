using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using OnlineStep.Models;
using OnlineStep.Navigation.Interfaces;
using OnlineStep.Services;
using Xamarin.Forms;
using Page = Xamarin.Forms.Page;

namespace OnlineStep.ViewModels
{
    public class ClozeViewModel : BaseViewModel 
    {
        private readonly INavigator _navigator;
        private readonly Cloze _cloze;
        private readonly string[] _sentences;
        private string _missingWord;

        public ClozeViewModel(INavigator navigator)
        {
            Debug.WriteLine("ClozeViewModel Constructor: ");
            _cloze = (Cloze) PageNavigator.GetCurrentPage;
            _navigator = navigator;
            _sentences = SplitSentence(_cloze.content.sentence, _cloze.content.missingWords);
            _missingWord = _cloze.content.missingWords[0];
            Title = _cloze.title;
            EntryPlaceholder = CreatePlaceholder(_missingWord);
            GuessedWord = "";

            ShowCorrection = false;
            ShowCorrectMeButton = true;
        }
        //Empty constructor used for testing
        public ClozeViewModel(){}

        public string[] SplitSentence(string sentence, List<string> missingWords)
        {
            Debug.WriteLine("Set sentences");
            string missingWord = missingWords[0];
            return sentence.Split(new string[] { missingWord }, StringSplitOptions.None);
        }

        public string CreatePlaceholder(string missingWord)
        {
            Debug.WriteLine(missingWord);
            Debug.WriteLine("missingWord length " + missingWord.Length);

            string placeholder = "";
            for (int i = 0; i < missingWord.Length; i++)
            {
                placeholder += "_";
            }
            return placeholder;
        }

        public ICommand CheckCorrectAnswer => new Command(() =>
        {
            
            Debug.WriteLine(GuessedWord);
            if (GuessedWord.Equals(_missingWord, StringComparison.InvariantCultureIgnoreCase))
            {
                //TODO Logic for right answer
                Debug.WriteLine("Rätt svar");
                CorectOrWrongBool = true;
                CorrectOrWrongMessage = "Du har svarat rätt!";
                UserProgress.AddPageResult(true);

            }
            else
            {
                //TODO logic for wrong answer
                Debug.WriteLine("Fel svar");
                CorectOrWrongBool = false;
                CorrectOrWrongMessage = "Tyvärr svarade du fel på frågan...";
                UserProgress.AddPageResult(false);
            }

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
        public string Title { get; set; }
        public string SentencesPartOne => _sentences[0];
        public string SentencesPartTwo => _sentences[1];
        public string EntryPlaceholder { get; set; }

        public string GuessedWord { set; get; }

        public double Progress => PageNavigator.GetProgress();
    }
}

