using CarInsurance.Core.Models.Settings.Auth;
using CarInsurance.Core.Models.Users;

namespace CarInsurance.Core.Interfaces;

public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<User> GetAll();
    User GetById(int id);
}
