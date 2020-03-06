using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
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
        private string _guessedWord = "";
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
            if (_guessedWord.Equals(_missingWord, StringComparison.InvariantCultureIgnoreCase))
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
        public string Title { get; set; }
        public string SentencesPartOne => _sentences[0];
        public string SentencesPartTwo => _sentences[1];
        public string EntryPlaceholder { get; set; }

        public string GuessedWord { 
            get => _guessedWord;
            set => _guessedWord = value;
        }

        public double Progress => PageNavigator.GetProgress();
    }
}

