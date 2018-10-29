using KS.API.DataContract.Authorization;
using KS.Business.DataContract.Authorization;
using KS.Business.Engines.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Business.Managers.Authorization
{
    public class RegisterUserManager : IRegisterUserManager
    {
        public Task<NewUserCreateDTO> RegisterUser(NewUserCreateRequest userRequest)
        {
            NewUserCreateDTO dto = PrepareUserDTOForRegister(userRequest);

            throw new Exception();
            //create new instance of the engine x
            //call createpasswordhash method x
            //pass variable into password hash x
            //prepare the DTO object for the next layer x
            //instantiate the class for the database
            //call the Invoker method in the DAL

            //store username in variable
        }

        private NewUserCreateDTO PrepareUserDTOForRegister(NewUserCreateRequest userRequest)
        {
            byte[] passwordHash, passwordSalt;

            var hashEngine = new CreatePasswordHashEngine();
            hashEngine.CreatePasswordHash(userRequest.Password, out passwordHash, out passwordSalt);

            var userDTO = MapUserRequestObjectToDTO( userRequest, passwordHash, passwordSalt);

            return userDTO;
        }

        private NewUserCreateDTO MapUserRequestObjectToDTO(NewUserCreateRequest userRequest, byte[] passwordHash, byte[] passwordSalt)
        {
            var userDTO =
                new NewUserCreateDTO
                {
                    Username = userRequest.Username,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };
            return userDTO;
        }
    }
}
