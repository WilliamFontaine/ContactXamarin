using System.IO;
using Contact.Repositories;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Contact
{
    public partial class App : Application
    {
        private readonly string dbPath = Path.Combine(FileSystem.AppDataDirectory, "contacts.db3");

        public App()
        {
            InitializeComponent();

            ContactRepository = new ContactRepository(dbPath);

            MainPage = new AppShell();
        }

        public static IRepository<Models.Contact> ContactRepository { get; private set; }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}