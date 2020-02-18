using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OnlineStep.ViewModels
{
    class ChapterViewModel : BaseViewModel
    {
        public ChapterViewModel()
        {
            Debug.WriteLine("ChapterViewModel()");
            Debug.WriteLine(CurrentChapterID);
        }
    }
}
