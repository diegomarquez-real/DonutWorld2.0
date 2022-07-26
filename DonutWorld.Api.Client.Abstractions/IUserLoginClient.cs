using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonutWorld.Api.Client.Abstractions
{
    public interface IUserLoginClient
    {
        Task LoginAsync(Models.UserLoginModel userLoginModel);
    }
}
