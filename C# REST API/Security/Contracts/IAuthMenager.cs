using entityf.Data.Users;
using Microsoft.AspNetCore.Identity;

namespace entityf.Contracts
{
    public interface IAuthMenager
    {
        Task<IEnumerable<IdentityError>> RegisterUser(ApiUserReg apiUserReg);
        Task<AuthResp> Login(ApiUserLog apiUserLog);
    }
}
