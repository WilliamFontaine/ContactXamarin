using Contact.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contact.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewContactPage : ContentPage
    {
        public NewContactPage()
        {
            InitializeComponent();
            BindingContext = new NewContactViewModel();
        }
    }
}