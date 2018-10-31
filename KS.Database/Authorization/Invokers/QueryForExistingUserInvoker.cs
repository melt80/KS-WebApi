using KS.Database.DataContract.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Database.Authorization.Invokers
{
    public class QueryForExistingUserInvoker : IQueryForExistingUserInvoker
    {
        private readonly IQueryForExistingUserCommand _command;

        public QueryForExistingUserInvoker(IQueryForExistingUserCommand command)
        {
            _command = command;
        }
        public async Task<ReceivedUserRAO> InvokeExistingUserCommand(QueryForExistingUserRAO userRAO)
        {
            return await _command.Execute(userRAO);
        }
    }
}
