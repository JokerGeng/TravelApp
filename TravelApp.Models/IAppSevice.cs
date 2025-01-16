using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Models
{
    public interface IAppSevice
    {
        Task<string> AuthenticateUser(LoginDto loginModel);
        Task<(bool IsSuccess, string ErrorMessage)> RegisterUser(RegisterDto loginModel);
    }
}
