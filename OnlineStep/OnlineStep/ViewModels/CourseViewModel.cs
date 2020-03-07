using OnlineStep.Models;
using OnlineStep.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using OnlineStep.Helpers;
using OnlineStep.Navigation.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace OnlineStep.ViewModels
{
    internal class CourseViewModel : BaseViewModel
    {
        public List<Course> CourseList { get; set; }
        private readonly INavigator _navigator;
        private Data Data;


        public CourseViewModel(INavigator navigator)
        {
            InitAsyncApiRequest();
            _navigator = navigator;                  
        }
        //TODO: Rename me
        public void InitAsyncApiRequest()
        {
            Data = DataCenter.GetListProcedure("GetCourseList");
            Debug.WriteLine("Post");
            CourseList = new List<Course>();
            Debug.WriteLine("Data" + Data.ObjList.Count);
            foreach (var i in Data.ObjList)
            {
                Course c = (Course)i;
                c.Name = c.Name.ToUpper();
                CourseList.Add(c);
            }
        }

        public ICommand GoToChapters => new Command<string>((id) =>
        {
            DataCenter.CreateSingletonProcedure("SetChapterID", id);           
            _navigator.PushAsync<ChapterViewModel>();
        });
            
    }
};

