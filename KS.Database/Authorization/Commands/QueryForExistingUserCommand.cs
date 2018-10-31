using KS.Database.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Commands
{
    class QueryForExistingUserCommand : IQueryForExistingUserCommand
    {
        private readonly IQueryForExistingUserReceiver _receiver;

        public QueryForExistingUserCommand(IQueryForExistingUserReceiver reciver)
        {
            _receiver = reciver;
        }

        public async Task<ReceivedUserRAO> Execute(QueryForExistingUserRAO userRAO)
        {
            return await _receiver.GetUserByUsername(userRAO);
        }
    }
}
