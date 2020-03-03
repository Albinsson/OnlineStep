using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;
using OnlineStep.Models;
using OnlineStep.Services;
using Xamarin.Forms;

namespace OnlineStep.Helpers
{
    public class DbHelper
    {
        private RestCLient_A RestCLient;
        private string Url = "https://online-step.herokuapp.com/";
        private string Courses = "courses/";
        private string Chapters = "courses/chapters/";
        private string Pages = "chapters/pages/";

        public DbHelper()
        {

        }
        
        //TODO:Insert if statements for null  

        public List<Course> GetCourses()
        {
            RestCLient = new RestCLient_A {HttpMethod = RestCLient_A.HttpVerb.GET, EndPoint = Url + Courses}; 
            string courses = RestCLient.DoRequest();
            List<Course> courseList = new List<Course>();
            courseList = JsonConvert.DeserializeObject<List<Course>>(courses);
            return courseList;
        }

        public List<Chapter> GetChapters(string id)
        {
            Debug.WriteLine("public List<Chapter> GetChapters(string id)");
            Debug.WriteLine( Url + Chapters + id);
            RestCLient = new RestCLient_A {HttpMethod = RestCLient_A.HttpVerb.GET, EndPoint = Url + Chapters + id};
            string chapters = RestCLient.DoRequest();
            List<Chapter> chapterList = new List<Chapter>();
            chapterList = JsonConvert.DeserializeObject<List<Chapter>>(chapters);
            return chapterList;
        }

        public List<Models.Page.RootObject> GetPages(string id)
        {
            Debug.WriteLine("DbHelper Page ID", id);
            Debug.WriteLine("DbHelper Url", Url + Pages + id);
            RestCLient = new RestCLient_A {HttpMethod = RestCLient_A.HttpVerb.GET, EndPoint = Url + Pages + id};
            string pages = RestCLient.DoRequest();
            List<Models.Page.RootObject> pageList = new List<Models.Page.RootObject>();
            pageList = JsonConvert.DeserializeObject<List<Models.Page.RootObject>>(pages);
            return pageList;
        }

        public List<ChapterLevels> GetChaptersByLevel(string id)
        {
            Debug.WriteLine("public List<Chapter> GetChapters(string id)");
            Debug.WriteLine(Url + Chapters + id);
            RestCLient = new RestCLient_A { HttpMethod = RestCLient_A.HttpVerb.GET, EndPoint = Url + Chapters + id };
            string chapters = RestCLient.DoRequest();
            List<Chapter> chapterList = new List<Chapter>();
            chapterList = JsonConvert.DeserializeObject<List<Chapter>>(chapters);

            List<ChapterLevels> listOfChapters = new List<ChapterLevels>();

            foreach (var chapter in chapterList)
            {

                while (int.Parse(chapter.Level) > listOfChapters.Count)
                {
                    listOfChapters.Add(new ChapterLevels(){ChapterList = new List<Chapter>()});
                }
                listOfChapters[int.Parse(chapter.Level) - 1].ChapterList.Add(chapter);
                listOfChapters[int.Parse(chapter.Level) - 1].Level = chapter.Level;

            }
            return listOfChapters;

            //List<List<Chapter>> listOfChapters = new List<List<Chapter>>();

            //foreach (var chapter in chapterList)
            //{
            //    while (int.Parse(chapter.Level) > listOfChapters.Count)
            //    {
            //        listOfChapters.Add(new List<Chapter>());
            //    }
            //    listOfChapters[int.Parse(chapter.Level) - 1].Add(chapter);
            //}
            //return listOfChapters;
        }
    }
}
