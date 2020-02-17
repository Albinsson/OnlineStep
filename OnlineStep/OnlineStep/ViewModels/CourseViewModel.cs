using OnlineStep.Models;
using OnlineStep.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using OnlineStep.Annotations;

namespace OnlineStep.ViewModels
{
    internal class CourseViewModel : BaseViewModel
    {
        private string _test = "Xamarin";
        private ObservableCollection<Course> _courseListDummy;
        private List<Course> _courseList;

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
    }
};




//    public CourseViewModel()
//        {
//            CourseListDummy = new List<Course>();
//            addDummyData();
//            Task.Run(async () => { await GetData(); });
//        }

//        public List<Course> getDummyData()
//        {
//            addDummyData();
//            return CourseListDummy;
//        }

//        private void addDummyData()
//        {
//            var course1 = new Course
//            {
//                Chapters = new List<string>(),
//                Name = "First Step",
//                Owner = "Team Xamarin",
//                Subject = "English",
//                _id = "1",
//                __v = 1
//            };
//            var course2 = new Course
//            {
//                Chapters = new List<string>(),
//                Name = "Swedish Step",
//                Owner = "Team Xamarin",
//                Subject = "Swedish",
//                _id = "2",
//                __v = 2
//            };

//            CourseListDummy.Add(course1);
//            CourseListDummy.Add(course2);
//        }

//        public List<string> Chapters { get; set; }
//        public string _id { get; set; }
//        public string Name { get; set; }
//        public string Owner { get; set; }
//        public string Subject { get; set; }
//        public int __v { get; set; }

//        private async Task<List<Course>> GetData()
//        {
//            RestClient restClient = new RestClient();
//            CourseList = await restClient.GetCoursesAsync();
//            Debug.WriteLine("GetData(): Course List Loaded");
//            CourseList.ForEach(Console.WriteLine);
//            return CourseList;
//        }
//    }
//}