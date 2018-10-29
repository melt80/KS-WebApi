using KS.Business.DataContract.Authorization;
using KS.Database.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Invokers
{
    public class RegisterUserCreateInvoker : IUserRegisterInvoker
    {
        private readonly IAuthorizationCommand _command;

        public RegisterUserCreateInvoker(IAuthorizationCommand command)
        {
            _command = command;
        }
        public async Task<bool> InvokeRegisterUserCommand(NewUserCreateDTO userDTO)
        {
            return await _command.Execute(userDTO);
        }
    }
}
