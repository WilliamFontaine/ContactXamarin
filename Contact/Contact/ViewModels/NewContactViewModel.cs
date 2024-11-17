using System;
using System.ComponentModel.DataAnnotations;
using Xamarin.Forms;

namespace Contact.ViewModels
{
    public class NewContactViewModel : BaseViewModel
    {
        private Models.Contact _contact;


        public NewContactViewModel()
        {
            Contact = new Models.Contact();
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            Contact.PropertyChanged += (sender, e) => SaveCommand.ChangeCanExecute();
        }

        public Models.Contact Contact
        {
            get => _contact;
            set
            {
                _contact = value;
                OnPropertyChanged();
            }
        }

        public Command SaveCommand { get; }

        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            try
            {
                await ContactRepository.Create(Contact);
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private bool ValidateSave()
        {
            var validationContext = new ValidationContext(Contact, null, null);

            return Validator.TryValidateObject(Contact, validationContext, null, true);
        }
    }
}