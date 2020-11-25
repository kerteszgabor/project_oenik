using project.Domain.DTO;
using project.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.WebAPI.Helpers
{
    public static class Mappers
    {
        public static LoginData MapVMToLoginData(LoginViewModel vm, string IP)
        {
            return new LoginData()
            {
                Username = vm.Username,
                Password = vm.Password,
                IPAddress = IP
            };
        }

        public static RegisterData MapVMToRegisterData(RegisterViewModel vm, string registeringUser)
        {
            return new RegisterData()
            {
                Username = vm.Username,
                Password = vm.Password,
                Email = vm.Email,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Role = vm.Role,
                RegisteringUserName = registeringUser
            };
        }
    }
}
