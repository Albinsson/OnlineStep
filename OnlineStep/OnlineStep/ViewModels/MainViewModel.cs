﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using OnlineStep.Models;
using OnlineStep.Navigation.Interfaces;
using OnlineStep.Services;
using Xamarin.Forms;

namespace OnlineStep.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly INavigator _navigator;
        //TODO: Rename the class NameOfOurAppService
        //QUESTION: Är detta en data fetcher bara?
        private OnlineStepApiService ApiFetcher = new OnlineStepApiService();
        private List<Course> CourseList;

        public MainViewModel(INavigator navigator)
        {
            Debug.WriteLine("public MainViewModel(INavigator navigator)");
            _navigator = navigator;
            _ = InitApiRequestAsync();
        }

        public async Task InitApiRequestAsync()
        {
            CourseList = await ApiFetcher.FetchCourses();
            List<object> courseObjectList = CourseList.ConvertAll(x => (object)x);
            DataCenter.CreateListProcedure("SetCourseList", courseObjectList);       
        }

        public ICommand GoToCourses => new Command(() =>
        {
            _navigator.PushAsync<CourseViewModel>();
        });

        public string WelcomeText => RandomWelcomeText();

        public string RandomWelcomeText()
        {
            var r = new Random();
            var randomText = r.Next(1, 3);
            switch (randomText)
            {
                case 1: return "Välkommen tillbaka";
                case 2: return "Lycka till med studierna";
                case 3: return "Övning ger färdighet";
            }
            return null;
        }
    }
}
