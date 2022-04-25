using Steer73.FormsApp.Framework;
using Steer73.FormsApp.Services;
using Steer73.FormsApp.ViewModels;
using Xamarin.Forms.Xaml;

namespace Steer73.FormsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersView : BaseView
    {
        private UsersViewModel _viewModel;
        
        public UsersView()
        {
            InitializeComponent();

            BindingContext = _viewModel = new UsersViewModel(
                new UserService(),
                new MessageService());
        }

        protected override async void OnAppearing()
        {
            await _viewModel.Initialize();
            
            base.OnAppearing();
        }
    }
}
