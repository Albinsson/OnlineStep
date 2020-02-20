using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using OnlineStep.Annotations;
using OnlineStep.Navigation.Interfaces;

namespace OnlineStep.ViewModels
{
    public abstract class BaseViewModel : IViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string CurrentCourseID { set; get; }

        public string Test = "Test";

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyname = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
            }



        public List<Object> PageList { get; set; }



    }
}



    