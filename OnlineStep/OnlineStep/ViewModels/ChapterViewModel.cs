using Newtonsoft.Json;
using OnlineStep.Helpers;
using OnlineStep.Models;
using OnlineStep.Navigation.Interfaces;
using OnlineStep.Services;
using Refit;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;


namespace OnlineStep.ViewModels
{
    class ChapterViewModel : BaseViewModel
    {
        private readonly DbHelper dbHelper = new DbHelper();
        private readonly ApiFetcher Service = new ApiFetcher();
        private readonly INavigator _navigator;
        private Data Data;
  
        public ChapterViewModel(INavigator navigator)
        {
            _ = InitAsyncApiRequest();
            _navigator = navigator;
        }
        //TEST CONSTRUCTOR
        public ChapterViewModel()
        {
        }

        public List<ChapterLevels> ChapterLevels { get; set; }
        public List<IPage> Pages { get; set; }


        private async System.Threading.Tasks.Task InitAsyncApiRequest()
        {
            Data = DataCenter.GetSingletonProcedure("GetChapterID");
            ChapterLevels = await Service.FetchChapters(Data.Obj.ToString());
        }
        private async System.Threading.Tasks.Task<List<IPage>> LoadPages(string id)
        {
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.Converters.Add(new PageConverter());
            var myApi = RestService.For<RestInterface>("https://online-step.herokuapp.com",
                new RefitSettings
                {
                    ContentSerializer = new JsonContentSerializer(jsonSerializerSettings)
                });
            return await myApi.GetPages(id);
        }

        public ICommand GoToPageView => new Command(async (id) =>
        {
            Debug.WriteLine("GoToPageView: Chapter " + id + " pressed");
            ApiFetcher apiFetcher = new ApiFetcher();
            List<IPage> pages = new List<IPage>();
            Debug.WriteLine("GoToPageView: Calling LoadPages()");
            PageNavigator.PageList = await LoadPages(id.ToString());
            Debug.WriteLine("GoToPageView: 1");
            PageNavigator.Index = 0;
            Debug.WriteLine("GoToPageView: 2");
            PageNavigator.PushNextPage(_navigator);
            Debug.WriteLine("GoToPageView: 3");
        });


    }
}
