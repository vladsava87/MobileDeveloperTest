using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Steer73.FormsApp.Interfaces;
using Steer73.FormsApp.Model;
using Steer73.FormsApp.ViewModels;

namespace Steer73.FormsApp.Tests.ViewModels
{
    [TestFixture]
    public class UsersViewModelTests
    {
        [Test]
        public async Task InitializeFetchesTheData()
        {
            var userService = new Mock<IUserService>();
            var messageService = new Mock<IMessageService>();

            var viewModel = new UsersViewModel(
                userService.Object,
                messageService.Object);

            userService
                .Setup(p => p.GetUsers())
                .Returns(Task.FromResult(Enumerable.Empty<User>()))
                .Verifiable();

            await viewModel.Initialize();

            userService.VerifyAll();

            Assert.AreEqual(viewModel.Users, new ObservableCollection<User>());
        }

        [Test]
        public async Task InitializeShowErrorMessageOnFetchingError()
        {
            var messageService = new Mock<IMessageService>();
            var userService = new Mock<IUserService>();
            
            var viewModel = new UsersViewModel(
                userService.Object,
                messageService.Object);
            
            userService
                .Setup(p => p.GetUsers())
                .Returns((Task<IEnumerable<User>>) null)
                .Verifiable();
            
            await viewModel.Initialize();

            userService.VerifyAll();
            
            Assert.AreEqual(userService.Object.GetUsers(), null);
        }
    }
}
