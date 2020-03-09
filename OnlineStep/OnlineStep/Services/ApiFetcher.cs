using Akavache;
using Fusillade;
using ModernHttpClient;
using OnlineStep.Helpers;
using OnlineStep.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reactive.Linq;
using System.Threading.Tasks;


namespace OnlineStep.Services
{
    public class ApiFetcher
    {
        //This is the class where everything comes together
        private ServiceHelper.IServiceHelper ServiceHelper;
        private readonly Lazy<RestInterface> userInitiated;
        public RestInterface UserInitiated { get { return userInitiated.Value; } }
        private IBlobCache Cache;
        private const string ApiEndPoint = "https://online-step.herokuapp.com";

        public ApiFetcher()
        {
            userInitiated = new Lazy<RestInterface>(() => createClient(new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.UserInitiated)));
        }

        public async Task<List<Course>> FetchCourses()
        {
            //TODO: Behöver vi en så här lång kommentar?
            //Using the Akavache nuget we can store data from GetCoursesAsync() in our localMachine using a keyword "courses"
            //The offset method tells the cache how long we want the data to remain inside the cache
            //This method is different from FetchChapters and FetchPages because we run it when the app is loading in the start
            //Making the loading of courses much faster
            Cache = BlobCache.LocalMachine;
            //TODO: Gammal kod?
            //var cachedCourses = Cache.GetAndFetchLatest("courses", () => GetCoursesAsync(), offset =>
            //   {
            //       TimeSpan elapsed = DateTimeOffset.Now - offset;
            //       return elapsed > new TimeSpan(hours: 2, minutes: 0, seconds: 0);
            //   });
            //var courses = await cachedCourses.FirstOrDefaultAsync();

            //List<Course> courses = await GetCoursesAsync();
            //await Cache.InsertObject("courses", courses, DateTimeOffset.Now.AddHours(2));
            //var c = await Cache.GetObject<List<Course>>("courses");

            //var client = new HttpClient(new NativeMessageHandler())
            //{
            //    BaseAddress = new Uri("https://online-step.herokuapp.com")
            //};   
            RestInterface _restInterface = RestService.For<RestInterface>("https://online-step.herokuapp.com");
            List<Course> CourseList = await _restInterface.GetCourses();
            return CourseList;
        }

        //These methods are the ones we call from courseViewModel and ChapterViewModel
        public async Task<List<ChapterLevels>> FetchChapters(string id)
        {
            Cache = BlobCache.LocalMachine;
            List<Chapter> getChaptersTask = await GetChaptersAsync(id);
            List<ChapterLevels> chapterLevels = FetchSortedLevels(getChaptersTask);
            await Cache.InsertObject("chapters", chapterLevels, DateTimeOffset.Now.AddHours(2));
            List<ChapterLevels> chapters = await Cache.GetObject<List<ChapterLevels>>("chapters");        
            return chapters;
        }

        public async Task<List<IPage>> FetchPages(string id)
        {
            Cache = BlobCache.LocalMachine;
            List<IPage> getPagesTask = await GetPagesAsync(id);
            await Cache.InsertObject("pages", getPagesTask, DateTimeOffset.Now.AddHours(2));
            List<IPage> pages = await Cache.GetObject<List<IPage>>("pages");
            return pages;
        }
        //END

        //These methods call on our ServiceHelper which is implemented in RestInterface
        async Task<List<IPage>> GetPagesAsync(string id)
        {
            Task<List<IPage>> getPagesTask = UserInitiated.Getpages(id);
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

        private List<ChapterLevels> FetchSortedLevels(List<Chapter> chapterList)
        {

            List<ChapterLevels> listOfChapters = new List<ChapterLevels>();
            foreach (var chapter in chapterList)
            {
                while (int.Parse(chapter.Level) > listOfChapters.Count)
                {
                    listOfChapters.Add(new ChapterLevels() { ChapterList = new List<Chapter>() });
                }
                listOfChapters[int.Parse(chapter.Level) - 1].ChapterList.Add(chapter);
                listOfChapters[int.Parse(chapter.Level) - 1].Level = chapter.Level;
            }
            return listOfChapters;
        }

    }
}
