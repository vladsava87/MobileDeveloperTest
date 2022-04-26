using System.Collections.Generic;
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
            
            messageService
                .Setup(p => p.ShowError("Object reference not set to an instance of an object."))
                .Returns(Task.CompletedTask)
                .Verifiable();
            
            await viewModel.Initialize();

            userService.VerifyAll();
            messageService.VerifyAll();
        }
    }
}
