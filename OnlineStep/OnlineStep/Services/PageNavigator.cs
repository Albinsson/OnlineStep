using OnlineStep.Navigation.Interfaces;
using OnlineStep.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using OnlineStep.Models;

namespace OnlineStep.Services
{
    public static class PageNavigator
    {

        public static List<IPage> pageList;
        public static int index;
        public static int maxIndex;

        public static List<IPage> PageList
        {
            get => pageList;
            set => pageList = value;
        }

        public static int Index
        {
            get => index;
            set => index = value;
        }

        public static int MaxIndex
        {
            get => pageList.Count;
            
        }

        public static IPage GetCurrentPage
        {
            get 
            {
                Debug.WriteLine("Getting page where index = " + index);
                return pageList[index];
            }
        }

        public static void PushNextPage(INavigator navigator)
        {

            Debug.WriteLine("Index: " + index);
            Debug.WriteLine("PageList Count: " + pageList.Count);
            
            if (pageList.Count == 0)
            {
                throw new System.ArgumentException("PageList", "PageList cannot be null");
            };



            if (pageList.Count <= index)
            {
                PageList = new List<IPage>();
                navigator.PushAsync<ChapterViewModel>();
            };

            if (pageList.Count > 0 && pageList.Count > index)
            {

                switch (pageList[index].type.ToLower())
                {
                    case "mcq":
                        navigator.PushAsync<McqViewModel>();
                        index++;
                        break;

                    case "cloze":
                        navigator.PushAsync<ClozeViewModel>();
                        index++;
                        break;

                    default:
                        throw new System.ArgumentException("PageList", "Page type not found: " + pageList[index].type);
                }
            }

            

        }

        public static float GetProgress()
        {
            if(index==0)
            {
                return 0.0f;
            } else
            {         
            float progress = index * (1 / (float)pageList.Count);
            return progress;
            }

        }
    }
}