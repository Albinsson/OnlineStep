using Akavache;
using Fusillade;
using ModernHttpClient;
using OnlineStep.Helpers;
using OnlineStep.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace OnlineStep.Services
{
    public class NameOfOurAppService
    {
        //This is the class where everything comes together
        private ServiceHelper.IServiceHelper ServiceHelper;
        private readonly Lazy<RestInterface> userInitiated;
        public RestInterface UserInitiated { get { return userInitiated.Value; } }
        private IBlobCache Cache;
        private const string ApiEndPoint = "https://online-step.herokuapp.com";

        public NameOfOurAppService()
        {
            userInitiated = new Lazy<RestInterface>(() => createClient(new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.UserInitiated)));
        }

        public async Task<List<Course>> FetchCourses()
        {
            //Using the Akavache nuget we can store data from GetCoursesAsync() in our localMachine using a keyword "courses"
            //The offset method tells the cache how long we want the data to remain inside the cache
            //This method is different from FetchChapters and FetchPages because we run it when the app is loading in the start
            //Making the loading of courses much faster
            Cache = BlobCache.LocalMachine;
            var cachedCourses = Cache.GetAndFetchLatest("courses", () => GetCoursesAsync(), offset =>
               {
                   TimeSpan elapsed = DateTimeOffset.Now - offset;
                   return elapsed > new TimeSpan(hours: 2, minutes: 0, seconds: 0);
               });
            var courses = await cachedCourses.FirstOrDefaultAsync();
            return courses;
        }

        //There methods are the ones we call from courseViewModel and ChapterViewModel
        public async Task<List<Chapter>> FetchChapters(string id)
        {
            Cache = BlobCache.LocalMachine;
            List<Chapter> getChaptersTask = await GetChaptersAsync(id);
            await Cache.InsertObject("chapters", getChaptersTask, DateTimeOffset.Now.AddHours(2));
            var chapters = await Cache.GetObject<List<Chapter>>("chapters");        
            return chapters;
        }

        public async Task<List<Page.RootObject>> FetchPages(string id)
        {
            Cache = BlobCache.LocalMachine;
            List<Page.RootObject> getPagesTask = await GetPagesAsync(id);
            await Cache.InsertObject("pages", getPagesTask, DateTimeOffset.Now.AddHours(2));
            var pages = await Cache.GetObject<List<Page.RootObject>>("pages");
            return pages;
        }
        //END

        //There methods call on our ServiceHelper which is implemented in TestRestClientHelper
        async Task<List<Page.RootObject>> GetPagesAsync(string id)
        {
            Task<List<Page.RootObject>> getPagesTask = UserInitiated.Getpages(id);
            return await getPagesTask;
        }

        async Task<List<Chapter>> GetChaptersAsync(string id)
        {
            Task<List<Chapter>> getChaptersTask = UserInitiated.GetChapters(id);
            return await getChaptersTask;
        }

        async Task<List<Course>> GetCoursesAsync()
        {
            Task<List<Course>> getCourseTask = ServiceHelper.UserInitiated.GetCourses();
            return await getCourseTask;
        }
        //END

        //Had to create a local instance of this because the Request was not going through for chapters and pages
        Func<HttpMessageHandler, RestInterface> createClient = messageHandler =>
        {
            var client = new HttpClient(messageHandler)
            {
                BaseAddress = new Uri(ApiEndPoint)
            };
            return RestService.For<RestInterface>(client);
        };

    }
}
