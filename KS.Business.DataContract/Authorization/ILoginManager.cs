using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KS.Business.DataContract.Authorization
{
    public interface ILoginManager
    {
        Task<ReceivedUserDTO> LoginUser(QueryForExistingUserDTO userRequest);

        string GenerateTokenForUser(ReceivedUserDTO receivedExistingUser);
    }
}
