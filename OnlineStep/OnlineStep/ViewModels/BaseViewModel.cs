using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using OnlineStep.Annotations;

namespace OnlineStep.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string CurrentChapterID; 

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Our Code starts here

        protected bool SetProperty<T>(ref T backfield, T value,
            [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backfield, value))
            {
                return false;
            }
            backfield = value;
            OnPropertyChanged(propertyName);
            return true;
        }

    }
}
