using OnlineStep.Models;
using OnlineStep.Navigation.Interfaces;
using OnlineStep.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;

namespace OnlineStep.Services
{
    public static class PageNavigator
    {
        public static List<IPage> PageList { get; set; }
        public static int Index { get; set; }

        public static IPage GetCurrentPage
        {
            get
            {
                Debug.WriteLine("Getting page where index = " + Index);
                return PageList[Index];
            }
        }

        public static void PushNextPage(INavigator navigator)
        {

            Debug.WriteLine("Index: " + Index + "\nPageList Count: " + PageList.Count);

            if (PageList.Count == 0)
            {
                throw new System.ArgumentException("PageList cannot be null", "PageList");
            };

            // All pages has been displayed
            if (PageList.Count <= Index)
            {
                PageList = new List<IPage>();
                navigator.PushAsync<ChapterViewModel>();
            };

            // Displays next pages
            if (PageList.Count > 0 && PageList.Count > Index)
            {
                switch (PageList[Index].type.ToLower())
                {
                    case "mcq":
                        navigator.PushAsync<McqViewModel>();
                        Index++;
                        break;

                    case "cloze":
                        navigator.PushAsync<ClozeViewModel>();
                        Index++;
                        break;

                    default:
                        throw new System.ArgumentException("PageList", "Page type not found: " + PageList[Index].type);
                }
            }
        }

        public static float GetProgress()
        {
            if (Index == 0)
            {
                return 0.0f;
            }
            else
            {
                float progress = Index * (1 / (float)PageList.Count);
                return progress;
            }
        }
    }
}