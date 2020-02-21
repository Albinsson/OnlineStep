using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using OnlineStep.Helpers;
using OnlineStep.Navigation.Interfaces;
using OnlineStep.ViewModels;

namespace OnlineStep.Services
{

    public class PageNavigator
    {
        private List<Models.Page.RootObject> _pageList;
        private bool _hasPageList = false;
        private int _index = 0;
        private int _size;
        
        public PageNavigator()
        {
            DbHelper dbHelper = new DbHelper();
            String chapterID = "5e3950a2dd22b950349ee26b";
            PageList = dbHelper.GetPages(chapterID);
            Thread.Sleep(3000);
        }

        public PageNavigator(List <Models.Page.RootObject> pageList)
        {
            _pageList = pageList;
            _hasPageList = true;
            _size = pageList.Count;
        }

        public List<Models.Page.RootObject> PageList
        {
            get => _pageList;
            set
            {
                _pageList = value;
                _index = 0;
                _hasPageList = true;
                _size = PageList.Count;
            }
        }

        public int GetIndex
        {
            get => _index;
        }

        public int GetSize
        {
            get => _size;
        }

        public Models.Page.RootObject LoadNextPage()
        {
            if (_hasPageList == false)
            {
                throw new System.ArgumentException("PageList cannot be null", "PageList");
            }

            _index++;
            if (_index >= _pageList.Count)
            {
                //TODO 
                Debug.WriteLine("No more pages i PageList");
            }

            return _pageList[_index];
        }

        public void PushNextPage(INavigator navigator)
        {
            Debug.WriteLine("PushNextPage, pageNumber:  " + _pageList[_index] + " of " + _pageList.Count);
            Debug.WriteLine("PageType:" + _pageList[_index].type);


            switch (_pageList[_index].type)
            {
                case "Mcq":
                    navigator.PushAsync<McqViewModel>();
                    break;
                case "cloze":
                    navigator.PushAsync<ClozeViewModel>();
                    break;
                default:
                    Debug.WriteLine("Page type not found: " + _pageList[_index].type);
                    break;
            }
        }
    }
}
