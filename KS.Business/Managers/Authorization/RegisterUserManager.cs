using AutoMapper;
using KS.API.DataContract.Authorization;
using KS.Business.DataContract.Authorization;
using KS.Business.Engines.Authorization;
using KS.Database.Authorization.Invokers;
using KS.Database.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Business.Managers.Authorization
{
    public class RegisterUserManager : IRegisterUserManager
    {
        private readonly IUserRegisterInvoker _userRegisterInvoker;
        private readonly IMapper _mapper;

        public RegisterUserManager(IUserRegisterInvoker userRegisterInvoker, IMapper mapper)
        {
            _userRegisterInvoker = userRegisterInvoker;
            _mapper = mapper;

        }

        public async Task<bool> RegisterUser(NewUserCreateDTO userDTO)
        {
            var rao = PrepareUserRAOForRegister(userDTO);

            return await _userRegisterInvoker.InvokeRegisterUserCommand(rao);

        }

        private UserRegisterRAO PrepareUserRAOForRegister(NewUserCreateDTO userDTO)
        {
            byte[] passwordHash, passwordSalt;

            var hashEngine = new CreatePasswordHashEngine();
            hashEngine.CreatePasswordHash(userDTO.Password, out passwordHash, out passwordSalt);

            var rao = _mapper.Map<UserRegisterRAO>(userDTO);
            rao.PasswordHash = passwordHash;
            rao.PasswordSalt = passwordSalt;

            return rao;
        }
    }
}
