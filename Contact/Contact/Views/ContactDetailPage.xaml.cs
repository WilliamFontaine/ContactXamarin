using Contact.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contact.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailPage : ContentPage
    {
        public ContactDetailPage()
        {
            InitializeComponent();
            BindingContext = new ContactDetailViewModel();
        }
    }
}