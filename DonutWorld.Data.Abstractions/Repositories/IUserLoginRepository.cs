using DonutWorld.Api.Models;
using DonutWorld.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonutWorld.Data.Abstractions.Repositories
{
    public interface IUserLoginRepository
    {
        Task<User> LoginUser(UserLoginModel userLoginModel);
    }
}
