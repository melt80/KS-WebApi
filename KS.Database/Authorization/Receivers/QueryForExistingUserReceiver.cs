using AutoMapper;
using KS.Database.Context;
using KS.Database.DataContract.Authorization;
using KS.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Receivers
{
    public class QueryForExistingUserReceiver : IQueryForExistingUserReceiver
    {
        private readonly KSContext _context;
        private readonly IMapper _mapper;

        public QueryForExistingUserReceiver(KSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReceivedUserRAO> GetUserByUsername(QueryForExistingUserRAO existingUserRAO)
        {
             UserEntity userEntity = await _context.UserTableAccess.FirstOrDefaultAsync(x => x.Username == existingUserRAO.Username);
            return _mapper.Map<ReceivedUserRAO>(userEntity);
        }

    }


}

        //public async Task<bool> GetUserByUsername(ExistingUserRAO existingUserRAO)
        //{
        //    //await _context
        //    //return await _context.SaveChangesAsync() == 1;
        //}
  
