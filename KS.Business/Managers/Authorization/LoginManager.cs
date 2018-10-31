using AutoMapper;
using KS.Business.DataContract.Authorization;
using KS.Business.Engines.Authorization;
using KS.Database.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Business.Managers.Authorization
{
    class LoginManager : ILoginManager
    {
        private readonly IQueryForExistingUserInvoker _existingUserInvoker;
        private readonly IMapper _mapper;

        public LoginManager(IQueryForExistingUserInvoker existingUserInvoker, IMapper mapper)
        {
            _existingUserInvoker = existingUserInvoker;
            _mapper = mapper;

        }

        public async Task<ReceivedUserDTO> LoginUser(QueryForExistingUserDTO userDTO)
        {
            var rao = PrepareExistingUserRAO(userDTO);

            var receivedUser = await _existingUserInvoker.InvokeExistingUserCommand(rao);

            var verifyPassEngine = new VerifyPasswordHashEngine();
                
            if (verifyPassEngine.VerifyPasswordHash(userDTO.Password, receivedUser.PasswordHash, receivedUser.PasswordSalt))
                return _mapper.Map<ReceivedUserDTO>(receivedUser);

            return null;
        }

        private QueryForExistingUserRAO PrepareExistingUserRAO(QueryForExistingUserDTO userDTO)
        {
            var rao = _mapper.Map<QueryForExistingUserRAO>(userDTO);
          
            return rao;
        }
    }
}
