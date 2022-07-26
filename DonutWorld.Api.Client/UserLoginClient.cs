using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace DonutWorld.Api.Client
{
    public class UserLoginClient : Abstractions.IUserLoginClient
    {
        private readonly Abstractions.IHttpClientBase _httpClientBase;

        public UserLoginClient(Abstractions.IHttpClientBase httpClientBase)
        {
            _httpClientBase = httpClientBase;
        }

        public string baseSegment => "UserLogin";

        public async Task LoginAsync(Models.UserLoginModel userLoginModel)
        {
            await _httpClientBase.BaseUrl
                .AppendPathSegment(baseSegment)
                .AppendPathSegment("Login")
                .PostJsonAsync(userLoginModel);
        }
    }
}
