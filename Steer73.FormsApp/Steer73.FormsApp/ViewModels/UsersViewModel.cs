using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Steer73.FormsApp.Framework;
using Steer73.FormsApp.Interfaces;
using Steer73.FormsApp.Model;

namespace Steer73.FormsApp.ViewModels
{
    public class UsersViewModel : ViewModel
    {
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;

        private ObservableCollection<User> _users = new ObservableCollection<User>();
        public ObservableCollection<User> Users
        {
            get => _users;
            set => SetProperty(ref value, _users);
        }

        public UsersViewModel(
            IUserService userService,
            IMessageService messageService)
        {
            _userService = userService;
            _messageService = messageService;
        }

        public async Task Initialize()
        {
            try
            {
                Message = "Loading users...";
                IsBusy = true;

                var users = await _userService.GetUsers();
                
                Users = new ObservableCollection<User>();
                
                foreach (var user in users)
                {
                    Users.Add(user);
                }
            }
            catch (Exception ex)
            {
                await _messageService.ShowError(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
