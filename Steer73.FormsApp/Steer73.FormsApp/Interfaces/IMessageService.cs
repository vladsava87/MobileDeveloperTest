using System.Threading.Tasks;

namespace Steer73.FormsApp.Interfaces
{
    public interface IMessageService
    {
        Task ShowError(string message); 
    }
}