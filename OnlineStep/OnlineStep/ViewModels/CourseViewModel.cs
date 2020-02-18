using OnlineStep.Models;
using OnlineStep.Services;
using System;
using System.Collections.Generic;

using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnlineStep.ViewModels
{
    internal class CourseViewModel : BaseViewModel
    {
        private List<Course> courseList;
        
        public CourseViewModel()
        {
            Debug.WriteLine("CourseViewModel()");
            Task.Run(async () => { await InitAsyncApiRequest(); }).Wait();
            
        }   

        public async Task InitAsyncApiRequest()
        {
            try
            {
                Debug.WriteLine("InitAsyncApiRequest()");
                var temp = RestClient.GetCoursesAsync();
                courseList = await temp;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("InitAsyncApiRequest()");
                Debug.WriteLine(ex);
            }

        }

        public List<Course> CourseList
        {
            get => courseList;
            set => courseList = value;
        }

        public ICommand SetCurrentChapterId
        {
            get
            {
                return new Command<string>((x) => CurrentChapterID = (x));
            }
        }

        public String SetChapterId
        {
            set => CurrentChapterID = value;
        }
    }
};

