using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Steer73.FormsApp.Framework
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        
        protected virtual void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return;

            field = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
