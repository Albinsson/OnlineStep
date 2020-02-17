using OnlineStep.Models;
using OnlineStep.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using OnlineStep.Annotations;

namespace OnlineStep.ViewModels
{
    internal class CourseViewModel : BaseViewModel
    {
        private string _test = "Xamarin";
        private ObservableCollection<Course> _courseListDummy;
        private List<Course> _courseList;

        public CourseViewModel()
        {
            _test = "I change you";
            Task.Run(async () => { await init(); }).Wait();

        }

        public async Task init()
        {
           var temp = RestClient.GetCoursesAsync();
            _courseList = await temp;
        }

        public string Test
        {
            get => _test;
            set => _test = value;
        }
        public List<Course> CourseList
        {
            get => _courseList;
            set => _courseList = value;
        }
        public void OnMore(object sender, EventArgs e)
        {
            Debug.WriteLine("Button clicked");

        }
    }
};

