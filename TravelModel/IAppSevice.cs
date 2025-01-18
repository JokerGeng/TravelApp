using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelModel
{
    public interface IAppSevice
    {
        Task<string> AuthenticateUser(LoginDto loginModel);
        Task<(bool IsSuccess, string ErrorMessage)> RegisterUser(RegisterDto loginModel);
    }
}
