using System.Collections.Generic;
using System.Threading.Tasks;
using Steer73.FormsApp.Model;

namespace Steer73.FormsApp.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
    }
}