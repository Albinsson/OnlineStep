using OnlineStep.Helpers;
using OnlineStep.Models;
using OnlineStep.Navigation.Interfaces;
using OnlineStep.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using IPage = OnlineStep.Models.IPage;


namespace OnlineStep.ViewModels
{
    class ChapterViewModel : BaseViewModel
    {

        private List<Chapter> chapterList;
        private readonly DbHelper dbHelper = new DbHelper();
        private readonly NameOfOurAppService Service = new NameOfOurAppService();
        private readonly INavigator _navigator;
        private Data Data;

        private List<ChapterLevels> chapterLevels;
        public ChapterViewModel(INavigator navigator)
        {
            InitAsync();
            _navigator = navigator;
        }
        public List<ChapterLevels> ChapterLevels
        {
            get => chapterLevels;
            set => chapterLevels = value;
        }

        private async System.Threading.Tasks.Task InitAsync()
        {
            Data = DataCenter.GetSingletonProcedure("GetChapterID");
            ChapterLevels = await Service.FetchChapters(Data.Obj.ToString());
        }

        public ICommand GoToPageView => new Command((id) =>
        {
            List<IPage> pageList = new List<IPage>();
            pageList = dbHelper.GetPages(id.ToString());
            var objList = pageList.ConvertAll(x => (object)x);
            DataCenter.CreateListProcedure("SetPageList", objList);

            PageNavigator.pageList = dbHelper.GetPages(id.ToString());
            PageNavigator.index = 0;
            PageNavigator.PushNextPage(_navigator);
        });


    }
}
