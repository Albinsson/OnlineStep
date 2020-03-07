using OnlineStep.Helpers;
using OnlineStep.Models;
using OnlineStep.Navigation.Interfaces;
using OnlineStep.Services;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using IPage = OnlineStep.Models.IPage;


namespace OnlineStep.ViewModels
{
    class ChapterViewModel : BaseViewModel
    {
        private readonly DbHelper dbHelper = new DbHelper();
        private readonly NameOfOurAppService Service = new NameOfOurAppService();
        private readonly INavigator _navigator;
        private Data Data;
  
        public ChapterViewModel(INavigator navigator)
        {
            InitAsync();
            _navigator = navigator;
        }
        public List<ChapterLevels> ChapterLevels { get; set; }


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

            PageNavigator.PageList = dbHelper.GetPages(id.ToString());
            PageNavigator.Index = 0;
            PageNavigator.PushNextPage(_navigator);
        });


    }
}
