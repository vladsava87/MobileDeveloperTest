using System.Threading.Tasks;
using Steer73.FormsApp.Interfaces;
using Xamarin.Forms;

namespace Steer73.FormsApp.Services
{
    public class MessageService : IMessageService
    {
        public Task ShowError(string message)
        {
            return Application.Current.MainPage.DisplayAlert("FormsApp", message, "OK");
        }
    }
}
