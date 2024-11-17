using Contact.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contact.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : ContentPage
    {
        private readonly ContactViewModel _viewModel;

        public ContactPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ContactViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}