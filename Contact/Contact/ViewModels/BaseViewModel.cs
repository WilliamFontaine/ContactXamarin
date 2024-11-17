using System.ComponentModel;
using System.Runtime.CompilerServices;
using Contact.Repositories;

namespace Contact.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool isBusy;
        public IRepository<Models.Contact> ContactRepository => App.ContactRepository;

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}