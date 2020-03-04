using OnlineStep.Helpers;
using OnlineStep.Models;
using OnlineStep.Navigation.Interfaces;
using OnlineStep.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnlineStep.ViewModels
{
    class TestingChapterViewModel : BaseViewModel
    {
        private List<ChapterLevels> chapterLevels;
        private readonly INavigator _navigator;
        private Data Data;
        private readonly NameOfOurAppService Service = new NameOfOurAppService();
        public List<ChapterLevels> ChapterLevels         
        {
            get => chapterLevels;
            set => chapterLevels = value;
        }
        public TestingChapterViewModel(INavigator navigator)
        {
            InitAsync();
            _navigator = navigator;         
        }

        private async System.Threading.Tasks.Task InitAsync()
        {
            Data = DataCenter.GetSingletonProcedure("GetChapterID");
            Debug.WriteLine(Data.Obj.ToString());
            List<Chapter> chapterList = await Service.FetchChapters(Data.Obj.ToString());
            ChapterLevels = FetchSortedLevels(chapterList);
        }

        public ICommand GoToPageView => new Command(async (id) =>
        {
            List<Models.Page.RootObject> pageList = new List<Models.Page.RootObject>();

            PageNavigator.pageList = await Service.FetchPages(id.ToString());
            PageNavigator.index = 0;
            PageNavigator.PushNextPage(_navigator);
        });

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
