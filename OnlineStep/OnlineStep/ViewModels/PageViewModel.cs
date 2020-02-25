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
        public List<string> AnswerList { get => answerList; set => answerList = value; }
        private readonly INavigator _navigator;
        private Data Data;
        public PageViewModel(INavigator navigator)
        {
            _navigator = navigator;
            Data = DataCenter.GetListProcedure("GetPageList");
            DistributeData();
        }

        void DistributeData()
        {
            foreach(var i in Data.ObjList)
            {
                Debug.WriteLine("DistributeData", i.GetType());               
            }
        }

        public ICommand AnswerAction => new Command(() =>
        {
            
        });

    }
}
