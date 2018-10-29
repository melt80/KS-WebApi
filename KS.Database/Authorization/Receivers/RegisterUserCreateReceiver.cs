using KS.Business.DataContract.Authorization;
using KS.Database.Context;
using KS.Database.DataContract.Authorization;
using KS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Receivers
{
    public class RegisterUserCreateReceiver : IAuthorizationReceiver
    {
        private readonly KSContext _context;

        public RegisterUserCreateReceiver(KSContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterUser(NewUserCreateDTO userDTO)
        {
            //Map DTO to RAO
            //Create Guid in RAO
            UserRegisterRAO userRAO = MapRegisterDTOtoRegisterRAO(userDTO);
            //Map the RAO to an entity
            UserEntity userEntity = MapRegisterRAOtoUserEntity(userRAO);
            //Create a user
            return await CreateUser(userEntity);
        }

        private async Task<bool> CreateUser(UserEntity userEntity)
        {
            await _context.UserTableAccess.AddAsync(userEntity);
            return await _context.SaveChangesAsync() == 1;
        }

        private UserEntity MapRegisterRAOtoUserEntity(UserRegisterRAO userRAO)
        {
            var entity =
                new UserEntity
                {
                    OwnerId = userRAO.OwnerId,
                    Username = userRAO.Username,
                    PasswordHash = userRAO.PasswordHash,
                    PasswordSalt = userRAO.PasswordSalt,
                };
            return entity;
        }

        private UserRegisterRAO MapRegisterDTOtoRegisterRAO(NewUserCreateDTO userDTO)
        {
            var userRAO =
                new UserRegisterRAO
                {
                    OwnerId = Guid.NewGuid(),
                    Username = userDTO.Username,
                    PasswordHash = userDTO.PasswordHash,
                    PasswordSalt = userDTO.PasswordSalt
                };
            return userRAO;
        }
    }
}
