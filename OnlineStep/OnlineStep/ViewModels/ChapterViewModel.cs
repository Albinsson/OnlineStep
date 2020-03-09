using OnlineStep.Helpers;
using OnlineStep.Models;
using OnlineStep.Navigation.Interfaces;
using OnlineStep.Services;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;


namespace OnlineStep.ViewModels
{
    class ChapterViewModel : BaseViewModel
    {
        private readonly DbHelper dbHelper = new DbHelper();
        private readonly DbService Service = new DbService();
        private readonly INavigator _navigator;
        private Data Data;
  
        public ChapterViewModel(INavigator navigator)
        {
            InitAsyncApiRequest();
            _navigator = navigator;
        }
        public List<ChapterLevels> ChapterLevels { get; set; }


        private async System.Threading.Tasks.Task InitAsyncApiRequest()
        {
            Data = DataCenter.GetSingletonProcedure("GetChapterID");
            ChapterLevels = await Service.FetchChapters(Data.Obj.ToString());
        }

        public ICommand GoToPageView => new Command((id) =>
        {
            var pageList = dbHelper.GetPages(id.ToString());
            var objList = pageList.ConvertAll(x => (object)x);
            DataCenter.CreateListProcedure("SetPageList", objList);

            PageNavigator.PageList = dbHelper.GetPages(id.ToString());
            PageNavigator.Index = 0;
            PageNavigator.PushNextPage(_navigator);
        });


    }
}
