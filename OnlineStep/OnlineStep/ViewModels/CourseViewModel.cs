using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OnlineStep.Annotations;
using OnlineStep.Models;
using OnlineStep.Services;

namespace OnlineStep.ViewModels
{
    class CourseViewModel : BaseViewModel
    {
        public List<Course> CourseList;
        

        public CourseViewModel()
        {
            Task.Run(async () => { await GetData(); });
        }

    private async Task<List<Course>> GetData()
    {
        RestClient restClient = new RestClient();
        CourseList = await restClient.GetCoursesAsync();
        Debug.WriteLine("GetData(): Course List Loaded");
        CourseList.ForEach(Console.WriteLine);
        return CourseList;
    }
    }
}
