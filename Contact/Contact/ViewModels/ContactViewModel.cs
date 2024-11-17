using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Contact.Views;
using Xamarin.Forms;

namespace Contact.ViewModels
{
    internal class ContactViewModel : BaseViewModel
    {
        private Models.Contact _contact;

        public ContactViewModel()
        {
            Contacts = new ObservableCollection<Models.Contact>();
            LoadContactsCommand = new Command(async () => await ExecuteLoadContactsCommand());
            ContactTapped = new Command<Models.Contact>(OnContactSelected);
            AddContactCommand = new Command(OnAddContact);
        }

        public ObservableCollection<Models.Contact> Contacts { get; set; }

        public Command LoadContactsCommand { get; set; }

        public Command AddContactCommand { get; set; }

        public Command<Models.Contact> ContactTapped { get; set; }

        public Models.Contact SelectedContact
        {
            get => _contact;
            set
            {
                _contact = value;
                OnContactSelected(value);
            }
        }

        private async Task ExecuteLoadContactsCommand()
        {
            IsBusy = true;
            try
            {
                Contacts.Clear();
                var contacts = await ContactRepository.GetAll();
                foreach (var contact in contacts) Contacts.Add(contact);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedContact = null;
        }

        private async void OnAddContact()
        {
            await Shell.Current.GoToAsync(nameof(NewContactPage));
        }

        private async void OnContactSelected(Models.Contact contact)
        {
            if (contact == null)
                return;

            await Shell.Current.GoToAsync(
                $"{nameof(ContactDetailPage)}?{nameof(ContactDetailViewModel.ContactId)}={contact.Id}");
        }
    }
}