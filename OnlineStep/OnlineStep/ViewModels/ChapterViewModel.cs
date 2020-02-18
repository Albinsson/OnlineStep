using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using OnlineStep.Models;
using OnlineStep.Services;

namespace OnlineStep.ViewModels
{
    class ChapterViewModel : BaseViewModel
    {

        private List<Chapter> chapterList;

        public ChapterViewModel()
        {
            Debug.WriteLine("ChapterViewModel()");
            Debug.WriteLine(CurrentChapterID);

            Task.Run(async () => { await InitAsyncApiRequest(); }).Wait();
        }

        public async Task InitAsyncApiRequest()
        {

            try
            {
                if (CurrentChapterID == String.Empty) { throw new ArgumentException("CurrentChapterID cannot be null or empty string");}

                Debug.WriteLine("InitAsyncApiRequest()");
                var temp = RestClient.GetChaptersAsync(CurrentChapterID);
                chapterList = await temp;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("InitAsyncApiRequest()");
                Debug.WriteLine(ex);

            }
        }

        public List<Chapter> ChapterList
        {
            get => chapterList;
            set => chapterList = value;
        }
    }
}
