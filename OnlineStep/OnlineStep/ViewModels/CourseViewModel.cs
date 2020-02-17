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
using Xamarin.Forms;

namespace OnlineStep.ViewModels
{
    internal class CourseViewModel : BaseViewModel
    {
        private List<Course> _courseList;
        
        public CourseViewModel()
        {
            Task.Run(async () => { await InitAsyncApiRequest(); }).Wait();
        }

        public async Task InitAsyncApiRequest()
        {
           var temp = RestClient.GetCoursesAsync();
            _courseList = await temp;
        }

        public List<Course> CourseList
        {
            get => _courseList;
            set => _courseList = value;
        }

    }
};

