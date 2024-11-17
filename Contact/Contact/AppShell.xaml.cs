using Contact.Views;
using Xamarin.Forms;

namespace Contact
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NewContactPage), typeof(NewContactPage));
            Routing.RegisterRoute(nameof(ContactDetailPage), typeof(ContactDetailPage));
        }
    }
}