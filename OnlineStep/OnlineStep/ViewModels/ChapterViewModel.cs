using Newtonsoft.Json;
using OnlineStep.Helpers;
using OnlineStep.Models;
using OnlineStep.Navigation.Interfaces;
using OnlineStep.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;


namespace OnlineStep.ViewModels
{
    class ChapterViewModel : BaseViewModel
    {
        private readonly OnlineStepApiService Service = new OnlineStepApiService();
        private readonly INavigator _navigator;
        private Data Data;
  
        public ChapterViewModel(INavigator navigator)
        {
            _ = InitAsyncApiRequest();
            _navigator = navigator;
            
        }

        private void UnlockLevels()
        {
            Debug.WriteLine("UnlockLevels start: ");
            List<User.ChapterProgress> chapterProgressList = User.Instance.ChapterProgressList;
            double progressTreshold = 0.5;
            for (int i = 0; i < ChapterLevels.Count; i++)
            {
                
                if (ChapterLevels[i].Level.Equals("1"))
                {
                    ChapterLevels[i].Locked = false;
                }
                else
                {
                    ChapterLevels[i].Locked = !ChapterLevels[i - 1].Chapters.All(chapter => chapterProgressList.Any(chapterProgress => chapterProgress.ChapterId.Equals(chapter._id) && chapterProgress.Progress >= progressTreshold));
                }
                ChapterLevels[i].Chapters.All(chapter => chapter.Locked = ChapterLevels[i].Locked);
                Debug.WriteLine("Level " + ChapterLevels[i].Level + " locked: " + ChapterLevels[i].Locked);
            }
            Debug.WriteLine("UnlockLevels end: ");
        }

        //Constructor used by Unit Test
        public ChapterViewModel()
        {
        }
        public List<ChapterLevel> ChapterLevels { get; set; }
        public List<IPage> Pages { get; set; }

        public bool IsLocked(string _id)
        {
            foreach (var item in User.Instance.ChapterProgressList)
            {
                if (item.ChapterId.Equals(_id) && item.Progress >= 0.8)
                {
                    return false;
                }
            }
            return true;
        }

        private async System.Threading.Tasks.Task InitAsyncApiRequest()
        {
            ChapterLevels = await Service.FetchChapterLevels(Global.Instance.CourseId);
            UnlockLevels();
        }
        private async System.Threading.Tasks.Task<List<IPage>> LoadPages(string id)
        {
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.Converters.Add(new PageConverter());
            var myApi = RestService.For<IOnlineStepApi>("https://online-step.herokuapp.com",
                new RefitSettings
                {
                    ContentSerializer = new JsonContentSerializer(jsonSerializerSettings)
                });
            return await myApi.GetPages(id);
        }

        public ICommand GoToPageView => new Command<string>(async (chapterId) =>
        {
            Global.Instance.ChapterId = chapterId;
            PageNavigator.PageList = await LoadPages(chapterId.ToString());
            PageNavigator.Index = 0;
            PageNavigator.PushNextPage(_navigator);
        });


    }
}
