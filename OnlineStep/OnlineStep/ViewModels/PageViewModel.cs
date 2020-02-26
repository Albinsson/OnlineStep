using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using OnlineStep.Helpers;
using OnlineStep.Models;
using OnlineStep.Navigation.Interfaces;
using OnlineStep.Services;
using Xamarin.Forms;

namespace OnlineStep.ViewModels
{
    class PageViewModel : BaseViewModel
    {
        private List<string> answerList;
        private List<object> pageList;
        public List<string> AnswerList { get => answerList; set => answerList = value; }
        public List<object> PageList { get => pageList; set => pageList = value; }
        private readonly INavigator _navigator;
        private Data Data;
        
        public PageViewModel(INavigator navigator)
        {
            _navigator = navigator;
            Data = DataCenter.GetListProcedure("GetPageList");
            DistributeData();
            Debug.WriteLine(PageList[0].GetType());
        }

        void DistributeData()
        {
            foreach(var i in Data.ObjList)
            {
                if(i is Mcq)
                {
                    Mcq mcq = (Mcq)i;
                    PageList.Add(mcq);
                }
                if(i is Cloze)
                {
                    Cloze cloze = (Cloze)i;
                    PageList.Add(cloze);
                }                       
            }
        }

        public ICommand AnswerAction => new Command(() =>
        {
            
        });

        
    }
}
