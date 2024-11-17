using System.ComponentModel.DataAnnotations;
using Xamarin.Forms;

namespace Contact.ViewModels
{
    [QueryProperty(nameof(ContactId), nameof(ContactId))]
    internal class ContactDetailViewModel : BaseViewModel
    {
        private Models.Contact _contact;
        private int contactId;

        public ContactDetailViewModel()
        {
            Contact = new Models.Contact();
            EditCommand = new Command(OnEdit, ValidateEdit);
            DeleteCommand = new Command(OnDelete);
        }

        public int ContactId
        {
            get => contactId;
            set
            {
                contactId = value;
                LoadContact(value);
            }
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

        public Command EditCommand { get; }
        public Command DeleteCommand { get; }

        public async void LoadContact(int contactId)
        {
            Contact = await ContactRepository.Get(contactId);
            Contact.PropertyChanged += (sender, e) => EditCommand.ChangeCanExecute();
        }

        private async void OnEdit()
        {
            await ContactRepository.Update(Contact);

            await Shell.Current.GoToAsync("..");
        }

        private async void OnDelete()
        {
            await ContactRepository.Delete(ContactId);

            await Shell.Current.GoToAsync("..");
        }

        private bool ValidateEdit()
        {
            var validationContext = new ValidationContext(Contact, null, null);

            return Validator.TryValidateObject(Contact, validationContext, null, true);
        }
    }
}