using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonutWorld.Api.Client.Bootstrapper
{
    public class IoCContainer
    {
        public static void Init(IServiceCollection services)
        {
            services.AddTransient<Abstractions.IUserLoginClient, UserLoginClient>();
            services.AddTransient<Abstractions.IHttpClientBase, HttpClientBase>();
        }
    }
}
