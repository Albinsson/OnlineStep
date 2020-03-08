using OnlineStep.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStep.Helpers
{
    //This class uses the Refit package, which is a type-safe REST lib for xamarin and .Net
    [Headers("Accept: application/json")]
    public interface RestInterface
    {
        [Get("/courses")]
        Task<List<Models.Course>> GetCourses();

        [Get("/courses/chapters/{id}")]
        Task<List<Models.Chapter>> GetChapters(string id);

        [Get("/chapters/pages/{id}")]
        Task<List<IPage>> Getpages(string id);
    }
}
