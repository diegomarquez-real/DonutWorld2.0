using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonutWorld.Data.Bootstrapper
{
    //Inversion Of Control for dependencies.
    public class IoCContainer
    {
        public static void Init(IServiceCollection services)
        {
            services.AddTransient<DonutWorld.Data.Abstractions.Repositories.IUserRepository, DonutWorld.Data.Repositories.UserRepository>();
            services.AddTransient<DonutWorld.Data.Abstractions.Repositories.IUserLoginRepository, DonutWorld.Data.Repositories.UserLoginRepository>();
        }
    }
}
